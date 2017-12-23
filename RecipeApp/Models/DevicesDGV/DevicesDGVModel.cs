using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private bool _isEditing;

        public DevicesDGVModel(DataGridView dgv, 
            Action<DataGridViewRowCollection> onDataChange,
            Action onReload)
        {
            _devices = dgv;
            _devicesCollection = new List<string>();
            OnDataChange += onDataChange;
            OnReload += onReload;
            DataTable dt = Connector.GetTable(
                QueryFactory.Queries.SelectAllDevicesNames);
        
            foreach (DataRow dataRow in dt.Rows)
            {
                _devicesCollection.Add(dataRow.ItemArray[0].ToString());
            }
        }

        public void LoadData(string name)
        {
            DataTable dt = Connector.GetTable(
                QueryFactory.Queries.SelectDevicesByRecipeName,
                Tuple.Create("@Name", name));
            _devices.Rows.Clear();
            _devices.Columns.Clear();
            _devices.ColumnCount = 1;

            foreach (DataRow dataRow in dt.Rows)
            {
                _devices.Rows.Add(dataRow.ItemArray[0].ToString());
            }
            OnDataChange?.Invoke(_devices.Rows);
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
                ((DataGridViewComboBoxCell)_devices.Rows[_devices.RowCount - 1].Cells[0]).Value = name;
                
            }
        }

        private void ChangeToNormal()
        {
            OnReload?.Invoke();
        }
    }
}
