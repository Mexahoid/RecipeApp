using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DBLayer;
using RecipeApp.Forms;

namespace RecipeApp.Models.DevicesDGV
{
    class DevicesDGVModel
    {
        private readonly DataGridView _devices;
        private readonly ContextMenuStrip _cms;
        private DataGridViewCellEventArgs _mouseLocation;

        private event Action<DataGridViewRowCollection> OnDataChange;
        private event Action OnReload;
        private event Action OnLock;
        private readonly List<string> _devicesCollection;
        private readonly List<Tuple<string, string>> _deviceNames;
        private readonly List<Tuple<string, string>> _recipeDevicesValues;
        private int _rowIndex;

        private bool _isEditing;

        public DevicesDGVModel(DataGridView dgv,
            Action<DataGridViewRowCollection> onDataChange,
            Action onReload,
            Action onLock,
            List<string> deviceCollection)
        {
            _devices = dgv;
            _devices.CellMouseEnter += (sender, location) => _mouseLocation = location;

            ToolStripMenuItem editItem = new ToolStripMenuItem("Изменить");
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Удалить");
            ToolStripMenuItem addItem = new ToolStripMenuItem("Добавить");
            // добавляем элементы в меню
            _cms = new ContextMenuStrip
            {
                Text = "Меню",
                Items = { editItem, deleteItem, addItem }
            };

            editItem.Click += EditHandler;
            deleteItem.Click += DeleteHandler;
            addItem.Click += AddHandler;



            OnLock += onLock;
            _devices.EditingControlShowing += DGV_EditingControlShowing;
            _devices.CellMouseClick += DGV_MouseClick;
            _devicesCollection = deviceCollection;
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
        }

        private void AddHandler(object sender, EventArgs e)
        {
            var answer = DevicesForm.Invoke(_deviceNames, "Отсутствует");
            _deviceNames.Clear();
            foreach (var tuple in answer.Item1)
            {
                _deviceNames.Add(tuple);
            }

        }

        private void DeleteHandler(object sender, EventArgs e)
        {

        }

        private void EditHandler(object sender, EventArgs e)
        {

        }







        private void DGV_MouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _rowIndex = e.RowIndex;
            if (e.Button == MouseButtons.Right && _isEditing)
            {
                DeleteDeviceFromRecipe(e.RowIndex);
            }
            if (e.Button == MouseButtons.Left && _isEditing)
            {
                if (_devices.Rows[_rowIndex].Cells[0].Value == null)
                {
                    ((DataGridViewComboBoxCell) _devices.Rows[_rowIndex].Cells[0]).Value =
                        Properties.Resources.AddNewDevice;
                    _devices.Rows.Add();
                    ((DataGridViewComboBoxCell) _devices.Rows[_rowIndex + 1].Cells[0]).DataSource = _devicesCollection;
                }
            }
        }

        private void AddNewDeviceToRecipe(string name)
        {
            _recipeDevicesValues.Add(Tuple.Create(name, ""));
            ((DataGridViewComboBoxCell)_devices.Rows[_rowIndex].Cells[0]).Value =
                name;
        }

        private void DeleteDeviceFromRecipe(int pos)
        {
            if (_isEditing)
            {
                _recipeDevicesValues[pos] = Tuple.Create("", _recipeDevicesValues[pos].Item2);
                _devices.Rows.RemoveAt(pos);
                OnDataChange?.Invoke(_devices.Rows);
                OnLock?.Invoke();
            }
        }

        private void EditDeviceFromRecipe(int pos, string newName)
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
                string text = dt.Rows[i].ItemArray[0].ToString();
                _devices.Rows.Add(text);
                _recipeDevicesValues.Add(Tuple.Create(text, text));
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
                if(row.Cells[0].Value != null)// && 
                    //row.Cells[0].Value.ToString() != Properties.Resources.AddNewDevice)
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
                void Act(object cbb, KeyEventArgs k)
                {
                    if (k.KeyData == Keys.E)
                    {
                        EditDeviceInDevices((cbb as DataGridViewComboBoxEditingControl).SelectedIndex);
                    }
                }

                void Eh(object cbb, EventArgs ev)
                {
                    HandleDeviceSelection((cbb as DataGridViewComboBoxEditingControl).SelectedIndex);
                }

                cb.KeyDown -= Act;
                cb.SelectedIndexChanged -= Eh;
                cb.KeyDown += Act;
                cb.SelectedIndexChanged += Eh;
            }
        }

        private void HandleDeviceSelection(int pos)
        {
            if (pos == _devicesCollection.Count - 1)
            {
                AddNewDeviceToDevices();
                ChangeToComboBoxes();
                ((DataGridViewComboBoxCell) _devices.Rows[_rowIndex].Cells[0]).Value =
                    _devicesCollection[_devicesCollection.Count - 2];
            }
            else
            {
                if (((DataGridViewComboBoxCell) _devices.Rows[_rowIndex].Cells[0]).Value.ToString() ==
                    Properties.Resources.AddNewDevice)
                {
                    if (_rowIndex == _recipeDevicesValues.Count && pos > -1)
                    {
                        AddNewDeviceToRecipe(_devicesCollection[pos]);
                    }
                }
            }
            OnDataChange?.Invoke(_devices.Rows);
            OnLock?.Invoke();
        }
    }
}
