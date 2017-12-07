using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeApp.Controllers
{
    class MainController
    {
        private List<Control> _controls;
        private RecipeNamesController _rnc;
        private KitchenController _ktc;
        private LinkController _lc;
        private ButtonController _bc;

        public MainController(IEnumerable controls)
        {
            _controls = new List<Control>();
            InitControlsRecursively(controls);
            InitRecipeNamesController();
            InitLinkController();
            InitKitchenController();
            InitTypeController();
            InitTextController();
            InitIngredsController();
            InitDeviceController();
        }


        private void InitControlsRecursively(IEnumerable controls)
        {
            foreach (object control in controls)
            {
                if((control as Control)?.Controls != null)
                    InitControlsRecursively((control as Control).Controls);
                
                    _controls.Add(control as Control);
            }
        }

        public void InitRecipeNamesController()
        {
            Button acc = _controls.Find(ctrl => ctrl.Name == "CtrlBtnAccept") as Button;
            Button rej = _controls.Find(ctrl => ctrl.Name == "CtrlBtnReject") as Button;
            RadioButton rbView = _controls.Find(ctrl => ctrl.Name == "CtrlRBSelect") as RadioButton;
            RadioButton rbEdit = _controls.Find(ctrl => ctrl.Name == "CtrlRBEdit") as RadioButton;

            _bc = new ButtonController(new List<Control> { acc, rej, rbView, rbEdit },
                new Tuple<Action, Action, Action>(OnAccept, OnReject, OnChangeMode));

            _rnc = new RecipeNamesController(_controls.Find(ctrl => ctrl.Name == "CtrlViewDGVNames") as DataGridView);
        }

        public void InitLinkController()
        {
            TextBox tb = _controls.Find(ctrl => ctrl.Name == "CtrlViewTBLink") as TextBox;
            _lc = new LinkController(tb, OnChangeLock);
        }

        public void InitKitchenController()
        {
            ComboBox cb = _controls.Find(ctrl => ctrl.Name == "CBKitchen") as ComboBox;
            TextBox tb = _controls.Find(ctrl => ctrl.Name == "CtrlViewTBKitchen") as TextBox;
            _ktc = new KitchenController(cb, tb);
        }

        public void InitTypeController()
        {
            
        }

        public void InitTextController()
        {
            
        }

        public void InitIngredsController()
        {
            
        }

        public void InitDeviceController()
        {
            
        }
        

        public void OnChangeMode()
        {
            _rnc.ChangeMode();
            _ktc.ChangeLayout();
            _lc.ChangeMode();
        }

        public void DGVClick(object sender, DataGridViewCellEventArgs e, Action<string> act)
        {
            _rnc.DGVButton_Clicked(sender, e, act);
        }


        private void OnChangeLock()
        {
            _bc.IsAdding = true;
        }


        private void OnAccept()
        {
            
        }

        private void OnReject()
        {

        }

        private void OnRecipeSelect()
        {
            
        }
    }
}
