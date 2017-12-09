using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;
using RecipeApp.Models.TextBoxModel;

namespace RecipeApp.Controllers.TextBoxController
{
    class TextBoxController
    {
        private readonly TextBoxModel _lm;
        private event Action<string> OnError;

        public TextBoxController(TextBox tb, Action locker, Action<string> onError)
        {
            OnError += onError;
            _lm = new TextBoxModel(tb, locker);
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
        

        public void HandleRecipeSelection(string text, QueryFactory.Queries query)
        {
            DataTable dt = Connector.GetTable(query,
                new Tuple<string, string>("@Name", text));
            try
            {
                SetText(dt.Rows[0].ItemArray[0].ToString());
            }
            catch (Exception e)
            {
                SetText("");
                //OnError?.Invoke(e.Message);
            }
        }
    }
}
