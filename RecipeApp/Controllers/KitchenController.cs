using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;
using RecipeApp.Models;

namespace RecipeApp.Controllers
{
    class KitchenController
    {
        private KitchensModel _mdl;
        private List<int> _deletingRows;
        private List<int> _changingRows;
        private List<Tuple<string, string>> _data;

        public KitchenController(ComboBox kitchens, TextBox kitchensTb)
        {
            _mdl = new KitchensModel(kitchens, kitchensTb, 
                new Tuple<Action<int>, Action, Action<ComboBox.ObjectCollection>>(
                    OnTextUpdate, OnKitchenAdd, OnDataUpdate));

            DataTable dt = Connector.GetTable(QueryFactory.Queries.SelectAllKitchens);
            _data = new List<Tuple<string, string>>();

            foreach (DataRow row in dt.Rows)
            {
                _data.Add(new Tuple<string, string>
                    (row.ItemArray[0].ToString(), row.ItemArray[0].ToString()));
            }
            _data.Add(new Tuple<string, string>(
                Properties.Resources.AddNewKitchen, 
                Properties.Resources.AddNewKitchen));   // Это последний ряд, если надо добавить
            _mdl.InvokeDataUpdate();
        }


        public void GetKitchenByRecipe(string recipe)
        {
            DataTable dt = Connector.GetTable(
                QueryFactory.Queries.QueryRedactorSelectKitchens,
                new Tuple<string, string>("@Name", recipe));

            _mdl.ChangeKitchen(dt.Rows[0].ItemArray[0].ToString());

        }

        public void ChangeLayout()
        {
            _mdl.ChangeLayout();
        }

        private void OnTextUpdate(int pos)
        {
            string name = HelperForm.Invoke(false);
            if(name != null)
                _data[pos] = new Tuple<string, string>(_data[pos].Item1, name);
        }

        private void OnKitchenAdd()
        {
            string name = HelperForm.Invoke(!_mdl.IsAdded);
            if(name != null)
                _data[_data.Count - 1] = new Tuple<string, string>("", name);
        }
        
        
        public void OnDataUpdate(ComboBox.ObjectCollection items)
        {
            items.Clear();
            foreach (var tuple in _data)
            {
                items.Add(tuple.Item2);
            }
        }
        
        public void ApplyChanges()
        {
            var strings = new List<string>(_mdl.GetItems());
            DataTable dt = Connector.GetTable(QueryFactory.Queries.SelectAllKitchens);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string row = dt.Rows[i].ItemArray[0].ToString();
                if (strings[i] != row)
                {
                    Connector.GetTable(QueryFactory.Queries.UpdateOneKitchen,
                        new Tuple<string, string>("@New", strings[i]),
                        new Tuple<string, string>("@Old", row));
                }
            }
            if (strings.Count != 1) ;
        }
    }
}
