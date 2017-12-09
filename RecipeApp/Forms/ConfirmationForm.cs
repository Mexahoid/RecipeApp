using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeApp.Forms
{
    public partial class ConfirmationForm : Form
    {
        public ConfirmationForm(string text)
        {
            InitializeComponent();
            CtrlLbl.Text = $"Действительно удалить запись \n{text}?";
        }

        private void CtrlBtnYes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CtrlBtnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static DialogResult Invoke(string text)
        {
            using (var cf = new ConfirmationForm(text))
            {
                return cf.ShowDialog();
            }
        }
    }
}
