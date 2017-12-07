using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;

namespace RecipeApp.Models
{
    class RecipeNamesModel
    {
        private DataGridView _dgv;
        private DataTable _dataTable;
        public int Count { get; set; }
        public RecipeNamesModel(DataGridView recipeNamesDgv)
        {
            _dgv = recipeNamesDgv;
            _dgv.AutoGenerateColumns = true;
        }

        public void ClearData()
        {
            _dgv.Rows.Clear();
            Count = 0;
        }

        public void SetButtonRow(string row)
        {
            _dgv.Rows[_dgv.RowCount - 1].Cells[0] = new DataGridViewTextBoxCell
            {
                Value = row
            };
        }

        public void AddRow(object o)
        {
            if (o is DataGridViewButtonCell btn)
            {
                _dgv.Rows.Add();
                _dgv.Rows[_dgv.RowCount - 1].Cells[0] = btn;
                Count++;
            }
            //_dataTable.Rows.Add();
            //_dataTable.Rows[_dataTable.Rows.Count - 1].ItemArray[0] = o;
        }

        public void RemoveRow()
        {
            if (_dgv.RowCount != 0)
            {
                _dgv.Rows.RemoveAt(_dgv.RowCount - 1);
                Count--;
            }
        }

        public void LoadData()
        {
            ClearData();
            _dgv.ColumnCount = 1;
            _dataTable = Connector.GetTable(QueryFactory.Queries.QuerySelectRecipeNames);
            foreach (DataRow dataTableRow in _dataTable.Rows)
            {
                _dgv.Rows.Add(dataTableRow.ItemArray[0]);
                Count++;
            }
        }
    }
}
