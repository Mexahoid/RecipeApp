using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeApp
{
    public partial class HelperForm : Form
    {
        private event Action<string> Del;

        public HelperForm(bool isAdding, Action<string> act)
        {
            InitializeComponent();
            CtrlBtnAdd.Text = isAdding ? "Добавить" : "Изменить";
            Del += act;
        }

        private void CtrlBtnAdd_Click(object sender, EventArgs e)
        {
            Del?.Invoke(CtrlTBName.Text);
            Close();
        }

        private void CtrlBtnReject_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetText(string text)
        {
            CtrlTBName.Text = text;
        }

        public static string Invoke(bool isAdding = true, string inputText = "")
        {
            string name = "";
            using (var add = new HelperForm(isAdding, text => name = text))
            {
                add.SetText(inputText);
                if (add.ShowDialog() == DialogResult.OK)
                {
                    return name;
                }
            }
            return null;
        }
    }
}
