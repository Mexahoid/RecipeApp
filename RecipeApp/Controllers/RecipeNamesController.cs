using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using System.Windows.Forms;
using RecipeApp.Forms;
using RecipeApp.Models;

namespace RecipeApp.Controllers
{
    class RecipeNamesController
    {
        private bool _editing;

        private readonly RecipeNamesModel _model;
        private event Action OnChangeLock;
        private event Action<string> OnRecipeSelect;
        private event Action<string> OnRecipeInsert;
        private List<Tuple<string, string>> _data;
        /// <summary>
        /// Количество строк изначальной дгв, когда не выбрали режим добавления.
        /// </summary>
        private readonly int _dgvUnchangedModeCount;

        public RecipeNamesController(DataGridView recipeNames,
            Action onChangeAction,
            Action<string> onRecipeSelect)
        {
            _model = new RecipeNamesModel(recipeNames, DataChangeHandler, CellClickHandler);
            OnChangeLock += onChangeAction;
            OnRecipeSelect += onRecipeSelect;

            _data = new List<Tuple<string, string>>();
            _model.ReloadData();
            _model.FillDataList(_data);

            _data.Add(new Tuple<string, string>(null, null));  // Последний ряд под новый
        }

        public void ModeChangeHandler()
        {
            _model.ChangeMode();
        }

        private void InsertRecipe(string text)
        {
            OnRecipeInsert?.Invoke(text);
        }

        private void UpdateRecipe(int index)
        {
            Connector.GetTable(QueryFactory.Queries.DeleteRecipeByName,
                new Tuple<string, string>("@New", _data[index].Item1),
                new Tuple<string, string>("@Old", _data[index].Item2));
        }

        private void DeleteRecipe(int index)
        {
            Connector.GetTable(QueryFactory.Queries.DeleteRecipeByName,
                new Tuple<string, string>("@Name", _data[index].Item2));
        }

        private void NewRow()
        {
            _data = new List<Tuple<string, string>>();
            _model.FillDataList(_data);
            _model.AddRow();
        }

        private void CellClickHandler(int index, string text, MouseButtons mb)
        {
            switch (mb)
            {
                case MouseButtons.Left:
                    OnRecipeSelect?.Invoke(text);
                    break;
                case MouseButtons.Right:
                    string answer = JunctionForm.Invoke(text);
                    if (answer == null)
                        _data[index] = new Tuple<string, string>(null, _data[index].Item2);
                    else if (answer == Properties.Resources.AddNewRecipe)
                        throw new Exception("Ты че, дурак? Зачем изменять название на системное?");
                    else
                    {
                        if (CheckExistence(answer))
                            throw new Exception("Такой рецепт уже есть.");
                        _data[index] = new Tuple<string, string>(answer, _data[index].Item2);
                    }
                    break;
            }

        }

        private bool CheckExistence(string text)
        {
            return _data.Any(tuple => tuple.Item1 == text);
        }


        private void DataChangeHandler(DataGridViewRowCollection rows)
        {
            if (rows.Count == _dgvUnchangedModeCount)
                throw new Exception("Ошибка неверного режима.");
            int lastRowIndex = rows.Count - 1;
            for (int i = 0; i < lastRowIndex; i++)    // Все, кроме последнего
            {
                _data[i] = new Tuple<string, string>(rows[i].Cells[0].Value.ToString(),
                    _data[i].Item2);
            }

            _data[lastRowIndex] = new Tuple<string, string>(
                rows[lastRowIndex].Cells[0].Value.ToString(), "");
        }

        private void ProcessCellClick()
        {

        }

        public void ShowRecipeNames()
        {
            _model.ReloadData();
        }

        public void HandleAccept()
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (_data[i].Item1 == null)
                {
                    DeleteRecipe(i);
                    continue;
                }
                if (_data[i].Item1 != _data[i].Item2)
                {
                    UpdateRecipe(i);
                    continue;
                }
                if(_data[i].Item1 != null && _data[i].Item2 == null)
                    InsertRecipe(_data[i].Item1);
            }

            NewRow();
        }

        public void HandleReject()
        {
            _model.ReloadData();
            NewRow();
        }

    }
}
