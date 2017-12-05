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
    public partial class Adder : Form
    {
        private event Action<string> _del;
        
        public Adder(Action<string> act)
        {
            InitializeComponent();
            _del += act;
        }

        private void CtrlBtnAdd_Click(object sender, EventArgs e)
        {
            _del(CtrlTBName.Text);
            this.Close();
        }

        private void CtrlBtnReject_Click(object sender, EventArgs e)
        {

        }
    }
}
