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
        private readonly DataGridView _dgv;
        private readonly ContextMenuStrip _cms;
        private DataGridViewCellEventArgs _mouseLocation;
        private bool _editingMode;

        private event Action<List<Tuple<string, string>>> OnDataChange;
        private event Action<int, string, MouseButtons> OnCellClick;
        private event Action OnChangeLock;
        private event Action<string> OnAdd;
        private event Action<string> OnDelete;
        private event Action<string, string> OnUpdate;

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


        private void AddHandler(object sender, EventArgs e)
        {
            string newName = RenameForm.Invoke();
            _dgv.Rows.Add(newName);
            _data.Add(Tuple.Create(newName, ""));
            OnDataChange?.Invoke(_data);
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
        }

        private void DeleteHandler(object sender, EventArgs e)
        {
            if (_mouseLocation.RowIndex < 0 || _mouseLocation.RowIndex > _dgv.Rows.Count - 1)
                return;
            string name = _dgv.Rows[_mouseLocation.RowIndex].Cells[0].Value.ToString();
            _dgv.Rows.RemoveAt(_mouseLocation.RowIndex);
            if (ConfirmationForm.Invoke(name) != DialogResult.OK)
                return;
            for (int i = 0; i < _data.Count; i++)
            {
                if (_data[i].Item1 != name)
                    continue;
                _data[i] = Tuple.Create("", _data[i].Item2);
                break;
            }
            OnDataChange?.Invoke(_data);
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
            //if(_editingMode)
            //    RemoveRow(_dgv.RowCount - 1);
            //else
            //    AddRow();
            OnChangeLock?.Invoke();
            _editingMode = !_editingMode;
        }

        public void SetRow(int index, string text)
        {
            _dgv.Rows[index].Cells[0].Value = text;
            OnDataChange?.Invoke(_data);
        }

        public void AddRow()
        {
            _dgv.Rows.Add();
            _dgv.Rows[_dgv.RowCount - 1].Cells[0].Value = Properties.Resources.AddNewRecipe;
        }

        public void RemoveRow(int index)
        {
            if (_dgv.RowCount != 0)
            {
                _dgv.Rows.RemoveAt(index);
            }
        }

        public void ReloadData()
        {
            _dgv.Rows.Clear();
            _dgv.ColumnCount = 1;
            DataTable dataTable = Connector.GetTable(QueryFactory.Queries.QuerySelectRecipeNames);
            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                _dgv.Rows.Add(dataTableRow.ItemArray[0]);
            }
            //_dgv.ClearSelection();
        }

        public void SelectNamedCell(string name)
        {
            if (name == "")
                return;
            for (int i = 0; i < _dgv.Rows.Count; i++)
            {
                if (_dgv.Rows[i].Cells[0].Value.ToString().ToLower() == name.ToLower())
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
