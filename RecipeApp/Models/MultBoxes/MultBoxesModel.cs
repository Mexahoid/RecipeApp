using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DBLayer;

namespace RecipeApp.Models.MultBoxes
{
    class MultBoxesModel
    {
        private readonly ComboBox _combo;
        private readonly TextBox _textb;
        private bool _tbForeground = true;
        private event Action<int, string> OnClick;
        private event Action<int, string, Keys> OnKeyPress;

        private event Action<ComboBox.ObjectCollection> OnDataChanged;

        public bool IsAdded { get; set; }

        public MultBoxesModel(ComboBox kitchens, TextBox kitchTextBox,
            Action<ComboBox.ObjectCollection> onDataChange,
            Action<int, string> onClick,
            Action<int, string, Keys> onKeyPress)
        {
            _textb = kitchTextBox;
            _combo = kitchens;
            OnDataChanged += onDataChange;
            OnKeyPress += onKeyPress;
            OnClick += onClick;
            _combo.SelectedIndexChanged += LB_Selected_Change;
            _combo.KeyDown += LB_Key_Down;
        }

        public void ChangeLayout()
        {
            if (_tbForeground)
                _combo.BringToFront();
            else
                _textb.BringToFront();
            _tbForeground = !_tbForeground;
        }

        public void LoadData(List<Tuple<string, string>> data, QueryFactory.Queries query)
        {
            _combo.Items.Clear();
            data.Clear();
            DataTable dt = Connector.GetTable(query);
            foreach (DataRow dataRow in dt.Rows)
            {
                _combo.Items.Add(dataRow.ItemArray[0]);
                data.Add(Tuple.Create(
                    dataRow.ItemArray[0].ToString(),
                    dataRow.ItemArray[0].ToString()));
            }
        }

        public void SetName(string kitchen)
        {
            _textb.Text = kitchen;
            _combo.Text = kitchen;// == "" ? Properties.Resources.AddNewKitchen : kitchen;
            _combo.SelectedText = kitchen;
        }

        public void InvokeDataUpdate()
        {
            OnDataChanged?.Invoke(_combo.Items);
        }

        public void ChangeItem(int index, string newName)
        {
            _combo.Items[index] = newName;
            OnDataChanged?.Invoke(_combo.Items);
        }

        public void AddSpecialRow()
        {
            _combo.Items.Add(Properties.Resources.AddNewKitchen);
            OnDataChanged?.Invoke(_combo.Items);
        }

        public void LB_Selected_Change(object sender, EventArgs e)
        {
            string text = _combo.SelectedIndex < 0 ? "" : _combo.Items[_combo.SelectedIndex].ToString();
            OnClick?.Invoke(_combo.SelectedIndex, text);
        }

        public void LB_Key_Down(object sender, KeyEventArgs e)
        {
            string text = _combo.SelectedIndex < 0 ? "" : _combo.Items[_combo.SelectedIndex].ToString();
            OnKeyPress?.Invoke(_combo.SelectedIndex, text, e.KeyData);
        }

        public string GetData()
        {
            return _combo.Text;
        }
    }
}
