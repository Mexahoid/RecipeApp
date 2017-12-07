using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecipeApp.Models;

namespace RecipeApp.Controllers
{
    class LinkController
    {
        private readonly TextBoxModel _lm;
        private readonly Action OnChangeLock;

        public LinkController(TextBox tb, Action locker)
        {
            OnChangeLock += locker;
            _lm = new TextBoxModel(tb, OnChangeLock);
        }

        public void ChangeMode()
        {
            _lm.ChangeMode();
        }

        public string GetText()
        {
            return _lm.GetText();
        }

        public void SetText(string text)
        {
            _lm.SetText(text);
        }
    }
}
