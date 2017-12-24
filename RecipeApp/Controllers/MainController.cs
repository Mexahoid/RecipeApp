using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;
using RecipeApp.Controllers.DevicesDGV;
using RecipeApp.Controllers.IngredsDGV;
using RecipeApp.Controllers.MultBoxes;
using RecipeApp.Controllers.RecipeNames;
using RecipeApp.Controllers.TextBoxes;

namespace RecipeApp.Controllers
{
    class MainController
    {
        private readonly List<Control> _controls;
        private RecipeNamesController _rnc;
        private MultBoxesController _ktc;
        private MultBoxesController _tc;
        private TextBoxController _linkCtrl;
        private TextBoxController _textCtrl;
        private DevicesDGVController _devCtrl;
        private IngredsDGVController _ingrCtrl;
        private PersistenceController _persistor;

        private ButtonController _bc;
        private event Action<string> OnError;

        public MainController(IEnumerable controls, Action<string> onError)
        {
            _controls = new List<Control>();
            _persistor = new PersistenceController();
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
            _linkCtrl = new TextBoxController(tb, ChangeLocker, ErrorHandler, QueryFactory.Queries.SelectLinkByRecipeName);
            tb = _controls.Find(ctrl => ctrl.Name == "CtrlViewTBText") as TextBox;
            _textCtrl = new TextBoxController(tb, ChangeLocker, ErrorHandler, QueryFactory.Queries.SelectTextByRecipeName);
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
            DataGridView ingreds = _controls.Find(ctrl => ctrl.Name == "CtrlViewDGVIngreds") as DataGridView;
            _ingrCtrl = new IngredsDGVController(ingreds, ChangeLocker);
        }

        public void InitDeviceController()
        {
            DataGridView devices = _controls.Find(ctrl => ctrl.Name == "CtrlViewDGVDevices") as DataGridView;
            _devCtrl = new DevicesDGVController(devices, ChangeLocker);
        }
        

        public void OnChangeMode()
        {
            _rnc.ModeChangeHandler();
            _ktc.ChangeLayout();
            _tc.ChangeLayout();
            _linkCtrl.ChangeMode();
            _textCtrl.ChangeMode();
            _devCtrl.ChangeMode();
            _ingrCtrl.ChangeMode();
        }


        private void ChangeLocker()
        {
            _bc.IsAdding = true;
            _rnc.Lock();
        }


        private void OnAccept()
        {
            _persistor.DoubleListPersister(_devCtrl.GetDevicesNames(), PersistenceController.DoubleLists.Device);
            _persistor.DoubleListPersister(_ktc.GetMultiboxData(), PersistenceController.DoubleLists.Kitchen);
            _persistor.DoubleListPersister(_tc.GetMultiboxData(), PersistenceController.DoubleLists.Type);

            _persistor.RecipeKitchen = _ktc.GetValue();
            _persistor.RecipeType = _tc.GetValue();
            _persistor.RecipeText = _textCtrl.GetText();
            _persistor.RecipeLink = _linkCtrl.GetText();
            _persistor.Ingreds = _ingrCtrl.GetData();
            _persistor.PersistIngredsChanges(_ingrCtrl.GetNames());

            _persistor.RecipeName = _rnc.GetValue();
            _persistor.RecipeSpecificDevices = _devCtrl.GetDevicesForRecipe();
            _persistor.PersistRecipe();

            Clear();
            _rnc.Unlock();
        }

        private void Clear()
        {
            _ktc.Clear();
            _tc.Clear();
            _linkCtrl.Clear();
            _textCtrl.Clear();
            _devCtrl.Clear();
            _ingrCtrl.Clear();
        }

        private void OnReject()
        {
            _rnc.Unlock();
            _rnc.HandleReject();
            _rnc.SelectCellWithName();
        }

        private void TextRecipeSelectHandler(string text)
        {
            
        }

        private void LinkRecipeSelectHandler(string text)
        {
            
        }

        private void RecipeSelectHandler(string text)
        {
            _linkCtrl.HandleRecipeSelection(text);
            _textCtrl.HandleRecipeSelection(text);
            _ktc.HandleRecipeSelection(text);
            _tc.HandleRecipeSelection(text);
            _devCtrl.HandleRecipeSelection(text);
            _ingrCtrl.HandleRecipeSelection(text);
        }

        private void RecipeInsertHandler()
        {
            ChangeLocker();
        }

        private void ErrorHandler(string text)
        {
            OnError?.Invoke(text);
        }
    }
}
