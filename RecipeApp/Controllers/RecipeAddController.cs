using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeApp.Controllers
{
    class RecipeAddController
    {
        private bool _adding;
        private readonly Button _acceptButton;
        private readonly Button _rejectButton;
        private event Action AddButtonRow;
        private event Action RemoveAddedRow;
        private event Action InsertRecipe;

        public RecipeAddController(Button acceptButton, Button rejectButton, Tuple<Action, Action, Action> rowEvents)
        {
            _acceptButton = acceptButton;
            _rejectButton = rejectButton;
            acceptButton.Click += Accept;
            rejectButton.Click += Reject;
            AddButtonRow += rowEvents.Item1;
            RemoveAddedRow += rowEvents.Item2;
            InsertRecipe += rowEvents.Item3;
        }

        public bool IsAdding
        {
            get => _adding;
            set
            {
                _adding = value;
                _acceptButton.Enabled = _adding;
                _rejectButton.Enabled = _adding;
            }
        }

        private void Accept(object sender, EventArgs e)
        {
            IsAdding = false;
            InsertRecipe?.Invoke();
            AddButtonRow?.Invoke();
        }

        private void Reject(object sender, EventArgs e)
        {
            IsAdding = false;
            RemoveAddedRow?.Invoke();
            AddButtonRow?.Invoke();
        }
    }
}
