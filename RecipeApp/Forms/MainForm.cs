using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;
using RecipeApp.Controllers;

namespace RecipeApp.Forms
{
    public partial class FormMain : Form
    {
        private MainController _mc;
        public FormMain()
        {
            InitializeComponent();
            CtrlViewDGVNames.AutoGenerateColumns = true;
            CtrlViewDGVIngreds.AutoGenerateColumns = true;
            CtrlViewDGVDevices.AutoGenerateColumns = true;
        }
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            CtrlViewDGVNames.ClearSelection();
            _mc = new MainController(Controls, text => MessageBox.Show(text));
        }
        
    }
}
