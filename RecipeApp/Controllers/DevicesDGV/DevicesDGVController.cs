using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RecipeApp.Models.DevicesDGV;

namespace RecipeApp.Controllers.DevicesDGV
{
    class DevicesDGVController
    {
        private readonly DevicesDGVModel _mdl;
        private List<Tuple<string, string>> _deviceNames;
        private List<Tuple<string, string>> _recipeDevicesValues;
        private string _currRecipe;

        public DevicesDGVController(DataGridView dgv, Action onLock)
        {
            _mdl = new DevicesDGVModel(dgv, DataChangeHandler, ReloadHandler, onLock);
        }

        private void DataChangeHandler(List<Tuple<string, string>>[] shit)
        {
            _deviceNames = shit[0];
            _recipeDevicesValues = shit[1];
        }

        public void ChangeMode()
        {
            _mdl.ChangeMode();
        }

        public void HandleRecipeSelection(string text)
        {
            _currRecipe = text;
            ReloadHandler();
        }

        private void ReloadHandler()
        {
            _mdl.LoadData(_currRecipe);
        }

        public List<Tuple<string, string>> GetDevicesNames()
        {
            return _deviceNames;
        }

        public List<Tuple<string, string>> GetDevicesForRecipe()
        {
            return _recipeDevicesValues;
        }
        public void Clear()
        {
            _mdl.Clear();
        }

    }
}
