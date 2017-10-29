using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;

namespace RecipeApp
{
    public partial class FormMain : Form
    {
        private Connector _connector;
        private QueryFactory _queries;
        public FormMain()
        {
            InitializeComponent();
            CtrlDGVNames.AutoGenerateColumns = true;
            CtrlDGVIngreds.AutoGenerateColumns = true;
            CtrlDGVDevices.AutoGenerateColumns = true;
            CtrlDGVRRecipes.AutoGenerateColumns = true;
            CtrlDGVRIngreds.AutoGenerateColumns = true;
        }

        private void CtrlButReload_Click(object sender, EventArgs e)
        {
            //GetRecipesNames();
        }


        private void GetRecipesNames()
        {
            var str = _queries.GetQuery(QueryFactory.Queries.QuerySelectRecipeNames);

            GetData(CtrlDGVNames, CtrlBindSourceNames, str);
            GetData(CtrlDGVRRecipes, CtrlBindSourceNames, str);
        }

        private void GetData(DataGridView DGV, BindingSource BS, string selectCommand, params Tuple<string, string>[] tuples)
        {
            DataTable table = GetTable(selectCommand, tuples);

            BS.DataSource = table;
            DGV.DataSource = null;
            DGV.DataSource = BS;
        }

        private void CtrlDGVNames_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = (string)CtrlDGVNames.Rows[CtrlDGVNames.CurrentCell.RowIndex].Cells[0].Value;
            string selectCommand = _queries.GetQuery(QueryFactory.Queries.QueryViewerSelectIngreds);
            Tuple<string, string> pars = new Tuple<string, string>("@Name", str);

            GetData(CtrlDGVIngreds, CtrlBindSourceIngreds, selectCommand, pars);

            selectCommand = _queries.GetQuery(QueryFactory.Queries.QueryViewerSelectDevices);
            GetData(CtrlDGVDevices, CtrlBindSourceDevices, selectCommand, pars);

            selectCommand = _queries.GetQuery(QueryFactory.Queries.QueryViewerSelectMiscData);
            DataRowCollection rows = GetTable(selectCommand, pars).Rows;
            object[] arr;
            if (rows.Count != 0)
            {
                arr = rows[0].ItemArray;
            }
            else
            {
                arr = new object[]{"Ошибка вызова", "Ошибка вызова", "Ошибка вызова", ""};
            }

            CtrlTBText.Text = arr[0].ToString();
            str = arr[3].ToString();
            CtrlTBKitchen.Text = str.Equals("") ? "Без кухни" : str;
            CtrlTBLink.Text = arr[1].ToString();
            CtrlTBType.Text = arr[2].ToString();

        }

        private DataTable GetTable(string selectCommand, params Tuple<string, string>[] tuples)
        {
            try
            {
                return _connector.GetTable(selectCommand, tuples);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _connector = new Connector();
            _queries = new QueryFactory();
            GetRecipesNames();
            CtrlDGVNames.ClearSelection();
            CtrlDGVRRecipes.ClearSelection();
        }

        private void CtrlRB_CheckedChanged(object sender, EventArgs e)
        {
            CtrlLblTableText.Text = (sender as Control)?.Text;
        }
    }
}
