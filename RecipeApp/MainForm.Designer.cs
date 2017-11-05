namespace RecipeApp
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CtrlBindSourceNames = new System.Windows.Forms.BindingSource(this.components);
            this.recipeDataSet = new DBLayer.RecipeDataSet();
            this.CtrlButReload = new System.Windows.Forms.Button();
            this.CtrlDGVNames = new System.Windows.Forms.DataGridView();
            this.CtrlPanel = new System.Windows.Forms.Panel();
            this.CtrlTBType = new System.Windows.Forms.TextBox();
            this.CtrlLblType = new System.Windows.Forms.Label();
            this.CtrlTBKitchen = new System.Windows.Forms.TextBox();
            this.CtrlLblKitchen = new System.Windows.Forms.Label();
            this.CtrlRecipeTabs = new System.Windows.Forms.TabControl();
            this.CtrlTPRecipeText = new System.Windows.Forms.TabPage();
            this.CtrlTBText = new System.Windows.Forms.TextBox();
            this.CtrlTPRecipeIngreds = new System.Windows.Forms.TabPage();
            this.CtrlDGVIngreds = new System.Windows.Forms.DataGridView();
            this.CtrlBindSourceIngreds = new System.Windows.Forms.BindingSource(this.components);
            this.CtrlTPRecipeDevices = new System.Windows.Forms.TabPage();
            this.CtrlDGVDevices = new System.Windows.Forms.DataGridView();
            this.CtrlBindSourceDevices = new System.Windows.Forms.BindingSource(this.components);
            this.CtrlTBLink = new System.Windows.Forms.TextBox();
            this.CtrlLblLink = new System.Windows.Forms.Label();
            this.CtrlTCMain = new System.Windows.Forms.TabControl();
            this.CtrlTabView = new System.Windows.Forms.TabPage();
            this.CtrlTabEdit = new System.Windows.Forms.TabPage();
            this.CtrlTCEdits = new System.Windows.Forms.TabControl();
            this.CtrlTPRecipeAdder = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CtrlDGVRIngreds = new System.Windows.Forms.DataGridView();
            this.CtrlBtnRAdd = new System.Windows.Forms.Button();
            this.CtrlLBTypes = new System.Windows.Forms.ListBox();
            this.CtrlLblRType = new System.Windows.Forms.Label();
            this.CtrlLBDevices = new System.Windows.Forms.ListBox();
            this.CtrlLblRDevice = new System.Windows.Forms.Label();
            this.CtrlLBKitchens = new System.Windows.Forms.ListBox();
            this.CtrlLblRKitchen = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CtrlLblRText = new System.Windows.Forms.Label();
            this.CtrlLblRLink = new System.Windows.Forms.Label();
            this.CtrlLblRName = new System.Windows.Forms.Label();
            this.CtrlLblRRecipes = new System.Windows.Forms.Label();
            this.CtrlDGVRRecipes = new System.Windows.Forms.DataGridView();
            this.CtrlTPDevices = new System.Windows.Forms.TabPage();
            this.CtrlGrBRTablesChoice = new System.Windows.Forms.GroupBox();
            this.CtrlRBTypes = new System.Windows.Forms.RadioButton();
            this.CtrlRBDevices = new System.Windows.Forms.RadioButton();
            this.CtrlRBKitchens = new System.Windows.Forms.RadioButton();
            this.CtrlGrBRAdder = new System.Windows.Forms.GroupBox();
            this.CtrlBtnTPDevicesAdd = new System.Windows.Forms.Button();
            this.CtrlTbTPName = new System.Windows.Forms.TextBox();
            this.CtrlLblTPDevicesName = new System.Windows.Forms.Label();
            this.CtrlLblTableText = new System.Windows.Forms.Label();
            this.CtrlDGVRUniv = new System.Windows.Forms.DataGridView();
            this.CtrlBindSourceUniv = new System.Windows.Forms.BindingSource(this.components);
            this.CtrlLblRIngredients = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlBindSourceNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVNames)).BeginInit();
            this.CtrlPanel.SuspendLayout();
            this.CtrlRecipeTabs.SuspendLayout();
            this.CtrlTPRecipeText.SuspendLayout();
            this.CtrlTPRecipeIngreds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVIngreds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlBindSourceIngreds)).BeginInit();
            this.CtrlTPRecipeDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlBindSourceDevices)).BeginInit();
            this.CtrlTCMain.SuspendLayout();
            this.CtrlTabView.SuspendLayout();
            this.CtrlTabEdit.SuspendLayout();
            this.CtrlTCEdits.SuspendLayout();
            this.CtrlTPRecipeAdder.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVRIngreds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVRRecipes)).BeginInit();
            this.CtrlTPDevices.SuspendLayout();
            this.CtrlGrBRTablesChoice.SuspendLayout();
            this.CtrlGrBRAdder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVRUniv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlBindSourceUniv)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlBindSourceNames
            // 
            this.CtrlBindSourceNames.DataSource = this.recipeDataSet;
            this.CtrlBindSourceNames.Position = 0;
            // 
            // recipeDataSet
            // 
            this.recipeDataSet.DataSetName = "RecipeDataSet";
            this.recipeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CtrlButReload
            // 
            this.CtrlButReload.Location = new System.Drawing.Point(3, 6);
            this.CtrlButReload.Name = "CtrlButReload";
            this.CtrlButReload.Size = new System.Drawing.Size(75, 23);
            this.CtrlButReload.TabIndex = 0;
            this.CtrlButReload.Text = "Обновить";
            this.CtrlButReload.UseVisualStyleBackColor = true;
            this.CtrlButReload.Click += new System.EventHandler(this.CtrlButReload_Click);
            // 
            // CtrlDGVNames
            // 
            this.CtrlDGVNames.AllowUserToAddRows = false;
            this.CtrlDGVNames.AllowUserToDeleteRows = false;
            this.CtrlDGVNames.AllowUserToResizeColumns = false;
            this.CtrlDGVNames.AllowUserToResizeRows = false;
            this.CtrlDGVNames.AutoGenerateColumns = false;
            this.CtrlDGVNames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CtrlDGVNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlDGVNames.ColumnHeadersVisible = false;
            this.CtrlDGVNames.DataSource = this.CtrlBindSourceNames;
            this.CtrlDGVNames.Location = new System.Drawing.Point(3, 32);
            this.CtrlDGVNames.MultiSelect = false;
            this.CtrlDGVNames.Name = "CtrlDGVNames";
            this.CtrlDGVNames.ReadOnly = true;
            this.CtrlDGVNames.RowHeadersVisible = false;
            this.CtrlDGVNames.RowHeadersWidth = 18;
            this.CtrlDGVNames.Size = new System.Drawing.Size(260, 468);
            this.CtrlDGVNames.TabIndex = 1;
            this.CtrlDGVNames.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CtrlDGVNames_CellClick);
            // 
            // CtrlPanel
            // 
            this.CtrlPanel.Controls.Add(this.CtrlTBType);
            this.CtrlPanel.Controls.Add(this.CtrlLblType);
            this.CtrlPanel.Controls.Add(this.CtrlTBKitchen);
            this.CtrlPanel.Controls.Add(this.CtrlLblKitchen);
            this.CtrlPanel.Controls.Add(this.CtrlRecipeTabs);
            this.CtrlPanel.Controls.Add(this.CtrlTBLink);
            this.CtrlPanel.Controls.Add(this.CtrlLblLink);
            this.CtrlPanel.Location = new System.Drawing.Point(269, 32);
            this.CtrlPanel.Name = "CtrlPanel";
            this.CtrlPanel.Size = new System.Drawing.Size(476, 468);
            this.CtrlPanel.TabIndex = 2;
            // 
            // CtrlTBType
            // 
            this.CtrlTBType.Location = new System.Drawing.Point(345, 38);
            this.CtrlTBType.Name = "CtrlTBType";
            this.CtrlTBType.ReadOnly = true;
            this.CtrlTBType.Size = new System.Drawing.Size(128, 20);
            this.CtrlTBType.TabIndex = 8;
            // 
            // CtrlLblType
            // 
            this.CtrlLblType.AutoSize = true;
            this.CtrlLblType.Location = new System.Drawing.Point(296, 41);
            this.CtrlLblType.Name = "CtrlLblType";
            this.CtrlLblType.Size = new System.Drawing.Size(32, 13);
            this.CtrlLblType.TabIndex = 7;
            this.CtrlLblType.Text = "Тип: ";
            // 
            // CtrlTBKitchen
            // 
            this.CtrlTBKitchen.Location = new System.Drawing.Point(64, 38);
            this.CtrlTBKitchen.Name = "CtrlTBKitchen";
            this.CtrlTBKitchen.ReadOnly = true;
            this.CtrlTBKitchen.Size = new System.Drawing.Size(128, 20);
            this.CtrlTBKitchen.TabIndex = 6;
            // 
            // CtrlLblKitchen
            // 
            this.CtrlLblKitchen.AutoSize = true;
            this.CtrlLblKitchen.Location = new System.Drawing.Point(3, 41);
            this.CtrlLblKitchen.Name = "CtrlLblKitchen";
            this.CtrlLblKitchen.Size = new System.Drawing.Size(42, 13);
            this.CtrlLblKitchen.TabIndex = 5;
            this.CtrlLblKitchen.Text = "Кухня: ";
            // 
            // CtrlRecipeTabs
            // 
            this.CtrlRecipeTabs.Controls.Add(this.CtrlTPRecipeText);
            this.CtrlRecipeTabs.Controls.Add(this.CtrlTPRecipeIngreds);
            this.CtrlRecipeTabs.Controls.Add(this.CtrlTPRecipeDevices);
            this.CtrlRecipeTabs.Location = new System.Drawing.Point(6, 64);
            this.CtrlRecipeTabs.Name = "CtrlRecipeTabs";
            this.CtrlRecipeTabs.SelectedIndex = 0;
            this.CtrlRecipeTabs.Size = new System.Drawing.Size(467, 401);
            this.CtrlRecipeTabs.TabIndex = 4;
            // 
            // CtrlTPRecipeText
            // 
            this.CtrlTPRecipeText.Controls.Add(this.CtrlTBText);
            this.CtrlTPRecipeText.Location = new System.Drawing.Point(4, 22);
            this.CtrlTPRecipeText.Name = "CtrlTPRecipeText";
            this.CtrlTPRecipeText.Padding = new System.Windows.Forms.Padding(3);
            this.CtrlTPRecipeText.Size = new System.Drawing.Size(459, 375);
            this.CtrlTPRecipeText.TabIndex = 0;
            this.CtrlTPRecipeText.Text = "Текст рецепта";
            this.CtrlTPRecipeText.UseVisualStyleBackColor = true;
            // 
            // CtrlTBText
            // 
            this.CtrlTBText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlTBText.Location = new System.Drawing.Point(3, 3);
            this.CtrlTBText.Multiline = true;
            this.CtrlTBText.Name = "CtrlTBText";
            this.CtrlTBText.ReadOnly = true;
            this.CtrlTBText.Size = new System.Drawing.Size(453, 369);
            this.CtrlTBText.TabIndex = 0;
            // 
            // CtrlTPRecipeIngreds
            // 
            this.CtrlTPRecipeIngreds.Controls.Add(this.CtrlDGVIngreds);
            this.CtrlTPRecipeIngreds.Location = new System.Drawing.Point(4, 22);
            this.CtrlTPRecipeIngreds.Name = "CtrlTPRecipeIngreds";
            this.CtrlTPRecipeIngreds.Padding = new System.Windows.Forms.Padding(3);
            this.CtrlTPRecipeIngreds.Size = new System.Drawing.Size(459, 375);
            this.CtrlTPRecipeIngreds.TabIndex = 1;
            this.CtrlTPRecipeIngreds.Text = "Список ингредиентов";
            this.CtrlTPRecipeIngreds.UseVisualStyleBackColor = true;
            // 
            // CtrlDGVIngreds
            // 
            this.CtrlDGVIngreds.AllowUserToAddRows = false;
            this.CtrlDGVIngreds.AllowUserToDeleteRows = false;
            this.CtrlDGVIngreds.AllowUserToResizeColumns = false;
            this.CtrlDGVIngreds.AllowUserToResizeRows = false;
            this.CtrlDGVIngreds.AutoGenerateColumns = false;
            this.CtrlDGVIngreds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CtrlDGVIngreds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlDGVIngreds.DataSource = this.CtrlBindSourceIngreds;
            this.CtrlDGVIngreds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlDGVIngreds.Location = new System.Drawing.Point(3, 3);
            this.CtrlDGVIngreds.Name = "CtrlDGVIngreds";
            this.CtrlDGVIngreds.ReadOnly = true;
            this.CtrlDGVIngreds.RowHeadersVisible = false;
            this.CtrlDGVIngreds.Size = new System.Drawing.Size(453, 369);
            this.CtrlDGVIngreds.TabIndex = 0;
            // 
            // CtrlTPRecipeDevices
            // 
            this.CtrlTPRecipeDevices.Controls.Add(this.CtrlDGVDevices);
            this.CtrlTPRecipeDevices.Location = new System.Drawing.Point(4, 22);
            this.CtrlTPRecipeDevices.Name = "CtrlTPRecipeDevices";
            this.CtrlTPRecipeDevices.Size = new System.Drawing.Size(459, 375);
            this.CtrlTPRecipeDevices.TabIndex = 2;
            this.CtrlTPRecipeDevices.Text = "Устройства";
            this.CtrlTPRecipeDevices.UseVisualStyleBackColor = true;
            // 
            // CtrlDGVDevices
            // 
            this.CtrlDGVDevices.AllowUserToAddRows = false;
            this.CtrlDGVDevices.AllowUserToDeleteRows = false;
            this.CtrlDGVDevices.AllowUserToResizeColumns = false;
            this.CtrlDGVDevices.AutoGenerateColumns = false;
            this.CtrlDGVDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CtrlDGVDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlDGVDevices.ColumnHeadersVisible = false;
            this.CtrlDGVDevices.DataSource = this.CtrlBindSourceDevices;
            this.CtrlDGVDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlDGVDevices.Location = new System.Drawing.Point(0, 0);
            this.CtrlDGVDevices.Name = "CtrlDGVDevices";
            this.CtrlDGVDevices.ReadOnly = true;
            this.CtrlDGVDevices.RowHeadersVisible = false;
            this.CtrlDGVDevices.Size = new System.Drawing.Size(459, 375);
            this.CtrlDGVDevices.TabIndex = 0;
            // 
            // CtrlTBLink
            // 
            this.CtrlTBLink.Location = new System.Drawing.Point(64, 3);
            this.CtrlTBLink.Name = "CtrlTBLink";
            this.CtrlTBLink.ReadOnly = true;
            this.CtrlTBLink.Size = new System.Drawing.Size(409, 20);
            this.CtrlTBLink.TabIndex = 2;
            // 
            // CtrlLblLink
            // 
            this.CtrlLblLink.AutoSize = true;
            this.CtrlLblLink.Location = new System.Drawing.Point(3, 6);
            this.CtrlLblLink.Name = "CtrlLblLink";
            this.CtrlLblLink.Size = new System.Drawing.Size(52, 13);
            this.CtrlLblLink.TabIndex = 1;
            this.CtrlLblLink.Text = "Ссылка: ";
            // 
            // CtrlTCMain
            // 
            this.CtrlTCMain.Controls.Add(this.CtrlTabView);
            this.CtrlTCMain.Controls.Add(this.CtrlTabEdit);
            this.CtrlTCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlTCMain.Location = new System.Drawing.Point(0, 0);
            this.CtrlTCMain.Name = "CtrlTCMain";
            this.CtrlTCMain.SelectedIndex = 0;
            this.CtrlTCMain.Size = new System.Drawing.Size(756, 529);
            this.CtrlTCMain.TabIndex = 3;
            // 
            // CtrlTabView
            // 
            this.CtrlTabView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CtrlTabView.Controls.Add(this.CtrlPanel);
            this.CtrlTabView.Controls.Add(this.CtrlButReload);
            this.CtrlTabView.Controls.Add(this.CtrlDGVNames);
            this.CtrlTabView.ForeColor = System.Drawing.Color.Black;
            this.CtrlTabView.Location = new System.Drawing.Point(4, 22);
            this.CtrlTabView.Name = "CtrlTabView";
            this.CtrlTabView.Padding = new System.Windows.Forms.Padding(3);
            this.CtrlTabView.Size = new System.Drawing.Size(748, 503);
            this.CtrlTabView.TabIndex = 0;
            this.CtrlTabView.Text = "Книга рецептов";
            // 
            // CtrlTabEdit
            // 
            this.CtrlTabEdit.BackColor = System.Drawing.SystemColors.Control;
            this.CtrlTabEdit.Controls.Add(this.CtrlTCEdits);
            this.CtrlTabEdit.Location = new System.Drawing.Point(4, 22);
            this.CtrlTabEdit.Name = "CtrlTabEdit";
            this.CtrlTabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.CtrlTabEdit.Size = new System.Drawing.Size(748, 503);
            this.CtrlTabEdit.TabIndex = 1;
            this.CtrlTabEdit.Text = "Редактор";
            // 
            // CtrlTCEdits
            // 
            this.CtrlTCEdits.Controls.Add(this.CtrlTPRecipeAdder);
            this.CtrlTCEdits.Controls.Add(this.CtrlTPDevices);
            this.CtrlTCEdits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlTCEdits.Location = new System.Drawing.Point(3, 3);
            this.CtrlTCEdits.Name = "CtrlTCEdits";
            this.CtrlTCEdits.SelectedIndex = 0;
            this.CtrlTCEdits.Size = new System.Drawing.Size(742, 497);
            this.CtrlTCEdits.TabIndex = 0;
            // 
            // CtrlTPRecipeAdder
            // 
            this.CtrlTPRecipeAdder.Controls.Add(this.groupBox1);
            this.CtrlTPRecipeAdder.Controls.Add(this.CtrlLblRRecipes);
            this.CtrlTPRecipeAdder.Controls.Add(this.CtrlDGVRRecipes);
            this.CtrlTPRecipeAdder.Location = new System.Drawing.Point(4, 22);
            this.CtrlTPRecipeAdder.Name = "CtrlTPRecipeAdder";
            this.CtrlTPRecipeAdder.Padding = new System.Windows.Forms.Padding(3);
            this.CtrlTPRecipeAdder.Size = new System.Drawing.Size(734, 471);
            this.CtrlTPRecipeAdder.TabIndex = 0;
            this.CtrlTPRecipeAdder.Text = "Добавление рецепта";
            this.CtrlTPRecipeAdder.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CtrlLblRIngredients);
            this.groupBox1.Controls.Add(this.CtrlDGVRIngreds);
            this.groupBox1.Controls.Add(this.CtrlBtnRAdd);
            this.groupBox1.Controls.Add(this.CtrlLBTypes);
            this.groupBox1.Controls.Add(this.CtrlLblRType);
            this.groupBox1.Controls.Add(this.CtrlLBDevices);
            this.groupBox1.Controls.Add(this.CtrlLblRDevice);
            this.groupBox1.Controls.Add(this.CtrlLBKitchens);
            this.groupBox1.Controls.Add(this.CtrlLblRKitchen);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.CtrlLblRText);
            this.groupBox1.Controls.Add(this.CtrlLblRLink);
            this.groupBox1.Controls.Add(this.CtrlLblRName);
            this.groupBox1.Location = new System.Drawing.Point(212, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 459);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // CtrlDGVRIngreds
            // 
            this.CtrlDGVRIngreds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CtrlDGVRIngreds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlDGVRIngreds.ColumnHeadersVisible = false;
            this.CtrlDGVRIngreds.Location = new System.Drawing.Point(283, 112);
            this.CtrlDGVRIngreds.Name = "CtrlDGVRIngreds";
            this.CtrlDGVRIngreds.RowHeadersVisible = false;
            this.CtrlDGVRIngreds.Size = new System.Drawing.Size(219, 296);
            this.CtrlDGVRIngreds.TabIndex = 13;
            // 
            // CtrlBtnRAdd
            // 
            this.CtrlBtnRAdd.Location = new System.Drawing.Point(350, 430);
            this.CtrlBtnRAdd.Name = "CtrlBtnRAdd";
            this.CtrlBtnRAdd.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnRAdd.TabIndex = 12;
            this.CtrlBtnRAdd.Text = "Добавить";
            this.CtrlBtnRAdd.UseVisualStyleBackColor = true;
            // 
            // CtrlLBTypes
            // 
            this.CtrlLBTypes.FormattingEnabled = true;
            this.CtrlLBTypes.Location = new System.Drawing.Point(167, 358);
            this.CtrlLBTypes.Name = "CtrlLBTypes";
            this.CtrlLBTypes.Size = new System.Drawing.Size(95, 95);
            this.CtrlLBTypes.TabIndex = 11;
            // 
            // CtrlLblRType
            // 
            this.CtrlLblRType.AutoSize = true;
            this.CtrlLblRType.Location = new System.Drawing.Point(164, 342);
            this.CtrlLblRType.Name = "CtrlLblRType";
            this.CtrlLblRType.Size = new System.Drawing.Size(67, 13);
            this.CtrlLblRType.TabIndex = 10;
            this.CtrlLblRType.Text = "Тип блюда: ";
            // 
            // CtrlLBDevices
            // 
            this.CtrlLBDevices.DataSource = this.CtrlBindSourceDevices;
            this.CtrlLBDevices.FormattingEnabled = true;
            this.CtrlLBDevices.Location = new System.Drawing.Point(167, 236);
            this.CtrlLBDevices.Name = "CtrlLBDevices";
            this.CtrlLBDevices.Size = new System.Drawing.Size(95, 95);
            this.CtrlLBDevices.TabIndex = 9;
            // 
            // CtrlLblRDevice
            // 
            this.CtrlLblRDevice.AutoSize = true;
            this.CtrlLblRDevice.Location = new System.Drawing.Point(164, 220);
            this.CtrlLblRDevice.Name = "CtrlLblRDevice";
            this.CtrlLblRDevice.Size = new System.Drawing.Size(73, 13);
            this.CtrlLblRDevice.TabIndex = 8;
            this.CtrlLblRDevice.Text = "Устройство: ";
            // 
            // CtrlLBKitchens
            // 
            this.CtrlLBKitchens.FormattingEnabled = true;
            this.CtrlLBKitchens.Location = new System.Drawing.Point(167, 112);
            this.CtrlLBKitchens.Name = "CtrlLBKitchens";
            this.CtrlLBKitchens.Size = new System.Drawing.Size(95, 95);
            this.CtrlLBKitchens.TabIndex = 7;
            // 
            // CtrlLblRKitchen
            // 
            this.CtrlLblRKitchen.AutoSize = true;
            this.CtrlLblRKitchen.Location = new System.Drawing.Point(164, 96);
            this.CtrlLblRKitchen.Name = "CtrlLblRKitchen";
            this.CtrlLblRKitchen.Size = new System.Drawing.Size(42, 13);
            this.CtrlLblRKitchen.TabIndex = 6;
            this.CtrlLblRKitchen.Text = "Кухня: ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(9, 112);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(152, 341);
            this.textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(75, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(263, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 20);
            this.textBox1.TabIndex = 3;
            // 
            // CtrlLblRText
            // 
            this.CtrlLblRText.AutoSize = true;
            this.CtrlLblRText.Location = new System.Drawing.Point(6, 96);
            this.CtrlLblRText.Name = "CtrlLblRText";
            this.CtrlLblRText.Size = new System.Drawing.Size(43, 13);
            this.CtrlLblRText.TabIndex = 2;
            this.CtrlLblRText.Text = "Текст: ";
            // 
            // CtrlLblRLink
            // 
            this.CtrlLblRLink.AutoSize = true;
            this.CtrlLblRLink.Location = new System.Drawing.Point(6, 58);
            this.CtrlLblRLink.Name = "CtrlLblRLink";
            this.CtrlLblRLink.Size = new System.Drawing.Size(52, 13);
            this.CtrlLblRLink.TabIndex = 1;
            this.CtrlLblRLink.Text = "Ссылка: ";
            // 
            // CtrlLblRName
            // 
            this.CtrlLblRName.AutoSize = true;
            this.CtrlLblRName.Location = new System.Drawing.Point(6, 30);
            this.CtrlLblRName.Name = "CtrlLblRName";
            this.CtrlLblRName.Size = new System.Drawing.Size(63, 13);
            this.CtrlLblRName.TabIndex = 0;
            this.CtrlLblRName.Text = "Название: ";
            // 
            // CtrlLblRRecipes
            // 
            this.CtrlLblRRecipes.AutoSize = true;
            this.CtrlLblRRecipes.Location = new System.Drawing.Point(6, 3);
            this.CtrlLblRRecipes.Name = "CtrlLblRRecipes";
            this.CtrlLblRRecipes.Size = new System.Drawing.Size(116, 13);
            this.CtrlLblRRecipes.TabIndex = 3;
            this.CtrlLblRRecipes.Text = "Имеющиеся рецепты";
            // 
            // CtrlDGVRRecipes
            // 
            this.CtrlDGVRRecipes.AllowUserToAddRows = false;
            this.CtrlDGVRRecipes.AllowUserToDeleteRows = false;
            this.CtrlDGVRRecipes.AllowUserToResizeColumns = false;
            this.CtrlDGVRRecipes.AllowUserToResizeRows = false;
            this.CtrlDGVRRecipes.AutoGenerateColumns = false;
            this.CtrlDGVRRecipes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CtrlDGVRRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlDGVRRecipes.ColumnHeadersVisible = false;
            this.CtrlDGVRRecipes.DataSource = this.CtrlBindSourceNames;
            this.CtrlDGVRRecipes.Location = new System.Drawing.Point(9, 19);
            this.CtrlDGVRRecipes.MultiSelect = false;
            this.CtrlDGVRRecipes.Name = "CtrlDGVRRecipes";
            this.CtrlDGVRRecipes.ReadOnly = true;
            this.CtrlDGVRRecipes.RowHeadersVisible = false;
            this.CtrlDGVRRecipes.RowHeadersWidth = 18;
            this.CtrlDGVRRecipes.Size = new System.Drawing.Size(197, 446);
            this.CtrlDGVRRecipes.TabIndex = 2;
            // 
            // CtrlTPDevices
            // 
            this.CtrlTPDevices.Controls.Add(this.CtrlGrBRTablesChoice);
            this.CtrlTPDevices.Controls.Add(this.CtrlGrBRAdder);
            this.CtrlTPDevices.Controls.Add(this.CtrlLblTableText);
            this.CtrlTPDevices.Controls.Add(this.CtrlDGVRUniv);
            this.CtrlTPDevices.Location = new System.Drawing.Point(4, 22);
            this.CtrlTPDevices.Name = "CtrlTPDevices";
            this.CtrlTPDevices.Padding = new System.Windows.Forms.Padding(3);
            this.CtrlTPDevices.Size = new System.Drawing.Size(734, 471);
            this.CtrlTPDevices.TabIndex = 1;
            this.CtrlTPDevices.Text = "Редактор";
            this.CtrlTPDevices.UseVisualStyleBackColor = true;
            // 
            // CtrlGrBRTablesChoice
            // 
            this.CtrlGrBRTablesChoice.Controls.Add(this.CtrlRBTypes);
            this.CtrlGrBRTablesChoice.Controls.Add(this.CtrlRBDevices);
            this.CtrlGrBRTablesChoice.Controls.Add(this.CtrlRBKitchens);
            this.CtrlGrBRTablesChoice.Location = new System.Drawing.Point(182, 50);
            this.CtrlGrBRTablesChoice.Name = "CtrlGrBRTablesChoice";
            this.CtrlGrBRTablesChoice.Size = new System.Drawing.Size(216, 100);
            this.CtrlGrBRTablesChoice.TabIndex = 8;
            this.CtrlGrBRTablesChoice.TabStop = false;
            this.CtrlGrBRTablesChoice.Tag = "-1";
            this.CtrlGrBRTablesChoice.Text = "Выбор";
            // 
            // CtrlRBTypes
            // 
            this.CtrlRBTypes.AutoSize = true;
            this.CtrlRBTypes.Location = new System.Drawing.Point(6, 43);
            this.CtrlRBTypes.Name = "CtrlRBTypes";
            this.CtrlRBTypes.Size = new System.Drawing.Size(81, 17);
            this.CtrlRBTypes.TabIndex = 6;
            this.CtrlRBTypes.Tag = "6";
            this.CtrlRBTypes.Text = "Типы блюд";
            this.CtrlRBTypes.UseVisualStyleBackColor = true;
            this.CtrlRBTypes.CheckedChanged += new System.EventHandler(this.CtrlRB_CheckedChanged);
            // 
            // CtrlRBDevices
            // 
            this.CtrlRBDevices.AutoSize = true;
            this.CtrlRBDevices.Location = new System.Drawing.Point(6, 66);
            this.CtrlRBDevices.Name = "CtrlRBDevices";
            this.CtrlRBDevices.Size = new System.Drawing.Size(85, 17);
            this.CtrlRBDevices.TabIndex = 7;
            this.CtrlRBDevices.Tag = "5";
            this.CtrlRBDevices.Text = "Устройства";
            this.CtrlRBDevices.UseVisualStyleBackColor = true;
            this.CtrlRBDevices.CheckedChanged += new System.EventHandler(this.CtrlRB_CheckedChanged);
            // 
            // CtrlRBKitchens
            // 
            this.CtrlRBKitchens.AutoSize = true;
            this.CtrlRBKitchens.Location = new System.Drawing.Point(6, 20);
            this.CtrlRBKitchens.Name = "CtrlRBKitchens";
            this.CtrlRBKitchens.Size = new System.Drawing.Size(54, 17);
            this.CtrlRBKitchens.TabIndex = 5;
            this.CtrlRBKitchens.Tag = "4";
            this.CtrlRBKitchens.Text = "Кухни";
            this.CtrlRBKitchens.UseVisualStyleBackColor = true;
            this.CtrlRBKitchens.CheckedChanged += new System.EventHandler(this.CtrlRB_CheckedChanged);
            // 
            // CtrlGrBRAdder
            // 
            this.CtrlGrBRAdder.Controls.Add(this.CtrlBtnTPDevicesAdd);
            this.CtrlGrBRAdder.Controls.Add(this.CtrlTbTPName);
            this.CtrlGrBRAdder.Controls.Add(this.CtrlLblTPDevicesName);
            this.CtrlGrBRAdder.Enabled = false;
            this.CtrlGrBRAdder.Location = new System.Drawing.Point(182, 176);
            this.CtrlGrBRAdder.Name = "CtrlGrBRAdder";
            this.CtrlGrBRAdder.Size = new System.Drawing.Size(216, 117);
            this.CtrlGrBRAdder.TabIndex = 4;
            this.CtrlGrBRAdder.TabStop = false;
            this.CtrlGrBRAdder.Text = "Добавление";
            // 
            // CtrlBtnTPDevicesAdd
            // 
            this.CtrlBtnTPDevicesAdd.Location = new System.Drawing.Point(9, 83);
            this.CtrlBtnTPDevicesAdd.Name = "CtrlBtnTPDevicesAdd";
            this.CtrlBtnTPDevicesAdd.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnTPDevicesAdd.TabIndex = 2;
            this.CtrlBtnTPDevicesAdd.Text = "Добавить";
            this.CtrlBtnTPDevicesAdd.UseVisualStyleBackColor = true;
            this.CtrlBtnTPDevicesAdd.Click += new System.EventHandler(this.CtrlBtnTPDevicesAdd_Click);
            // 
            // CtrlTbTPName
            // 
            this.CtrlTbTPName.Location = new System.Drawing.Point(69, 31);
            this.CtrlTbTPName.Name = "CtrlTbTPName";
            this.CtrlTbTPName.Size = new System.Drawing.Size(138, 20);
            this.CtrlTbTPName.TabIndex = 1;
            // 
            // CtrlLblTPDevicesName
            // 
            this.CtrlLblTPDevicesName.AutoSize = true;
            this.CtrlLblTPDevicesName.Location = new System.Drawing.Point(6, 34);
            this.CtrlLblTPDevicesName.Name = "CtrlLblTPDevicesName";
            this.CtrlLblTPDevicesName.Size = new System.Drawing.Size(60, 13);
            this.CtrlLblTPDevicesName.TabIndex = 0;
            this.CtrlLblTPDevicesName.Text = "Название:";
            // 
            // CtrlLblTableText
            // 
            this.CtrlLblTableText.AutoSize = true;
            this.CtrlLblTableText.Location = new System.Drawing.Point(7, 13);
            this.CtrlLblTableText.Name = "CtrlLblTableText";
            this.CtrlLblTableText.Size = new System.Drawing.Size(112, 13);
            this.CtrlLblTableText.TabIndex = 3;
            this.CtrlLblTableText.Text = "<Выберите таблицу>";
            // 
            // CtrlDGVRUniv
            // 
            this.CtrlDGVRUniv.AllowUserToAddRows = false;
            this.CtrlDGVRUniv.AllowUserToDeleteRows = false;
            this.CtrlDGVRUniv.AllowUserToResizeColumns = false;
            this.CtrlDGVRUniv.AllowUserToResizeRows = false;
            this.CtrlDGVRUniv.AutoGenerateColumns = false;
            this.CtrlDGVRUniv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CtrlDGVRUniv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlDGVRUniv.ColumnHeadersVisible = false;
            this.CtrlDGVRUniv.DataSource = this.CtrlBindSourceUniv;
            this.CtrlDGVRUniv.Location = new System.Drawing.Point(10, 50);
            this.CtrlDGVRUniv.MultiSelect = false;
            this.CtrlDGVRUniv.Name = "CtrlDGVRUniv";
            this.CtrlDGVRUniv.ReadOnly = true;
            this.CtrlDGVRUniv.RowHeadersVisible = false;
            this.CtrlDGVRUniv.RowHeadersWidth = 18;
            this.CtrlDGVRUniv.Size = new System.Drawing.Size(155, 415);
            this.CtrlDGVRUniv.TabIndex = 2;
            // 
            // CtrlLblRIngredients
            // 
            this.CtrlLblRIngredients.AutoSize = true;
            this.CtrlLblRIngredients.Location = new System.Drawing.Point(280, 96);
            this.CtrlLblRIngredients.Name = "CtrlLblRIngredients";
            this.CtrlLblRIngredients.Size = new System.Drawing.Size(81, 13);
            this.CtrlLblRIngredients.TabIndex = 14;
            this.CtrlLblRIngredients.Text = "Ингредиенты: ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 529);
            this.Controls.Add(this.CtrlTCMain);
            this.Name = "FormMain";
            this.Text = "Книга рецептов";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CtrlBindSourceNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVNames)).EndInit();
            this.CtrlPanel.ResumeLayout(false);
            this.CtrlPanel.PerformLayout();
            this.CtrlRecipeTabs.ResumeLayout(false);
            this.CtrlTPRecipeText.ResumeLayout(false);
            this.CtrlTPRecipeText.PerformLayout();
            this.CtrlTPRecipeIngreds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVIngreds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlBindSourceIngreds)).EndInit();
            this.CtrlTPRecipeDevices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlBindSourceDevices)).EndInit();
            this.CtrlTCMain.ResumeLayout(false);
            this.CtrlTabView.ResumeLayout(false);
            this.CtrlTabEdit.ResumeLayout(false);
            this.CtrlTCEdits.ResumeLayout(false);
            this.CtrlTPRecipeAdder.ResumeLayout(false);
            this.CtrlTPRecipeAdder.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVRIngreds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVRRecipes)).EndInit();
            this.CtrlTPDevices.ResumeLayout(false);
            this.CtrlTPDevices.PerformLayout();
            this.CtrlGrBRTablesChoice.ResumeLayout(false);
            this.CtrlGrBRTablesChoice.PerformLayout();
            this.CtrlGrBRAdder.ResumeLayout(false);
            this.CtrlGrBRAdder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGVRUniv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlBindSourceUniv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource CtrlBindSourceNames;
        private DBLayer.RecipeDataSet recipeDataSet;
        private System.Windows.Forms.Button CtrlButReload;
        private System.Windows.Forms.DataGridView CtrlDGVNames;
        private System.Windows.Forms.Panel CtrlPanel;
        private System.Windows.Forms.TabControl CtrlRecipeTabs;
        private System.Windows.Forms.TabPage CtrlTPRecipeText;
        private System.Windows.Forms.TextBox CtrlTBText;
        private System.Windows.Forms.TabPage CtrlTPRecipeIngreds;
        private System.Windows.Forms.DataGridView CtrlDGVIngreds;
        private System.Windows.Forms.TextBox CtrlTBLink;
        private System.Windows.Forms.Label CtrlLblLink;
        private System.Windows.Forms.BindingSource CtrlBindSourceIngreds;
        private System.Windows.Forms.TextBox CtrlTBKitchen;
        private System.Windows.Forms.Label CtrlLblKitchen;
        private System.Windows.Forms.TabPage CtrlTPRecipeDevices;
        private System.Windows.Forms.DataGridView CtrlDGVDevices;
        private System.Windows.Forms.BindingSource CtrlBindSourceDevices;
        private System.Windows.Forms.TextBox CtrlTBType;
        private System.Windows.Forms.Label CtrlLblType;
        private System.Windows.Forms.TabControl CtrlTCMain;
        private System.Windows.Forms.TabPage CtrlTabView;
        private System.Windows.Forms.TabPage CtrlTabEdit;
        private System.Windows.Forms.TabControl CtrlTCEdits;
        private System.Windows.Forms.TabPage CtrlTPRecipeAdder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label CtrlLblRRecipes;
        private System.Windows.Forms.DataGridView CtrlDGVRRecipes;
        private System.Windows.Forms.TabPage CtrlTPDevices;
        private System.Windows.Forms.GroupBox CtrlGrBRTablesChoice;
        private System.Windows.Forms.RadioButton CtrlRBTypes;
        private System.Windows.Forms.RadioButton CtrlRBDevices;
        private System.Windows.Forms.RadioButton CtrlRBKitchens;
        private System.Windows.Forms.GroupBox CtrlGrBRAdder;
        private System.Windows.Forms.Button CtrlBtnTPDevicesAdd;
        private System.Windows.Forms.TextBox CtrlTbTPName;
        private System.Windows.Forms.Label CtrlLblTPDevicesName;
        private System.Windows.Forms.Label CtrlLblTableText;
        private System.Windows.Forms.DataGridView CtrlDGVRUniv;
        private System.Windows.Forms.Button CtrlBtnRAdd;
        private System.Windows.Forms.ListBox CtrlLBTypes;
        private System.Windows.Forms.Label CtrlLblRType;
        private System.Windows.Forms.ListBox CtrlLBDevices;
        private System.Windows.Forms.Label CtrlLblRDevice;
        private System.Windows.Forms.ListBox CtrlLBKitchens;
        private System.Windows.Forms.Label CtrlLblRKitchen;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label CtrlLblRText;
        private System.Windows.Forms.Label CtrlLblRLink;
        private System.Windows.Forms.Label CtrlLblRName;
        private System.Windows.Forms.DataGridView CtrlDGVRIngreds;
        private System.Windows.Forms.BindingSource CtrlBindSourceUniv;
        private System.Windows.Forms.Label CtrlLblRIngredients;
    }
}

