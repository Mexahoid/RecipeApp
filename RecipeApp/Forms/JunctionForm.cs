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
    public partial class JunctionForm : Form
    {
        private event Action<string> OnYes;
        private readonly string _text;
        public JunctionForm(Action<string> act, string text)
        {
            InitializeComponent();
            OnYes += act;
            _text = text;
        }

        private void CtrlBtnEdit_Click(object sender, EventArgs e)
        {
            string text = "";
            bool flag = true;
            while (flag)
            {
                text = HelperForm.Invoke(false, _text);
                if (text != "")
                {
                    flag = false;
                }
                else
                {
                    MessageBox.Show("Если нужно удалить запись - выбирайте опцию" +
                                    " \"Удалить\". Пустые значения вводить нельзя.");
                }
            }
            DialogResult = DialogResult.OK;
            OnYes?.Invoke(text);
            Close();
        }

        private void CtrlBtnDelete_Click(object sender, EventArgs e)
        {
            if (ConfirmationForm.Invoke(_text) == DialogResult.Yes)
                DialogResult = DialogResult.Abort;
            Close();
        }

        private void CtrlBtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static string Invoke(string input)
        {
            string name = "";
            using (var jf = new JunctionForm(text => name = text, input))
            {
                DialogResult dr = jf.ShowDialog();
                switch (dr)
                {
                    case DialogResult.OK:
                        // Edit
                        return name;
                    case DialogResult.Abort:
                        // Delete
                        return null;
                    default:
                        return null;
                }
            }
        }
    }
}
