using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
            CtrlViewDGVNames.AutoGenerateColumns = true;
            CtrlViewDGVIngreds.AutoGenerateColumns = true;
            CtrlViewDGVDevices.AutoGenerateColumns = true;
            CtrlEditorDGVNames.AutoGenerateColumns = true;
            CtrlDGVRUniv.AutoGenerateColumns = true;
            CtrlEditorDGVIngredsView.ColumnCount = 3;
            CtrlEditorInfoDGVRIngredsToAdd.Columns.Add("Название", "Название");
            CtrlEditorInfoDGVRIngredsToAdd.Columns.Add("Количество", "Количество");
            CtrlEditorInfoDGVRIngredsToAdd.Columns.Add("Единиц", "Единиц");
            //CtrlEditorInfoDGVRNewIngreds.RowCount = 1;
            CtrlEditorDGVIngredsView.AutoGenerateColumns = true;
        }

        private void CtrlButReload_Click(object sender, EventArgs e)
        {
            //GetRecipesNames();
        }


        private void GetRecipesNames()
        {
            var str = _queries.GetQuery(QueryFactory.Queries.QuerySelectRecipeNames);

            GetData(CtrlViewDGVNames, str);
            GetData(CtrlEditorDGVNames, str);
        }

        private void GetData(DataGridView DGV, string selectCommand, params Tuple<string, string>[] tuples)
        {
            DGV.DataSource = GetTable(selectCommand, tuples);
        }
        private void GetData(ListControl LB, string selectCommand, params Tuple<string, string>[] tuples)
        {
            LB.DataSource = GetTable(selectCommand, tuples);
            LB.DisplayMember = "Name";
        }
        private void CtrlDGVNames_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = (string)CtrlViewDGVNames.Rows[CtrlViewDGVNames.CurrentCell.RowIndex].Cells[0].Value;
            string selectCommand = _queries.GetQuery(QueryFactory.Queries.QueryViewerSelectIngreds);
            Tuple<string, string> pars = new Tuple<string, string>("@Name", str);

            GetData(CtrlViewDGVIngreds, selectCommand, pars);

            selectCommand = _queries.GetQuery(QueryFactory.Queries.QueryViewerSelectDevices);
            GetData(CtrlViewDGVDevices, selectCommand, pars);

            selectCommand = _queries.GetQuery(QueryFactory.Queries.QueryViewerSelectMiscData);
            DataRowCollection rows = GetTable(selectCommand, pars).Rows;
            var arr = rows.Count != 0 ? rows[0].ItemArray : new object[] { "Ошибка вызова", "Ошибка вызова", "Ошибка вызова", "" };

            CtrlViewTBText.Text = arr[0].ToString();
            str = arr[3].ToString();
            CtrlViewTBKitchen.Text = str.Equals("") ? "Без кухни" : str;
            CtrlViewTBLink.Text = arr[1].ToString();
            CtrlViewTBType.Text = arr[2].ToString();
        }

        private DataTable GetTable(string selectCommand, params Tuple<string, string>[] tuples)
        {
            try
            {
                return _connector.GetTable(selectCommand, tuples);
            }
            catch (SqlException exception)
            {
                switch (exception.Number)
                {
                    case 2627:
                        MessageBox.Show("Нельзя создавать дублирующие записи");
                        return null;

                    default:
                        MessageBox.Show(exception.Message);
                        return null;
                }
            }

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _connector = new Connector();
            _queries = new QueryFactory();
            GetRecipesNames();
            CtrlViewDGVNames.ClearSelection();
            CtrlEditorDGVNames.ClearSelection();
            ShowIngredsPure();
            FillListBoxes();
        }

        private void CtrlRB_CheckedChanged(object sender, EventArgs e)
        {
            CtrlLblTableText.Text = (sender as Control)?.Text;
            CtrlGrBRTablesChoice.Tag = (sender as Control)?.Tag;
            ShowUnivTable();
            CtrlGrBRAdder.Enabled = true;
        }

        private void ShowUnivTable()
        {
            string query = _queries.GetQuery((QueryFactory.Queries)Convert.ToInt32(CtrlGrBRTablesChoice.Tag));
            GetData(CtrlDGVRUniv, query);
        }


        private void CtrlBtnTPDevicesAdd_Click(object sender, EventArgs e)
        {
            string query = _queries.GetQuery((QueryFactory.Queries)Convert.ToInt32(CtrlGrBRTablesChoice.Tag) + 3);
            GetTable(query, new Tuple<string, string>("@Name", CtrlTbTPName.Text));
            ShowUnivTable();
        }

        private void CtrlEditorBtnIngredsAdd_Click(object sender, EventArgs e)
        {
            string query = _queries.GetQuery(QueryFactory.Queries.QueryRedactorInsertIngreds);
            string name = CtrlEditorTBIngredsName.Text;
            string units = CtrlEditorTBIngredsUnits.Text.Replace(".", string.Empty);
            units += '.';
            GetTable(query, new Tuple<string, string>("@Name", name), new Tuple<string, string>("@Units", units));
            ShowIngredsPure();
        }

        private void ShowIngredsPure()
        {
            string query = _queries.GetQuery(QueryFactory.Queries.QueryRedactorSelectPureIngreds);
            GetData(CtrlEditorDGVIngredsView, query);
            CtrlEditorLBIngredsAll.DataSource = GetTable(query);
            CtrlEditorLBIngredsAll.DisplayMember = "Название";
            CtrlEditorLBIngredsAll.ClearSelected();
        }

        private void FillListBoxes()
        {
            string query = _queries.GetQuery(QueryFactory.Queries.QueryRedactorSelectKitchens);
            GetData(CtrlEditorInfoLBKitchens, query);
            CtrlEditorInfoLBKitchens.ClearSelected();
            query = _queries.GetQuery(QueryFactory.Queries.QueryRedactorSelectDevices);
            GetData(CtrlEditorInfoLBDevices, query);
            CtrlEditorInfoLBDevices.ClearSelected();
            query = _queries.GetQuery(QueryFactory.Queries.QueryRedactorSelectTypes);
            GetData(CtrlEditorInfoLBTypes, query);
            CtrlEditorInfoLBTypes.ClearSelected();
        } 

        private void CtrlEditorLBIngredsAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlEditorLblUnits.Text = (CtrlEditorLBIngredsAll.SelectedItem as DataRowView)?.Row.ItemArray[1].ToString();
        }

        private void CtrlEditorBtnAddIngred_Click(object sender, EventArgs e)
        {
            if (CtrlEditorTBIngredCount.Text.Equals(""))
            {
                MessageBox.Show("Падла, зполни количество");
                return;
            }
            if(CtrlEditorLBIngredsAll.SelectedIndex < 0)
            {
                MessageBox.Show("Падла, выбери ингредиент");
                return;
            }
            string name = (CtrlEditorLBIngredsAll.SelectedItem as DataRowView)?.Row.ItemArray[0].ToString();
            if (CheckExistence(name))
            {
                MessageBox.Show("Падла, не добавляй существующие");
                return;
            }
            CtrlEditorInfoDGVRIngredsToAdd.Rows.Add();
            CtrlEditorInfoDGVRIngredsToAdd.Rows[CtrlEditorInfoDGVRIngredsToAdd.RowCount - 1].Cells[1].Value =
                CtrlEditorTBIngredCount.Text;
            CtrlEditorInfoDGVRIngredsToAdd.Rows[CtrlEditorInfoDGVRIngredsToAdd.RowCount - 1].Cells[0].Value =
                (CtrlEditorLBIngredsAll.SelectedItem as DataRowView)?.Row.ItemArray[0].ToString();
            CtrlEditorInfoDGVRIngredsToAdd.Rows[CtrlEditorInfoDGVRIngredsToAdd.RowCount - 1].Cells[2].Value =
                CtrlEditorLblUnits.Text;

        }

        private bool CheckExistence(string name)
        {
            foreach (DataGridViewRow row in CtrlEditorInfoDGVRIngredsToAdd.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(name))
                    return true;
            }
            return false;
        }

        private void CtrlEditorBtnDeleteIngred_Click(object sender, EventArgs e)
        {
            CtrlEditorInfoDGVRIngredsToAdd.Rows.RemoveAt(CtrlEditorInfoDGVRIngredsToAdd.CurrentCell.RowIndex);
            CtrlEditorInfoDGVRIngredsToAdd.ClearSelection();
            CtrlEditorBtnDeleteIngred.Enabled = false;
        }

        private void CtrlEditorInfoDGVRIngredsToAdd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CtrlEditorBtnDeleteIngred.Enabled = true;
        }
    }
}
