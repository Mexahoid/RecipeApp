using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;
using RecipeApp.Models.TextBoxes;

namespace RecipeApp.Controllers.TextBoxes
{
    class TextBoxController
    {
        private readonly TextBoxModel _lm;
        private event Action<string> OnError;
        private QueryFactory.Queries _selectQuery;
        public TextBoxController(TextBox tb, 
            Action locker, 
            Action<string> onError,
            QueryFactory.Queries query)
        {
            _selectQuery = query;
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
        

        public void HandleRecipeSelection(string text)
        {
            DataTable dt = Connector.GetTable(_selectQuery,
                new Tuple<string, string>("@Name", text));
            try
            {
                SetText(dt.Rows[0].ItemArray[0].ToString());
            }
            catch
            {
                SetText("");
                //OnError?.Invoke(e.Message);
            }
        }

        public void Clear()
        {
            _lm.SetText("");
        }
    }
}
