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

        private readonly RecipeNamesModel _model;
        private event Action OnChangeLock;
        private List<Tuple<string, string>> _data;

        public RecipeNamesController(DataGridView recipeNames, Action onChangeAction)
        {
            _model = new RecipeNamesModel(recipeNames, OnDataChange);
            OnChangeLock += onChangeAction;
            //recipeNames.CellContentClick += DGVButton_Clicked;
            ShowRecipeNames();
        }

        private void InsertRecipe()
        {

        }

        private void UpdateRecipe()
        {

        }

        private void DeleteRecipe()
        {
            
        }

        private void OnDataChange(DataGridViewRowCollection rows)
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
            _model.AddRow();
        }

        public void DGVButton_Clicked(object sender, DataGridViewCellEventArgs e, Action<string> act)
        {
            if ((sender as DataGridView)?.Rows[e.RowIndex].Cells[e.ColumnIndex] is
                DataGridViewButtonCell)
            {
                string name = HelperForm.Invoke();
                if (name != null)
                {
                    _model.SetButtonRow(name);
                    OnChangeLock?.Invoke();
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
                        string name = HelperForm.Invoke(false);
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

        private void ProcessButtonClick()
        {
            string name = HelperForm.Invoke();
            if (name != null)
            {
                _model.SetButtonRow(name);
                OnChangeLock?.Invoke();
            }
            else
            {
                RemoveFillerRow();
                AddFillerRow();
            }
        }

        private void ProcessCellClick()
        {
            
        }

        public void ShowRecipeNames()
        {
            _model.ClearData();
            _model.LoadData();
        }

    }
}
