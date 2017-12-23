using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DBLayer;
using RecipeApp.Forms;
using DataStructure = System.Collections.Generic.List<System.Tuple<System.Tuple<string, string>, System.Tuple<string, string>, System.Tuple<string, string>>>;

namespace RecipeApp.Models.IngredsDGV
{
    class IngredsDGVModel
    {
        private DataStructure _data;
        private DataGridView _dgv;
        private event Action OnReload;
        private event Action OnChangeLock;
        private event Action OnLock;
        private DataGridViewCellEventArgs _mouseLocation;
        private event Action<DataStructure> OnDataChange;
        private List<Tuple<string, string>> _names;
        public IngredsDGVModel(DataGridView dgv,
            Action onReload,
            Action<DataStructure> onChange,
            Action onLock)
        {
            _dgv = dgv;
            OnReload += onReload;
            OnDataChange += onChange;
            OnLock += onLock;
            InitStructures();
            InitCoMeSt();
        }

        private void InitStructures()
        {
            _data = new DataStructure();
            _names = new List<Tuple<string, string>>();

            DataTable dt = Connector.GetTable(QueryFactory.Queries.SelectAllIngredNames);

            foreach (DataRow row in dt.Rows)
            {
                _names.Add(Tuple.Create(
                    row.ItemArray[0].ToString(),
                    row.ItemArray[0].ToString()));
            }
        }

        private void InitCoMeSt()
        {
            _dgv.CellMouseEnter += (sender, location) => _mouseLocation = location;

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
            _dgv.Enabled = false;
            _dgv.ContextMenuStrip = cms;
        }


        private void AddHandler(object sender, EventArgs e)
        {
            var lst = InvokeIngredEditor(new List<string>
            {
                "Ничто", "Нисколько", "Никакие"
            });

            _dgv.Rows.Add(lst[0], lst[1], lst[2]);
            _data.Add(Tuple.Create(
                Tuple.Create(lst[0], ""),
                Tuple.Create(lst[1], ""),
                Tuple.Create(lst[2], "")));
            OnDataChange?.Invoke(_data);
            OnLock?.Invoke();
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
                if (_data[i].Item1.Item1 != name)
                    continue;
                _data[i] = Tuple.Create(
                    Tuple.Create("", _data[i].Item1.Item2),
                    Tuple.Create("", _data[i].Item2.Item2),
                    Tuple.Create("", _data[i].Item3.Item2));
                break;
            }
            OnDataChange?.Invoke(_data);
            OnLock?.Invoke();
        }

        private void EditHandler(object sender, EventArgs e)
        {
            if (_mouseLocation.RowIndex < 0 || _mouseLocation.RowIndex > _dgv.Rows.Count - 1)
                return;
            string oldName = _dgv.Rows[_mouseLocation.RowIndex].Cells[0].Value.ToString();
            var lst = InvokeIngredEditor(new List<string>
            {
                _dgv.Rows[_mouseLocation.RowIndex].Cells[0].Value.ToString(),
                _dgv.Rows[_mouseLocation.RowIndex].Cells[1].Value.ToString(),
                _dgv.Rows[_mouseLocation.RowIndex].Cells[2].Value.ToString()
            });

            if (string.IsNullOrEmpty(lst[0]) ||
                string.IsNullOrEmpty(lst[1]) || 
                string.IsNullOrEmpty(lst[2]))
                return;

            for (int i = 0; i < 3; i++)
                _dgv.Rows[_mouseLocation.RowIndex].Cells[i].Value = lst[i];

            for (int i = 0; i < _data.Count; i++)
            {
                if (_data[i].Item1.Item1 != oldName)
                    continue;

                _data[i] = Tuple.Create(
                    Tuple.Create(lst[0], _data[i].Item1.Item2),
                    Tuple.Create(lst[1], _data[i].Item2.Item2),
                    Tuple.Create(lst[2], _data[i].Item3.Item2));
                break;
            }
            OnDataChange?.Invoke(_data);
            OnLock?.Invoke();
        }


        private List<string> InvokeIngredEditor(List<string> dat)
        {
            var answer = IngredsForm.Invoke(Tuple.Create(_names, dat));
            if (answer == null)
                return null;
            _names = new List<Tuple<string, string>>();
            foreach (var tuple in answer.Item1)
            {
                _names.Add(tuple);
            }
            return answer.Item2;
        }


        public void LoadData(string recipeName)
        {
            DataTable dt = Connector.GetTable(QueryFactory.Queries.SelectIngredsByRecipeName,
                Tuple.Create("@Name", recipeName));
            _dgv.Rows.Clear();
            _dgv.ColumnCount = 3;

            _data = new DataStructure();
            foreach (DataRow row in dt.Rows)
            {
                _data.Add(Tuple.Create(
                    Tuple.Create(row.ItemArray[0].ToString(), row.ItemArray[0].ToString()),
                    Tuple.Create(row.ItemArray[1].ToString(), row.ItemArray[1].ToString()),
                    Tuple.Create(row.ItemArray[2].ToString(), row.ItemArray[2].ToString())));

                _dgv.Rows.Add(
                    row.ItemArray[0].ToString(),
                    row.ItemArray[1].ToString(),
                    row.ItemArray[2].ToString());
            }
            OnDataChange?.Invoke(_data);
        }

        public void ChangeMode()
        {
            OnChangeLock?.Invoke();
            _dgv.Enabled = !_dgv.Enabled;
        }
    }
}
