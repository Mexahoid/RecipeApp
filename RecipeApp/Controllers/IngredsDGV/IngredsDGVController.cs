using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RecipeApp.Models.IngredsDGV;
using DataStructure = System.Collections.Generic.List<System.Tuple<System.Tuple<string, string>, System.Tuple<string, string>, System.Tuple<string, string>>>;

namespace RecipeApp.Controllers.IngredsDGV
{
    class IngredsDGVController
    {
        private readonly IngredsDGVModel _mdl;
        private DataStructure _data;
        private string _currRecipe;
        public IngredsDGVController(DataGridView dgv, Action onChangeLock)
        {
            _mdl = new IngredsDGVModel(dgv, DataChangeHandler, onChangeLock);
            _data = new DataStructure();
        }

        public void HandleRecipeSelection(string recipeName)
        {
            _currRecipe = recipeName;
            _mdl.LoadData(_currRecipe);
        }

        private void DataChangeHandler(DataStructure data)
        {
            _data = data;
        }

        public void ChangeMode()
        {
            _mdl.ChangeMode();
        }

        public DataStructure GetData()
        {
            return _data;
        }

        public List<Tuple<string, string>> GetNames()
        {
            return _mdl.GetIngredsNames();
        }

        public void Clear()
        {
            _mdl.Clear();
        }
    }
}
