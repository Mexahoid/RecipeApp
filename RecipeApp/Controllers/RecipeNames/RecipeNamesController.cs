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
        private event Action OnRecipeInsert;
        private event Action<string> OnError;
        private List<Tuple<string, string>> _data;
        private string _lastName;
        private string _currName;
        private bool _isEditing;

        public RecipeNamesController(DataGridView recipeNames,
            Action onChangeAction,
            Action<string> onRecipeSelect,
            Action onRecipeInsert,
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
        
        
        private void DataChangeHandler(List<Tuple<string, string>> rows)
        {
            _data = rows;
            foreach (var tuple in rows)
            {
                if (tuple.Item2 == _lastName || tuple.Item2 == string.Empty)
                {
                    _currName = tuple.Item1;
                    _lastName = _currName;
                    SelectCellWithName();
                    break;
                }
            }
            OnChangeLock?.Invoke();
        }
        

        public void HandleReject()
        {
            _model.ReloadData();
            //NewRow();
        }

        public Tuple<string, string> GetValue()
        {
            return Tuple.Create(_currName, _lastName);
        }
    }
}
