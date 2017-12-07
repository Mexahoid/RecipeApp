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
        private event Action<DataGridViewRowCollection> OnDataChange;
        private event Action OnButtonClick;
        private event Action OnCellClick;
        public int Count { get; set; }
        public RecipeNamesModel(DataGridView recipeNamesDgv, Action<DataGridViewRowCollection> action,
            Tuple<Action, Action> actions)
        {
            _dgv = recipeNamesDgv;
            _dgv.AutoGenerateColumns = true;
            OnDataChange += action;
            OnButtonClick += actions.Item1;
            OnCellClick += actions.Item2;
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

        public void AlterButtonRow(string text)
        {
            if (_dgv.Rows[_dgv.RowCount - 1].Cells[0].GetType() == typeof(DataGridViewButtonCell))
            {
                _dgv.Rows[_dgv.RowCount - 1].Cells[0] = new DataGridViewTextBoxCell
                {
                    Value = text
                };
            }
            else
            {
                var btn = new DataGridViewButtonCell
                {
                    Value = "Добавить новый рецепт",
                    FlatStyle = FlatStyle.System
                };
                _dgv.Rows[_dgv.RowCount - 1].Cells[0] = btn;
            }
        }

        public void 

        public void AddRow()
        {
            var btn = new DataGridViewButtonCell
            {
                Value = "Добавить новый рецепт",
                FlatStyle = FlatStyle.System
            };
            _dgv.Rows.Add();
            _dgv.Rows[_dgv.RowCount - 1].Cells[0] = btn;
                Count++;
            
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

        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((sender as DataGridView)?.Rows[e.RowIndex].Cells[e.ColumnIndex] is
                DataGridViewButtonCell)
            {

            }
            else
            {
                
            }
        }
    }
}
