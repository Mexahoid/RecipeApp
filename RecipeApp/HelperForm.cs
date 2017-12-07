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
        public enum Operation
        {
            Add,
            Rename
        }

        private event Action<string> Del;

        public HelperForm(Operation op, Action<string> act)
        {
            InitializeComponent();
            CtrlBtnAdd.Text = op == Operation.Add ? "Добавить" : "Изменить";
            Del += act;
        }

        private void CtrlBtnAdd_Click(object sender, EventArgs e)
        {
            Del?.Invoke(CtrlTBName.Text);
            this.Close();
        }

        private void CtrlBtnReject_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
