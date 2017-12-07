using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using System.Windows.Forms;
using RecipeApp.Models;

namespace RecipeApp.Controllers
{
    class RecipeNamesController
    {
        private bool _editing;

        private RecipeNamesModel _model;
        private RecipeAddController _adder;

        public RecipeNamesController(DataGridView recipeNames)
        {
            _model = new RecipeNamesModel(recipeNames);
            ShowRecipeNames();
        }

        public void InitAdder(Button accept, Button reject)
        {
            _adder = new RecipeAddController(accept, reject,
                new Tuple<Action, Action, Action>(
                    AddFillerRow, RemoveFillerRow, InsertRecipe));
        }

        public void InsertRecipe()
        {

        }

        public void ChangeMode()
        {
            _editing = !_editing;
            if (_editing)
            {
                AddFillerRow();
            }
            else
            {
                RemoveFillerRow();
            }
        }

        private void RemoveFillerRow()
        {
            _model.RemoveRow();
        }

        private void AddFillerRow()
        {
            var btn = new DataGridViewButtonCell
            {
                Value = "Добавить новый рецепт",
                FlatStyle = FlatStyle.System
            };
            _model.AddRow(btn);
        }

        public void DGVButton_Clicked(object sender, DataGridViewCellEventArgs e, Action<string> act)
        {
            if ((sender as DataGridView)?.Rows[e.RowIndex].Cells[e.ColumnIndex] is
                DataGridViewButtonCell)
            {
                string name = GetNewRecipeName();
                if (name != null)
                {
                    _model.SetButtonRow(name);
                    _adder.IsAdding = true;
                }
                else
                {
                    RemoveFillerRow();
                    AddFillerRow();
                }
            }
            else
            {
                if (_adder.IsAdding)  //Последний row только добавлен
                {
                    if (e.RowIndex == _model.Count - 1)
                    {
                        string name = GetNewRecipeName(false);
                        if (name != null)
                        {
                            _model.SetButtonRow(name);
                        }

                    }
                }
                else
                    act((sender as DataGridView)?.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        public void ShowRecipeNames()
        {
            _model.ClearData();
            _model.LoadData();
        }

        public string GetNewRecipeName(bool isAdding = true)
        {
            string name = "";
            var op = isAdding ? HelperForm.Operation.Add : HelperForm.Operation.Rename;
            using (var add = new HelperForm(op, text => name = text))
            {
                if (add.ShowDialog() == DialogResult.OK)
                {
                    return name;
                }
            }
            return null;
        }

        public void EditRecipeName()
        {

        }
    }
}
