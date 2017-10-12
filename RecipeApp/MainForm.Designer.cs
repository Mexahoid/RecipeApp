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
            this.recipeDataSet = new RecipeApp.RecipeDataSet();
            this.CtrlButReload = new System.Windows.Forms.Button();
            this.CtrlDGVNames = new System.Windows.Forms.DataGridView();
            this.CtrlPanel = new System.Windows.Forms.Panel();
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
            this.CtrlTBType = new System.Windows.Forms.TextBox();
            this.CtrlLblType = new System.Windows.Forms.Label();
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
            this.CtrlButReload.Location = new System.Drawing.Point(13, 13);
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
            this.CtrlDGVNames.Location = new System.Drawing.Point(13, 42);
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
            this.CtrlPanel.Location = new System.Drawing.Point(352, 42);
            this.CtrlPanel.Name = "CtrlPanel";
            this.CtrlPanel.Size = new System.Drawing.Size(476, 468);
            this.CtrlPanel.TabIndex = 2;
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
            this.CtrlTPRecipeText.Size = new System.Drawing.Size(459, 330);
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
            this.CtrlTBText.Size = new System.Drawing.Size(453, 324);
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
            this.CtrlTPRecipeDevices.Size = new System.Drawing.Size(459, 330);
            this.CtrlTPRecipeDevices.TabIndex = 2;
            this.CtrlTPRecipeDevices.Text = "Устройства";
            this.CtrlTPRecipeDevices.UseVisualStyleBackColor = true;
            // 
            // CtrlDGVDevices
            // 
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
            this.CtrlDGVDevices.Size = new System.Drawing.Size(459, 330);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 522);
            this.Controls.Add(this.CtrlPanel);
            this.Controls.Add(this.CtrlDGVNames);
            this.Controls.Add(this.CtrlButReload);
            this.Name = "FormMain";
            this.Text = "Книга рецептов";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource CtrlBindSourceNames;
        private RecipeDataSet recipeDataSet;
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
    }
}

