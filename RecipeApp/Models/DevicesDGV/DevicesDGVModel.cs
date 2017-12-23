using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DBLayer;

namespace RecipeApp.Models.DevicesDGV
{
    class DevicesDGVModel
    {
        private readonly DataGridView _devices;
        private event Action<DataGridViewRowCollection> OnDataChange;
        private event Action OnReload;
        private readonly List<string> _devicesCollection;
        private readonly List<Tuple<string, string>> _deviceNames;
        private readonly List<Tuple<string, string>> _recipeDevicesValues;

        private bool _isEditing;

        public DevicesDGVModel(DataGridView dgv, 
            Action<DataGridViewRowCollection> onDataChange,
            Action onReload)
        {
            _devices = dgv;
            _devices.EditingControlShowing += DGV_EditingControlShowing;
            _devicesCollection = new List<string>();
            _deviceNames = new List<Tuple<string, string>>();
            _recipeDevicesValues = new List<Tuple<string, string>>();
            OnDataChange += onDataChange;
            OnReload += onReload;
            DataTable dt = Connector.GetTable(
                QueryFactory.Queries.SelectAllDevicesNames);
        
            foreach (DataRow dataRow in dt.Rows)
            {
                _deviceNames.Add(Tuple.Create(
                    dataRow.ItemArray[0].ToString(),
                    dataRow.ItemArray[0].ToString()));

                _devicesCollection.Add(dataRow.ItemArray[0].ToString());
            }
            _devicesCollection.Add(Properties.Resources.AddNewDevice);
        }

        private void AddNewDeviceToRecipe(string name)
        {
            _deviceNames.Add(Tuple.Create(name, ""));
            _devicesCollection.Add(name);
        }

        private void DeleteDeviceFromRecipe(int pos)
        {
            if (_isEditing)
            {
                
            }
        }

        private void EditRecipeFromRecipe(int pos, string newName)
        {
            if (_isEditing)
            {

            }
        }

        private void AddNewDeviceToDevices()
        {   // Исходим из того, что добавление отражается в _deviceNames
            string name = RenameForm.Invoke();
            if (name == "")
                return;

            _deviceNames.Add(Tuple.Create(name, ""));
            _devicesCollection[_devicesCollection.Count - 1] = name;  // Заменили последний
            _devicesCollection.Add(Properties.Resources.AddNewDevice);
        }

        private void EditDeviceInDevices(int pos)
        {
            string oldName = _devicesCollection[pos];
            string newName = RenameForm.Invoke(false, oldName);
            if (newName == "")
                return;

            _devicesCollection[pos] = newName;
            _deviceNames[pos] = Tuple.Create(newName, _deviceNames[pos].Item2);
        }

        public void LoadData(string name)
        {
            if (name == null)
                return;
            DataTable dt = Connector.GetTable(
                QueryFactory.Queries.SelectDevicesByRecipeName,
                Tuple.Create("@Name", name));
            _devices.Rows.Clear();
            _devices.Columns.Clear();
            _devices.ColumnCount = 1;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _devices.Rows.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            OnDataChange?.Invoke(_devices.Rows);
            if(_isEditing)
                ChangeToComboBoxes();
        }

        public void ChangeMode()
        {
            if (_isEditing)
            {
                ChangeToNormal();
            }
            else
            {
                ChangeToComboBoxes(); 
            }
            _isEditing = !_isEditing;
            _devices.ReadOnly = !_devices.ReadOnly;
        }

        private void ChangeToComboBoxes()
        {
            DataGridViewComboBoxColumn cc = new DataGridViewComboBoxColumn
            { Name = "Устройства"};
            List<string> items = new List<string>();
            foreach (DataGridViewRow row in _devices.Rows)
            {
                items.Add(row.Cells[0].Value.ToString());
            }
            _devices.Columns.Clear();
            _devices.Columns.Add(cc);

            foreach (string name in items)
            {
                _devices.Rows.Add();
                ((DataGridViewComboBoxCell) _devices.Rows[_devices.RowCount - 1].Cells[0]).DataSource = _devicesCollection;
                ((DataGridViewComboBoxCell) _devices.Rows[_devices.RowCount - 1].Cells[0]).Value = name;
            }
            _devices.Rows.Add();
            ((DataGridViewComboBoxCell)_devices.Rows[_devices.RowCount - 1].Cells[0]).DataSource = _devicesCollection;
        }

        private void ChangeToNormal()
        {
            OnReload?.Invoke();
        }

        void DGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl cb)
            {
                //cb.DropDownStyle = ComboBoxStyle.Simple;
                cb.KeyDown += (cbb, k) =>
                {
                    if (k.KeyData == Keys.E)
                    {
                        EditDevice((cbb as DataGridViewComboBoxEditingControl).SelectedIndex);
                    }
                };
            }
        }

        private void EditDevice(int pos)
        {
            pos = pos + 1;

        }

        private void DeleteDevice(int pos)
        {
            
        }
    }
}
