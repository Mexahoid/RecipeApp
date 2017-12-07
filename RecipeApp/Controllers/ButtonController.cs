using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeApp.Controllers
{
    class ButtonController
    {
        private bool _adding;
        private readonly Button _acceptButton;
        private readonly Button _rejectButton;
        private readonly RadioButton _rbView, _rbEdit;
        private event Action OnAccept;
        private event Action OnReject;
        private event Action OnModeChange;

        public ButtonController(List<Control> controls, Tuple<Action, Action, Action> rowEvents)
        {
            _acceptButton = controls[0] as Button;
            _rejectButton = controls[1] as Button;
            _rbView = controls[2] as RadioButton;
            _rbEdit = controls[3] as RadioButton;

            _acceptButton.Click += Accept;
            _rejectButton.Click += Reject;

            OnAccept += rowEvents.Item1;
            OnReject += rowEvents.Item2;
            OnModeChange += rowEvents.Item3;

            _rbEdit.CheckedChanged += ModeChange;
        }

        public bool IsAdding
        {
            get => _adding;
            set
            {
                _adding = value;
                _acceptButton.Enabled = _adding;
                _rejectButton.Enabled = _adding;
                _rbEdit.Enabled = !_adding;
                _rbView.Enabled = !_adding;
            }
        }

        private void Accept(object sender, EventArgs e)
        {
            IsAdding = false;
            OnAccept?.Invoke();
        }

        private void Reject(object sender, EventArgs e)
        {
            IsAdding = false;
            OnReject?.Invoke();
        }

        private void ModeChange(object sender, EventArgs e)
        {
            OnModeChange?.Invoke();
        }
    }
}
