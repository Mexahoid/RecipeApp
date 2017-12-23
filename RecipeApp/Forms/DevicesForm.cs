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
    public partial class DevicesForm : Form
    {
        private readonly List<Tuple<string, string>> _data;
        private event Action<List<Tuple<string, string>>, string> Action;
        public DevicesForm(List<Tuple<string, string>> data,
            string oldName,
            Action<List<Tuple<string, string>>, string> act)
        {
            InitializeComponent();
            CtrlLblOld.Text = oldName;
            CtrlLblNew.Text = "Отсутствует";
            _data = data;
            Action += act;
            FillDGV();
        }

        private void FillDGV()
        {
            CtrlDGV.Rows.Clear();
            CtrlDGV.ColumnCount = 1;
            foreach (var tuple in _data)
            {
                CtrlDGV.Rows.Add(tuple.Item1);
            }
            CtrlDGV.Rows.Add(Properties.Resources.AddNewDevice);
        }

        private void CtrlButOK_Click(object sender, EventArgs e)
        {
            Action?.Invoke(_data, CtrlLblTxtNew.Text);
            Close();
        }

        private void CtrlButCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static Tuple<List<Tuple<string, string>>, string> Invoke(
            List<Tuple<string, string>> data,
            string oldName)
        {
            var lst = new List<Tuple<string, string>>();
            string newName = "";
            using (var df = new DevicesForm(data, oldName, 
                (dat, nam) => {lst = dat; newName = nam;}))
            {
                if (df.ShowDialog() == DialogResult.OK)
                {
                   return Tuple.Create(lst, newName);
                }
            }
            return null;
        }

        private void CtrlDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == CtrlDGV.RowCount - 1)
            {
                string newName = RenameForm.Invoke();
                if (string.IsNullOrEmpty(newName))
                    return;
                CtrlDGV.Rows[e.RowIndex].Cells[0].Value = newName;
                _data.Add(Tuple.Create(newName, ""));
                CtrlDGV.Rows.Add(Properties.Resources.AddNewDevice);
            }
            else
            {
                CtrlLblNew.Text = CtrlDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
    }
}
