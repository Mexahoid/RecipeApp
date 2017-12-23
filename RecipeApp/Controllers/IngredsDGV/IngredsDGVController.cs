using System;
using System.Windows.Forms;
using RecipeApp.Models.IngredsDGV;
using DataStructure = System.Collections.Generic.List<System.Tuple<System.Tuple<string, string>, System.Tuple<string, string>, System.Tuple<string, string>>>;

namespace RecipeApp.Controllers.IngredsDGV
{
    class IngredsDGVController
    {
        private IngredsDGVModel _mdl;
        private DataStructure _data;
        private string _currRecipe;
        public IngredsDGVController(DataGridView dgv, Action onChangeLock)
        {
            _mdl = new IngredsDGVModel(dgv, ReloadHandler, DataChangeHandler, onChangeLock);
            _data = new DataStructure();
        }

        private void ReloadHandler()
        {
            _mdl.LoadData(_currRecipe);
        }

        public void HandleRecipeSelection(string recipeName)
        {
            _currRecipe = recipeName;
            ReloadHandler();
        }

        private void DataChangeHandler(DataStructure data)
        {
            _data = data;
        }

        public void ChangeMode()
        {
            _mdl.ChangeMode();
        }
    }
}
