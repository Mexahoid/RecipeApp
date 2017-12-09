using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;
using TBController = RecipeApp.Controllers.TextBoxController.TextBoxController;

namespace RecipeApp.Controllers
{
    class MainController
    {
        private readonly List<Control> _controls;
        private RecipeNamesController _rnc;
        private MultBoxesController _ktc;
        private MultBoxesController _tc;
        private TBController _linkCtrl;
        private TBController _textCtrl;
        private ButtonController _bc;
        private event Action<string> OnError;

        public MainController(IEnumerable controls, Action<string> onError)
        {
            _controls = new List<Control>();
            OnError += onError;
            InitControlsRecursively(controls);
            InitRecipeNamesController();
            InitTbController();
            InitKitchenController();
            InitTypeController();
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

            _rnc = new RecipeNamesController(
                _controls.Find(ctrl => ctrl.Name == "CtrlViewDGVNames") as DataGridView,
                ChangeLocker, RecipeSelectHandler, RecipeInsertHandler, ErrorHandler);
        }

        public void InitTbController()
        {
            TextBox tb = _controls.Find(ctrl => ctrl.Name == "CtrlViewTBLink") as TextBox;
            _linkCtrl = new TBController(tb, ChangeLocker, ErrorHandler);
            tb = _controls.Find(ctrl => ctrl.Name == "CtrlViewTBText") as TextBox;
            _textCtrl = new TBController(tb, ChangeLocker, ErrorHandler);
        }

        public void InitKitchenController()
        {
            ComboBox cb = _controls.Find(ctrl => ctrl.Name == "CBKitchen") as ComboBox;
            TextBox tb = _controls.Find(ctrl => ctrl.Name == "CtrlViewTBKitchen") as TextBox;
            QueryFactory.Queries[] queries =
            {
                QueryFactory.Queries.SelectKitchenByRecipeName,
                QueryFactory.Queries.InsertKitchen,
                QueryFactory.Queries.UpdateKitchen,
                QueryFactory.Queries.SelectAllKitchens
            };
            _ktc = new MultBoxesController(cb, tb, queries);
        }

        public void InitTypeController()
        {
            ComboBox cb = _controls.Find(ctrl => ctrl.Name == "CBType") as ComboBox;
            TextBox tb = _controls.Find(ctrl => ctrl.Name == "CtrlViewTBType") as TextBox;
            QueryFactory.Queries[] queries =
            {
                QueryFactory.Queries.SelectTypeByRecipeName,
                QueryFactory.Queries.InsertType,
                QueryFactory.Queries.UpdateType,
                QueryFactory.Queries.SelectAllTypes
            };
            _tc = new MultBoxesController(cb, tb, queries);
        }
        

        public void InitIngredsController()
        {
            
        }

        public void InitDeviceController()
        {
            
        }
        

        public void OnChangeMode()
        {
            _rnc.ModeChangeHandler();
            _ktc.ChangeLayout();
            _tc.ChangeLayout();
            _linkCtrl.ChangeMode();
            _textCtrl.ChangeMode();
        }


        private void ChangeLocker()
        {
            _bc.IsAdding = true;
            _rnc.Lock();
        }


        private void OnAccept()
        {
            _rnc.Unlock();
        }

        private void OnReject()
        {
            _rnc.Unlock();
            _rnc.HandleReject();
        }

        private void TextRecipeSelectHandler(string text)
        {
            
        }

        private void LinkRecipeSelectHandler(string text)
        {
            
        }

        private void RecipeSelectHandler(string text)
        {
            _linkCtrl.HandleRecipeSelection(text, QueryFactory.Queries.SelectLinkByRecipeName);
            _textCtrl.HandleRecipeSelection(text, QueryFactory.Queries.SelectTextByRecipeName);
            _ktc.HandleRecipeSelection(text);
        }

        private void RecipeInsertHandler(string text)
        {
            
        }

        private void ErrorHandler(string text)
        {
            OnError?.Invoke(text);
        }
    }
}
