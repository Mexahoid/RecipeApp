using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MassTuple = System.Tuple<System.Collections.Generic.List<System.Tuple<string, string>>, System.Collections.Generic.List<string>>; 

namespace RecipeApp.Forms
{
    public partial class IngredsForm : Form
    {
        private List<Tuple<string, string>> _names;
        private event Action<MassTuple> Action;
        public IngredsForm(MassTuple data, Action<MassTuple> act)
        {
            _names = data.Item1;
            InitializeComponent();
            Action += act;
            CtrlLblBefNameValue.Text = data.Item2[0];
            CtrlLblBefQtyValue.Text = data.Item2[1];
            CtrlLblBefUnitsValue.Text = data.Item2[2];
            FillDGV();
        }

        private void FillDGV()
        {
            CtrlDGV.Rows.Clear();
            CtrlDGV.ColumnCount = 1;
            foreach (var tuple in _names)
            {
                CtrlDGV.Rows.Add(tuple.Item1);
            }
            CtrlDGV.Rows.Add(Properties.Resources.AddNewIngred);
        }
        private void CtrlBtnOK_Click(object sender, EventArgs e)
        {
            Action?.Invoke(Tuple.Create(_names,
                new List<string>{CtrlLblAftNameValue.Text, CtrlNUD.Text, CtrlTB.Text}));
            Close();
        }

        private void CtrlBtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static MassTuple Invoke(MassTuple data)
        {
            var lst = new MassTuple(new List<Tuple<string, string>>(), new List<string>());
            using (var form = new IngredsForm(data, dat => lst = dat))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return lst;
                }
            }
            return null;
        }

        private void CtrlDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != CtrlDGV.RowCount - 1)
                return;
            string newName = RenameForm.Invoke();
            if (string.IsNullOrEmpty(newName))
                return;
            CtrlDGV.Rows[e.RowIndex].Cells[0].Value = newName;
            _names.Add(Tuple.Create(newName, ""));
            CtrlDGV.Rows.Add(Properties.Resources.AddNewDevice);
            CtrlLblAftNameValue.Text = newName;
            CtrlNUD.Value = 0;
            CtrlTB.Text = "";
        }

        private void CtrlDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == CtrlDGV.RowCount - 1)
                return;
            CtrlLblAftNameValue.Text = CtrlDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            _names[e.RowIndex] = Tuple.Create(CtrlLblAftNameValue.Text, _names[e.RowIndex].Item2);
            CtrlNUD.Value = 0;
            CtrlTB.Text = "";
        }
    }
}
