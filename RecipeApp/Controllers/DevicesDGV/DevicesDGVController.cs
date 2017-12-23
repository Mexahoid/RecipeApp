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
        private List<string> _devicesCollection;
        private List<string> _oldData;
        private bool _inited;
        private string _currRecipe;

        public DevicesDGVController(DataGridView dgv, Action onLock)
        {
            _devicesCollection = new List<string>();
            _mdl = new DevicesDGVModel(dgv, DataChangeHandler, ReloadHandler, onLock, _devicesCollection);
            _data = new List<string>();
            _oldData = new List<string>();
        }

        private void DataChangeHandler(DataGridViewRowCollection rc)
        {
            _data.Clear();
            foreach (DataGridViewRow row in rc)
            {
                if(!_inited)
                    _oldData.Add(row.Cells[0].Value.ToString());
                if(row.Cells[0].Value != null)
                    _data.Add(row.Cells[0].Value.ToString());
            }
            _inited = true;
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
