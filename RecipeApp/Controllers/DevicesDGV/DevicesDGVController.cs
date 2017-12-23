using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RecipeApp.Models.DevicesDGV;

namespace RecipeApp.Controllers.DevicesDGV
{
    class DevicesDGVController
    {
        private DevicesDGVModel _mdl;
        private List<string> _data;
        private string _currRecipe;

        public DevicesDGVController(DataGridView dgv)
        {
            _mdl = new DevicesDGVModel(dgv, DataChangeHandler, ReloadHandler);
            _data = new List<string>();
        }

        private void DataChangeHandler(DataGridViewRowCollection rc)
        {
            _data.Clear();
            foreach (DataGridViewRow row in rc)
            {
                _data.Add(row.Cells[0].Value.ToString());
            }
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

    }
}
