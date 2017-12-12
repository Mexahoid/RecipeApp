using System;
using System.Data;
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
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DataTable dt = Connector.GetTable(QueryFactory.Queries.SelectAllKitchens);
            foreach (DataRow dataRow in dt.Rows)
            {
                CBKitchen.Items.Add(dataRow.ItemArray[0]);
            }
            
            _mc = new MainController(Controls, text => MessageBox.Show(text));
        }
    }
}
