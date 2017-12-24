using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DBLayer;
using RecipeApp.Forms;

namespace RecipeApp.Models.RecipeNames
{
    class RecipeNamesModel
    {
        public enum State
        {
            Null,
            Edited,
            Deleted,
            Added
        }


        private State _state = State.Null;
        private readonly DataGridView _dgv;
        private readonly ContextMenuStrip _cms;
        private DataGridViewCellEventArgs _mouseLocation;
        private bool _editingMode;

        private event Action<List<Tuple<string, string>>> OnDataChange;
        private event Action<int, string, MouseButtons> OnCellClick;
        private event Action OnChangeLock;
        

        private List<Tuple<string, string>> _data;

        public RecipeNamesModel(DataGridView recipeNamesDgv, 
            Action<List<Tuple<string, string>>> action, 
            Action<int, string, MouseButtons> clicker)
        {
            _dgv = recipeNamesDgv;
            _dgv.AutoGenerateColumns = true;

            OnDataChange += action;
            OnCellClick += clicker;

            _dgv.CellMouseClick += DGV_Cell_Mouse_Click;
            _dgv.CurrentCell = null;
            InitCoMeSt();
        }
        private void InitCoMeSt()
        {
            _dgv.CellMouseEnter += (sender, location) => _mouseLocation = location;

            ToolStripMenuItem editItem = new ToolStripMenuItem("Переименовать");
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

            _dgv.ContextMenuStrip = cms;

        }

        public State GetState() => _state;

        private void AddHandler(object sender, EventArgs e)
        {
            string newName = RenameForm.Invoke();
            _dgv.Rows.Add(newName);
            _data.Add(Tuple.Create(newName, ""));
            OnDataChange?.Invoke(_data);
            _state = State.Added;
        }

        private void EditHandler(object sender, EventArgs e)
        {
            if (_mouseLocation.RowIndex < 0 || _mouseLocation.RowIndex > _dgv.Rows.Count - 1)
                return;
            string name = _dgv.Rows[_mouseLocation.RowIndex].Cells[0].Value.ToString();
            string newName = RenameForm.Invoke(false, name);
            _dgv.Rows[_mouseLocation.RowIndex].Cells[0].Value = newName;

            for (int i = 0; i < _data.Count; i++)
            {
                if (_data[i].Item1 != name)
                    continue;
                _data[i] = Tuple.Create(newName, _data[i].Item2);
                break;
            }
            OnDataChange?.Invoke(_data);
            _state = State.Edited;
        }

        private void DeleteHandler(object sender, EventArgs e)
        {
            if (_mouseLocation.RowIndex < 0 || _mouseLocation.RowIndex > _dgv.Rows.Count - 1)
                return;
            string name = _dgv.Rows[_mouseLocation.RowIndex].Cells[0].Value.ToString();
            if (ConfirmationForm.Invoke(name) != DialogResult.OK)
                return;
            _dgv.Rows.RemoveAt(_mouseLocation.RowIndex);
            for (int i = 0; i < _data.Count; i++)
            {
                if (_data[i].Item1 != name)
                    continue;
                _data[i] = Tuple.Create("", _data[i].Item2);
                break;
            }
            OnDataChange?.Invoke(_data);
            _state = State.Deleted;
        }
        
        public void FillDataList(List<Tuple<string, string>> data)
        {
            data.Clear();
            data.AddRange(
                from DataGridViewRow row 
                in _dgv.Rows
                select 
                new Tuple<string, string>(row.Cells[0].Value.ToString(), row.Cells[0].Value.ToString()));
        }

        public void ChangeMode()
        {
            OnChangeLock?.Invoke();
            _editingMode = !_editingMode;
        }
        

        public void ReloadData()
        {
            _dgv.Rows.Clear();
            _dgv.ColumnCount = 1;
            _data = new List<Tuple<string, string>>();
            DataTable dataTable = Connector.GetTable(QueryFactory.Queries.QuerySelectRecipeNames);
            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                _dgv.Rows.Add(dataTableRow.ItemArray[0]);
                _data.Add(Tuple.Create(dataTableRow.ItemArray[0].ToString(), dataTableRow.ItemArray[0].ToString()));
            }
            _state = State.Null;
        }

        public void SelectNamedCell(string name)
        {
            if (name == "")
                return;
            for (int i = 0; i < _dgv.Rows.Count; i++)
            {
                if (_dgv.Rows[i].Cells[0].Value?.ToString().ToLower() == name?.ToLower())
                {
                    DGV_Cell_Mouse_Click(_dgv, 
                        new DataGridViewCellMouseEventArgs(0, i, 0, 0,
                            new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)));
                    _dgv.CurrentCell = _dgv.Rows[i].Cells[0];
                    break;
                }
            }
        }

        private void DGV_Cell_Mouse_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            OnCellClick?.Invoke(
                e.RowIndex, 
                (sender as DataGridView)?.Rows[e.RowIndex].Cells[0].Value.ToString(),
                e.Button);
            
        }

        public void Lock() => _dgv.Enabled = false;

        public void Unlock() => _dgv.Enabled = true;

    }
}
