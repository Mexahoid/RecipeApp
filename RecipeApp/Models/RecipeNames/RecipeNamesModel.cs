using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DBLayer;

namespace RecipeApp.Models.RecipeNames
{
    class RecipeNamesModel
    {
        private readonly DataGridView _dgv;
        private readonly ContextMenuStrip _cms;
        private bool _editingMode;

        private event Action<DataGridViewRowCollection> OnDataChange;
        private event Action<int, string, MouseButtons> OnCellClick;
        private DataGridViewCellEventArgs mouseLocation;

        public RecipeNamesModel(DataGridView recipeNamesDgv, 
            Action<DataGridViewRowCollection> action, 
            Action<int, string, MouseButtons> clicker)
        {
            _dgv = recipeNamesDgv;
            _dgv.AutoGenerateColumns = true;

            OnDataChange += action;
            OnCellClick += clicker;

            _dgv.CellMouseClick += DGV_Cell_Mouse_Click;
            _dgv.CellMouseEnter += (sender, location) => mouseLocation = location;
            _dgv.CurrentCell = null;

            ToolStripMenuItem editItem = new ToolStripMenuItem("Изменить");
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Удалить");
            // добавляем элементы в меню
            _cms = new ContextMenuStrip
            {
                Text = "Меню",
                Items = { editItem, deleteItem }
            };
            _dgv.ContextMenuStrip = _cms;
            editItem.Click += EditClickHandler;
            deleteItem.Click += DeleteClickHandler;
        }
        
        private void EditClickHandler(object sender, EventArgs e)
        {
            MessageBox.Show(_dgv.Rows[mouseLocation.RowIndex].Cells[0].Value.ToString());
        }

        private void DeleteClickHandler(object sender, EventArgs e)
        {

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
            if(_editingMode)
                RemoveRow(_dgv.RowCount - 1);
            else
                AddRow();
            _editingMode = !_editingMode;
        }

        public void SetRow(int index, string text)
        {
            _dgv.Rows[index].Cells[0].Value = text;
            OnDataChange?.Invoke(_dgv.Rows);
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
            _dgv.ClearSelection();
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
