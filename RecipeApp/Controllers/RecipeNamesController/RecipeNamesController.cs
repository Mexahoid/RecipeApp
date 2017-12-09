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
        private event Action<string> OnError;
        private List<Tuple<string, string>> _data;

        public RecipeNamesController(DataGridView recipeNames,
            Action onChangeAction,
            Action<string> onRecipeSelect,
            Action<string> onRecipeInsert,
            Action<string> onError)
        {
            _model = new RecipeNamesModel(recipeNames, DataChangeHandler, CellClickHandler);
            OnChangeLock += onChangeAction;
            OnRecipeSelect += onRecipeSelect;
            OnRecipeInsert += onRecipeInsert;
            OnError += onError;

            _data = new List<Tuple<string, string>>();
            _model.ReloadData();
            _model.FillDataList(_data);

            _data.Add(new Tuple<string, string>(null, null));  // Последний ряд под новый
        }

        public void Lock() => _model.Lock();

        public void Unlock() => _model.Unlock();

        public void ModeChangeHandler()
        {
            _model.ChangeMode();
        }

        private void InsertRecipe(string text)
        {
            OnRecipeInsert?.Invoke(text);
            ReloadData();
        }

        private void UpdateRecipe(int index)
        {
            Connector.GetTable(QueryFactory.Queries.DeleteRecipeByName,
                new Tuple<string, string>("@New", _data[index].Item1),
                new Tuple<string, string>("@Old", _data[index].Item2));
            ReloadData();
        }

        private void DeleteRecipe(int index)
        {
            Connector.GetTable(QueryFactory.Queries.DeleteRecipeByName,
                new Tuple<string, string>("@Name", _data[index].Item2));
            ReloadData();
        }

        private void ReloadData()
        {
            _model.ReloadData();
            _data.Clear();
            _model.FillDataList(_data);
        }

        private void NewRow()
        {
            _data.Clear();
            _model.FillDataList(_data);
            _model.AddRow();
        }

        private void CellClickHandler(int index, string text, MouseButtons mb)
        {
            string ans;
            switch (mb)
            {
                case MouseButtons.Left:
                    if (text == Properties.Resources.AddNewRecipe)
                    {
                        ans = RenameForm.Invoke();
                        AlterAddeableRow(ans);
                    }
                    OnRecipeSelect?.Invoke(text);
                    break;
                case MouseButtons.Right:
                    ans = JunctionForm.Invoke(text);
                    if (ans == null)
                        _data[index] = new Tuple<string, string>(null, _data[index].Item2);
                    else if (ans == Properties.Resources.AddNewRecipe)
                        OnError?.Invoke("Ты че, дурак? Зачем изменять название на системное?");
                    else
                    {
                        if (CheckExistence(ans))
                            OnError?.Invoke("Такой рецепт уже есть.");
                        _model.SetRow(index, ans);
                        _data[index] = new Tuple<string, string>(ans, _data[index].Item2);
                    }
                    break;
            }

        }

        private bool CheckExistence(string text)
        {
            return _data.Any(tuple => tuple.Item1 == text);
        }


        private void AlterAddeableRow(string text)
        {
            if (text != "")
            {
                _model.SetRow(_data.Count - 1, text);
            }
        }

        private void DataChangeHandler(DataGridViewRowCollection rows)
        {
            int lastRowIndex = rows.Count - 1;
            for (int i = 0; i < lastRowIndex; i++)    // Все, кроме последнего
            {
                _data[i] = new Tuple<string, string>(rows[i].Cells[0].Value.ToString(),
                    _data[i].Item2);
            }

            _data[lastRowIndex] = new Tuple<string, string>(
                rows[lastRowIndex].Cells[0].Value.ToString(), null);
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
                if (_data[i].Item1 != null && _data[i].Item2 == null)
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
