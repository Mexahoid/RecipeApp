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
    class KitchensModel
    {
        private readonly ComboBox _kitCb;
        private readonly TextBox _kitTb;
        private bool _tbForeground = true;
        private event Action<int> OnUpdate;
        private event Action OnInsert;

        private event Action<ComboBox.ObjectCollection> OnDataChanged;

        public bool IsAdded { get; set; }

        public KitchensModel(ComboBox kitchens, TextBox kitchTextBox,
            Tuple<
                Action<int>,
                Action,
                Action<ComboBox.ObjectCollection>> actions)
        {
            _kitTb = kitchTextBox;
            _kitCb = kitchens;
            OnUpdate += actions.Item1;
            OnInsert += actions.Item2;
            OnDataChanged += actions.Item3;
            _kitCb.SelectedIndexChanged += _kitCb_SelectedIndexChanged;
            _kitCb.KeyDown += _kitCb_KeyDown;
        }

        private void _kitCb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 18)
                return;

            OnUpdate?.Invoke(_kitCb.SelectedIndex);
            InvokeDataUpdate();
        }
        private void _kitCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsAdded || _kitCb.SelectedIndex != _kitCb.Items.Count - 1)
                return;
            IsAdded = true;
            OnInsert?.Invoke();
            InvokeDataUpdate();
        }

        public void ChangeLayout()
        {
            if (_tbForeground)
                _kitCb.BringToFront();
            else
                _kitTb.BringToFront();
            _tbForeground = !_tbForeground;
        }

        public void LoadData()
        {
            _kitCb.Items.Clear();
            DataTable dt = Connector.GetTable(
                QueryFactory.Queries.QueryRedactorSelectKitchens);
            foreach (DataRow dataRow in dt.Rows)
            {
                _kitCb.Items.Add(dataRow.ItemArray[0]);
            }
            _kitCb.Items.Add(Properties.Resources.AddNewKitchen);
        }

        public void ChangeKitchen(string kitchen)
        {
            _kitTb.Text = kitchen;
            _kitCb.Text = kitchen;
        }

        public void InvokeDataUpdate()
        {
            OnDataChanged?.Invoke(_kitCb.Items);
        }

        public IEnumerable<string> GetItems()
        {
            foreach (object kitCbItem in _kitCb.Items)
            {
                yield return kitCbItem.ToString();
            }
        }
    }
}
