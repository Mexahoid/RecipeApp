using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeApp.Models
{
    class TextBoxModel
    {
        private readonly TextBox _tb;
        private bool _isLocked;
        private event Action OnChange;

        public TextBoxModel(TextBox textBox, Action onChangeAction)
        {
            _tb = textBox;
            _tb.TextChanged += TextChanged;
            OnChange += onChangeAction;
        }

        public void ChangeMode()
        {
            _tb.ReadOnly = !_tb.ReadOnly;
        }

        public string GetText()
        {
            return _tb.Text;
        }

        public void SetText(string text)
        {
            _isLocked = true;
            _tb.Text = text;
            _isLocked = false;
        }

        private void TextChanged(object sender, EventArgs e)
        {
            if (!_isLocked)
            {
                OnChange?.Invoke();
            }
        }
    }
}
