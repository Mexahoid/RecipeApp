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

namespace RecipeApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            CtrlDGVNames.AutoGenerateColumns = true;
            CtrlDGVIngreds.AutoGenerateColumns = true;
            CtrlDGVDevices.AutoGenerateColumns = true;
        }

        private void CtrlButReload_Click(object sender, EventArgs e)
        {
            GetData("Select Name From Recipe", CtrlDGVNames, CtrlBindSourceNames);
        }

        private void GetData(string selectCommand, DataGridView DGV, BindingSource BS)
        {
            DataTable table = GetTable(selectCommand);

            BS.DataSource = table;
            DGV.DataSource = null;
            DGV.DataSource = BS;
        }

        private void CtrlDGVNames_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = (string)CtrlDGVNames.Rows[CtrlDGVNames.CurrentCell.RowIndex].Cells[0].Value;
            string selectCommand = "SELECT I.[Name] AS 'Название', RI.[Quantity] AS 'Количество', I.[Units] AS 'Единицы измерения'" +
                                         " FROM [RecipeIngredient] AS RI" +
                                         " LEFT JOIN [Recipe] AS R ON R.ID = RI.IDRecipe" +
                                         " LEFT JOIN [Ingredient] AS I ON I.ID = RI.IDIngred" +
                                         " WHERE R.Name = '" + str + "'";
            GetData(selectCommand, CtrlDGVIngreds, CtrlBindSourceIngreds);

            selectCommand = "SELECT R.[Description], R.[Link], T.[Name], K.[Name] " +
                            " FROM [Recipe] AS R"+
                            " LEFT JOIN [Type] AS T ON T.ID = R.IDType" +
                            " LEFT JOIN [Kitchen] AS K ON K.ID = R.IDKitchen" +
                            "  WHERE R.Name = '"+ str + "'";
            DataRowCollection rows = GetTable(selectCommand).Rows;
            object[] Arr = rows[0].ItemArray;

            CtrlTBText.Text = Arr[0].ToString();
            str = Arr[3].ToString();
            CtrlTBKitchen.Text = str.Equals("") ? "Без кухни" : str;
            CtrlTBLink.Text = Arr[1].ToString();
            CtrlTBType.Text = Arr[2].ToString();
        }

        private static DataTable GetTable(string selectCommand)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.
                    ConnectionStrings["RecipeConnectionString"].ConnectionString;

                var dataAdapter = new SqlDataAdapter(selectCommand, connectionString);


                var table = new DataTable
                {
                    Locale = System.Globalization.CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                return table;
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }

        }
    }
}
