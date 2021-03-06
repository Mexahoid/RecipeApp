﻿using System;
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
        private DataGridViewCellEventArgs _mouseLocation;

        private event Action<List<Tuple<string, string>>[]> OnDataChange;
        private event Action OnReload;
        private event Action OnLock;
        private event Action OnChangeLock;
        private List<Tuple<string, string>> _deviceNames;
        private readonly List<Tuple<string, string>> _recipeDevicesValues;

        private bool _isEditing;

        public DevicesDGVModel(DataGridView dgv,
            Action<List<Tuple<string, string>>[]> onDataChange,
            Action onReload,
            Action onLock)
        {
            _devices = dgv;
            InitCoMeSt();
            OnLock += onLock;

            _recipeDevicesValues = new List<Tuple<string, string>>();
            OnDataChange += onDataChange;
            OnReload += onReload;

            InitAllDeviceNames();
        }

        private void InitAllDeviceNames()
        {
            _deviceNames = new List<Tuple<string, string>>();
            DataTable dt = Connector.GetTable(
                QueryFactory.Queries.SelectAllDevicesNames);

            foreach (DataRow dataRow in dt.Rows)
            {
                _deviceNames.Add(Tuple.Create(
                    dataRow.ItemArray[0].ToString(),
                    dataRow.ItemArray[0].ToString()));
            }
        }

        private void InitCoMeSt()
        {
            _devices.CellMouseEnter += (sender, location) => _mouseLocation = location;

            ToolStripMenuItem editItem = new ToolStripMenuItem("Изменить");
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Удалить");
            ToolStripMenuItem addItem = new ToolStripMenuItem("Добавить");
            // добавляем элементы в меню
            ContextMenuStrip cms = new ContextMenuStrip
            {
                Text = "Меню",
                Items = { editItem, deleteItem, addItem }
            };
            OnChangeLock += () => cms.Enabled = !cms.Enabled;
            cms.Enabled = false;
            editItem.Click += EditHandler;
            deleteItem.Click += DeleteHandler;
            addItem.Click += AddHandler;

            _devices.ContextMenuStrip = cms;
            _devices.Enabled = false;
        }


        private void AddHandler(object sender, EventArgs e)
        {
            string newName = InvokeDeviceEditor("Отсутствует");

            _devices.Rows.Add(newName);
            _recipeDevicesValues.Add(Tuple.Create(newName, ""));
            OnDataChange?.Invoke(new[] { _deviceNames, _recipeDevicesValues });
            OnLock?.Invoke();
        }

        private void DeleteHandler(object sender, EventArgs e)
        {
            if (_mouseLocation.RowIndex < 0 || _mouseLocation.RowIndex > _devices.Rows.Count - 1)
                return;
            string name = _devices.Rows[_mouseLocation.RowIndex].Cells[0].Value.ToString();
            if (ConfirmationForm.Invoke(name) != DialogResult.OK)
                return;

            _devices.Rows.RemoveAt(_mouseLocation.RowIndex);
            for (int i = 0; i < _recipeDevicesValues.Count; i++)
            {
                if (_recipeDevicesValues[i].Item1 != name)
                    continue;
                _recipeDevicesValues[i] =
                    Tuple.Create("", _recipeDevicesValues[i].Item2);
                break;
            }
            OnDataChange?.Invoke(new[] { _deviceNames, _recipeDevicesValues });
            OnLock?.Invoke();
        }

        private void EditHandler(object sender, EventArgs e)
        {
            if (_mouseLocation.RowIndex < 0 || _mouseLocation.RowIndex > _devices.Rows.Count - 1)
                return;
            string oldName = _devices.Rows[_mouseLocation.RowIndex].Cells[0].Value.ToString();
            string newName = InvokeDeviceEditor(oldName);
            if (string.IsNullOrEmpty(newName))
                return;
            _devices.Rows[_mouseLocation.RowIndex].Cells[0].Value =
                newName;
            for (int i = 0; i < _recipeDevicesValues.Count; i++)
            {
                if (_recipeDevicesValues[i].Item1 != oldName)
                    continue;
                _recipeDevicesValues[i] =
                    Tuple.Create(newName, _recipeDevicesValues[i].Item2);
                break;
            }
            OnDataChange?.Invoke(new[] { _deviceNames, _recipeDevicesValues });
            OnLock?.Invoke();
        }

        private string InvokeDeviceEditor(string name)
        {
            var answer = DevicesForm.Invoke(_deviceNames, name);
            if (answer == null)
                return null;
            _deviceNames = new List<Tuple<string, string>>();
            foreach (var tuple in answer.Item1)
            {
                _deviceNames.Add(tuple);
            }
            return answer.Item2;
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
            _recipeDevicesValues.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string text = dt.Rows[i].ItemArray[0].ToString();
                _devices.Rows.Add(text);
                _recipeDevicesValues.Add(Tuple.Create(text, text));
            }
            OnDataChange?.Invoke(new[] {_deviceNames, _recipeDevicesValues});
        }

        public void ChangeMode()
        {
            if (_isEditing)
            {
                ChangeToNormal();
            }
            OnChangeLock?.Invoke();
            _devices.Enabled = !_devices.Enabled;
        }
        

        private void ChangeToNormal()
        {
            OnReload?.Invoke();
        }

        public void Clear()
        {
            InitAllDeviceNames();
            _devices.Rows.Clear();
            _devices.Columns.Clear();
        }
    }
}
