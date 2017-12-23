using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DBLayer;
using RecipeApp.Forms;
using RecipeApp.Models.RecipeNames;

namespace RecipeApp.Controllers.RecipeNames
{
    class RecipeNamesController
    {
        private readonly RecipeNamesModel _model;
        private event Action OnChangeLock;
        private event Action<string> OnRecipeSelect;
        private event Action<string> OnRecipeInsert;
        private event Action<string> OnError;
        private List<Tuple<string, string>> _data;
        private string _lastName;
        private bool _isEditing;

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
            
            _model.ReloadData();
        }

        public void SelectCellWithName()
        {
            _model.SelectNamedCell(_lastName);
        }
        
        public void Lock() => _model.Lock();

        public void Unlock() => _model.Unlock();

        public void ModeChangeHandler()
        {
            _model.ChangeMode();
            _isEditing = !_isEditing;
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
            _model.FillDataList(_data);
            _data.Add(new Tuple<string, string>(null, null));  // Последний ряд под новый
        }

        private void NewRow()
        {
            _model.FillDataList(_data);
            _data.Add(new Tuple<string, string>(null, null));  // Последний ряд под новый
            _model.AddRow();
        }

        private void CellClickHandler(int index, string text, MouseButtons mb)
        {
            string ans;
            switch (mb)
            {
                case MouseButtons.Left:
                    _lastName = text;
                    OnRecipeSelect?.Invoke(text);
                    break;
            }

        }

        private bool CheckExistence(string text)
        {
            return _data.Any(tuple => tuple.Item1 == text);
        }
        
        private void DataChangeHandler(List<Tuple<string, string>> rows)
        {
            _data = rows;
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
            //NewRow();
        }

    }
}
