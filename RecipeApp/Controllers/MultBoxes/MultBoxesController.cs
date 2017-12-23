using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DBLayer;
using RecipeApp.Models.MultBoxes;

namespace RecipeApp.Controllers.MultBoxes
{
    class MultBoxesController
    {
        private MultBoxesModel _mdl;
        private List<Tuple<string, string>> _data;
        private QueryFactory.Queries[] _queries;

        public MultBoxesController(ComboBox Cb, TextBox Tb, QueryFactory.Queries[] queries)
        {
            _mdl = new MultBoxesModel(Cb, Tb, 
                DataUpdateHandler, MouseClickHandler, KeyPressHandler);
            _data = new List<Tuple<string, string>>();
            _queries = queries;

            _mdl.LoadData(_data, queries[3]);
            AddSpecialRow();
        }


        public void GetKitchenByRecipe(string recipe)
        {
            DataTable dt = Connector.GetTable(
                _queries[0],
                new Tuple<string, string>("@Name", recipe));

            _mdl.SetName(dt.Rows[0].ItemArray[0].ToString());

        }


        private void AddSpecialRow()
        {
            _data.Add(new Tuple<string, string>(null, null));
            _mdl.AddSpecialRow();
        }

        public void ChangeLayout()
        {
            _mdl.ChangeLayout();
        }

        private void OnTextUpdate(int pos)
        {
            string name = RenameForm.Invoke(false);
            if(name != null)
                _data[pos] = new Tuple<string, string>(_data[pos].Item1, name);
        }

        private void OnKitchenAdd()
        {
            string name = RenameForm.Invoke(!_mdl.IsAdded);
            if(name != null)
                _data[_data.Count - 1] = new Tuple<string, string>("", name);
        }
        
        
        public void DataUpdateHandler(ComboBox.ObjectCollection items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(_data[i].Item1 != items[i].ToString())
                    _data[i] = new Tuple<string, string>(items[i].ToString(), _data[i].Item2);
            }
        }

        private void InsertData(int index)
        {
            Connector.GetTable(_queries[1],
                Tuple.Create("@Name", _data[index].Item1));
        }

        private void UpdateData(int index)
        {
            Connector.GetTable(_queries[2],
                Tuple.Create("@New", _data[index].Item1),
                Tuple.Create("@Old", _data[index].Item2));
        }

        public void Persist()
        {
            for (int i = 0; i < _data.Count - 1; i++)  // Т.к. всегда доп ряд будет
            {
                if (_data[i].Item2 != null && _data[i].Item1 != _data[i].Item2)
                {
                    UpdateData(i);
                    continue;
                }
                if(_data[i].Item2 == null)
                    InsertData(i);
            }
        }

        public void HandleRecipeSelection(string text)
        {
            DataTable dt = Connector.GetTable(_queries[0],
                new Tuple<string, string>("@Name", text));

            try
            {
                _mdl.SetName(dt.Rows[0].ItemArray[0].ToString());
            }
            catch
            {
                _mdl.SetName("");
            }

        }


        private void MouseClickHandler(int index, string text)
        {
            string ans;
            if (index < 0)
                return;
            if (text == Properties.Resources.AddNewKitchen)
            {
                ans = RenameForm.Invoke();
                _mdl.ChangeItem(index, ans);
                AddSpecialRow();
            }
        }

        private void KeyPressHandler(int index, string text, Keys key)
        {
            if (index < 0)
                return;
            if (key == Keys.E)
            {
                string ans = RenameForm.Invoke(false, text);
                _mdl.ChangeItem(index, ans);
            }
        }
    }
}
