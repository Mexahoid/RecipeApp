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
    class MultBoxesModel
    {
        private readonly ComboBox _kitCb;
        private readonly TextBox _kitTb;
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
            _kitTb = kitchTextBox;
            _kitCb = kitchens;
            OnDataChanged += onDataChange;
            OnKeyPress += onKeyPress;
            OnClick += onClick;
            _kitCb.SelectedIndexChanged += LB_Selected_Change;
            _kitCb.KeyDown += LB_Key_Down;
        }

        public void ChangeLayout()
        {
            if (_tbForeground)
                _kitCb.BringToFront();
            else
                _kitTb.BringToFront();
            _tbForeground = !_tbForeground;
        }

        public void LoadData(List<Tuple<string, string>> data, QueryFactory.Queries query)
        {
            _kitCb.Items.Clear();
            data.Clear();
            DataTable dt = Connector.GetTable(query);
            foreach (DataRow dataRow in dt.Rows)
            {
                _kitCb.Items.Add(dataRow.ItemArray[0]);
                data.Add(Tuple.Create(
                    dataRow.ItemArray[0].ToString(),
                    dataRow.ItemArray[0].ToString()));
            }
        }

        public void SetName(string kitchen)
        {
            _kitTb.Text = kitchen;
            if (kitchen == "")
                return;
            _kitCb.Text = kitchen;
            _kitCb.SelectedText = kitchen;
        }

        public void InvokeDataUpdate()
        {
            OnDataChanged?.Invoke(_kitCb.Items);
        }

        public void ChangeItem(int index, string newName)
        {
            _kitCb.Items[index] = newName;
            OnDataChanged?.Invoke(_kitCb.Items);
        }

        public void AddSpecialRow()
        {
            _kitCb.Items.Add(Properties.Resources.AddNewKitchen);
            OnDataChanged?.Invoke(_kitCb.Items);
        }

        public void LB_Selected_Change(object sender, EventArgs e)
        {
            string text = _kitCb.SelectedIndex < 0 ? "" : _kitCb.Items[_kitCb.SelectedIndex].ToString();
            OnClick?.Invoke(_kitCb.SelectedIndex, text);
        }

        public void LB_Key_Down(object sender, KeyEventArgs e)
        {
            string text = _kitCb.SelectedIndex < 0 ? "" : _kitCb.Items[_kitCb.SelectedIndex].ToString();
            OnKeyPress?.Invoke(_kitCb.SelectedIndex, text, e.KeyData);
        }
    }
}
