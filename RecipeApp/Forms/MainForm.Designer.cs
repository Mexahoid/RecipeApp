namespace RecipeApp.Forms
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
            this.CtrlTPView = new System.Windows.Forms.TabPage();
            this.CtrlBtnReject = new System.Windows.Forms.Button();
            this.CtrlBtnAccept = new System.Windows.Forms.Button();
            this.CtrlRBEdit = new System.Windows.Forms.RadioButton();
            this.CtrlRBSelect = new System.Windows.Forms.RadioButton();
            this.CtrlViewPanel = new System.Windows.Forms.Panel();
            this.CtrlViewTBType = new System.Windows.Forms.TextBox();
            this.CtrlViewLblType = new System.Windows.Forms.Label();
            this.CtrlViewTCMisc = new System.Windows.Forms.TabControl();
            this.CtrlViewTPText = new System.Windows.Forms.TabPage();
            this.CtrlViewTBText = new System.Windows.Forms.TextBox();
            this.CtrlViewTPIngreds = new System.Windows.Forms.TabPage();
            this.CtrlViewDGVIngreds = new System.Windows.Forms.DataGridView();
            this.CtrlViewTPDevices = new System.Windows.Forms.TabPage();
            this.CtrlViewDGVDevices = new System.Windows.Forms.DataGridView();
            this.CtrlViewLblKitchen = new System.Windows.Forms.Label();
            this.CtrlViewTBLink = new System.Windows.Forms.TextBox();
            this.CtrlViewLblLink = new System.Windows.Forms.Label();
            this.CtrlViewTBKitchen = new System.Windows.Forms.TextBox();
            this.CBKitchen = new System.Windows.Forms.ComboBox();
            this.CtrlViewDGVNames = new System.Windows.Forms.DataGridView();
            this.CtrlTCMain = new System.Windows.Forms.TabControl();
            this.CBType = new System.Windows.Forms.ComboBox();
            this.CtrlTPView.SuspendLayout();
            this.CtrlViewPanel.SuspendLayout();
            this.CtrlViewTCMisc.SuspendLayout();
            this.CtrlViewTPText.SuspendLayout();
            this.CtrlViewTPIngreds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlViewDGVIngreds)).BeginInit();
            this.CtrlViewTPDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlViewDGVDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlViewDGVNames)).BeginInit();
            this.CtrlTCMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtrlTPView
            // 
            this.CtrlTPView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CtrlTPView.Controls.Add(this.CtrlBtnReject);
            this.CtrlTPView.Controls.Add(this.CtrlBtnAccept);
            this.CtrlTPView.Controls.Add(this.CtrlRBEdit);
            this.CtrlTPView.Controls.Add(this.CtrlRBSelect);
            this.CtrlTPView.Controls.Add(this.CtrlViewPanel);
            this.CtrlTPView.Controls.Add(this.CtrlViewDGVNames);
            this.CtrlTPView.ForeColor = System.Drawing.Color.Black;
            this.CtrlTPView.Location = new System.Drawing.Point(4, 22);
            this.CtrlTPView.Name = "CtrlTPView";
            this.CtrlTPView.Padding = new System.Windows.Forms.Padding(3);
            this.CtrlTPView.Size = new System.Drawing.Size(748, 503);
            this.CtrlTPView.TabIndex = 0;
            this.CtrlTPView.Text = "Книга рецептов";
            // 
            // CtrlBtnReject
            // 
            this.CtrlBtnReject.Enabled = false;
            this.CtrlBtnReject.Location = new System.Drawing.Point(188, 472);
            this.CtrlBtnReject.Name = "CtrlBtnReject";
            this.CtrlBtnReject.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnReject.TabIndex = 8;
            this.CtrlBtnReject.Text = "Отменить";
            this.CtrlBtnReject.UseVisualStyleBackColor = true;
            // 
            // CtrlBtnAccept
            // 
            this.CtrlBtnAccept.Enabled = false;
            this.CtrlBtnAccept.Location = new System.Drawing.Point(8, 472);
            this.CtrlBtnAccept.Name = "CtrlBtnAccept";
            this.CtrlBtnAccept.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnAccept.TabIndex = 7;
            this.CtrlBtnAccept.Text = "Принять";
            this.CtrlBtnAccept.UseVisualStyleBackColor = true;
            // 
            // CtrlRBEdit
            // 
            this.CtrlRBEdit.AutoSize = true;
            this.CtrlRBEdit.Location = new System.Drawing.Point(8, 24);
            this.CtrlRBEdit.Name = "CtrlRBEdit";
            this.CtrlRBEdit.Size = new System.Drawing.Size(184, 17);
            this.CtrlRBEdit.TabIndex = 6;
            this.CtrlRBEdit.Text = "Режим изменения/добавления";
            this.CtrlRBEdit.UseVisualStyleBackColor = true;
            // 
            // CtrlRBSelect
            // 
            this.CtrlRBSelect.AutoSize = true;
            this.CtrlRBSelect.Checked = true;
            this.CtrlRBSelect.Location = new System.Drawing.Point(8, 6);
            this.CtrlRBSelect.Name = "CtrlRBSelect";
            this.CtrlRBSelect.Size = new System.Drawing.Size(101, 17);
            this.CtrlRBSelect.TabIndex = 5;
            this.CtrlRBSelect.TabStop = true;
            this.CtrlRBSelect.Text = "Режим выбора";
            this.CtrlRBSelect.UseVisualStyleBackColor = true;
            // 
            // CtrlViewPanel
            // 
            this.CtrlViewPanel.Controls.Add(this.CtrlViewTBType);
            this.CtrlViewPanel.Controls.Add(this.CtrlViewLblType);
            this.CtrlViewPanel.Controls.Add(this.CtrlViewTCMisc);
            this.CtrlViewPanel.Controls.Add(this.CtrlViewLblKitchen);
            this.CtrlViewPanel.Controls.Add(this.CtrlViewTBLink);
            this.CtrlViewPanel.Controls.Add(this.CtrlViewLblLink);
            this.CtrlViewPanel.Controls.Add(this.CtrlViewTBKitchen);
            this.CtrlViewPanel.Controls.Add(this.CBKitchen);
            this.CtrlViewPanel.Controls.Add(this.CBType);
            this.CtrlViewPanel.Location = new System.Drawing.Point(269, 6);
            this.CtrlViewPanel.Name = "CtrlViewPanel";
            this.CtrlViewPanel.Size = new System.Drawing.Size(476, 494);
            this.CtrlViewPanel.TabIndex = 2;
            // 
            // CtrlViewTBType
            // 
            this.CtrlViewTBType.Location = new System.Drawing.Point(334, 37);
            this.CtrlViewTBType.Name = "CtrlViewTBType";
            this.CtrlViewTBType.Multiline = true;
            this.CtrlViewTBType.ReadOnly = true;
            this.CtrlViewTBType.Size = new System.Drawing.Size(128, 21);
            this.CtrlViewTBType.TabIndex = 8;
            // 
            // CtrlViewLblType
            // 
            this.CtrlViewLblType.AutoSize = true;
            this.CtrlViewLblType.Location = new System.Drawing.Point(296, 41);
            this.CtrlViewLblType.Name = "CtrlViewLblType";
            this.CtrlViewLblType.Size = new System.Drawing.Size(32, 13);
            this.CtrlViewLblType.TabIndex = 7;
            this.CtrlViewLblType.Text = "Тип: ";
            // 
            // CtrlViewTCMisc
            // 
            this.CtrlViewTCMisc.Controls.Add(this.CtrlViewTPText);
            this.CtrlViewTCMisc.Controls.Add(this.CtrlViewTPIngreds);
            this.CtrlViewTCMisc.Controls.Add(this.CtrlViewTPDevices);
            this.CtrlViewTCMisc.Location = new System.Drawing.Point(6, 89);
            this.CtrlViewTCMisc.Name = "CtrlViewTCMisc";
            this.CtrlViewTCMisc.SelectedIndex = 0;
            this.CtrlViewTCMisc.Size = new System.Drawing.Size(467, 400);
            this.CtrlViewTCMisc.TabIndex = 4;
            // 
            // CtrlViewTPText
            // 
            this.CtrlViewTPText.Controls.Add(this.CtrlViewTBText);
            this.CtrlViewTPText.Location = new System.Drawing.Point(4, 22);
            this.CtrlViewTPText.Name = "CtrlViewTPText";
            this.CtrlViewTPText.Padding = new System.Windows.Forms.Padding(3);
            this.CtrlViewTPText.Size = new System.Drawing.Size(459, 374);
            this.CtrlViewTPText.TabIndex = 0;
            this.CtrlViewTPText.Text = "Текст рецепта";
            this.CtrlViewTPText.UseVisualStyleBackColor = true;
            // 
            // CtrlViewTBText
            // 
            this.CtrlViewTBText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlViewTBText.Location = new System.Drawing.Point(3, 3);
            this.CtrlViewTBText.Multiline = true;
            this.CtrlViewTBText.Name = "CtrlViewTBText";
            this.CtrlViewTBText.ReadOnly = true;
            this.CtrlViewTBText.Size = new System.Drawing.Size(453, 368);
            this.CtrlViewTBText.TabIndex = 0;
            // 
            // CtrlViewTPIngreds
            // 
            this.CtrlViewTPIngreds.Controls.Add(this.CtrlViewDGVIngreds);
            this.CtrlViewTPIngreds.Location = new System.Drawing.Point(4, 22);
            this.CtrlViewTPIngreds.Name = "CtrlViewTPIngreds";
            this.CtrlViewTPIngreds.Padding = new System.Windows.Forms.Padding(3);
            this.CtrlViewTPIngreds.Size = new System.Drawing.Size(459, 374);
            this.CtrlViewTPIngreds.TabIndex = 1;
            this.CtrlViewTPIngreds.Text = "Список ингредиентов";
            this.CtrlViewTPIngreds.UseVisualStyleBackColor = true;
            // 
            // CtrlViewDGVIngreds
            // 
            this.CtrlViewDGVIngreds.AllowUserToAddRows = false;
            this.CtrlViewDGVIngreds.AllowUserToDeleteRows = false;
            this.CtrlViewDGVIngreds.AllowUserToResizeColumns = false;
            this.CtrlViewDGVIngreds.AllowUserToResizeRows = false;
            this.CtrlViewDGVIngreds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlViewDGVIngreds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CtrlViewDGVIngreds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CtrlViewDGVIngreds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlViewDGVIngreds.Location = new System.Drawing.Point(0, 0);
            this.CtrlViewDGVIngreds.Name = "CtrlViewDGVIngreds";
            this.CtrlViewDGVIngreds.ReadOnly = true;
            this.CtrlViewDGVIngreds.RowHeadersVisible = false;
            this.CtrlViewDGVIngreds.Size = new System.Drawing.Size(459, 374);
            this.CtrlViewDGVIngreds.TabIndex = 0;
            // 
            // CtrlViewTPDevices
            // 
            this.CtrlViewTPDevices.Controls.Add(this.CtrlViewDGVDevices);
            this.CtrlViewTPDevices.Location = new System.Drawing.Point(4, 22);
            this.CtrlViewTPDevices.Name = "CtrlViewTPDevices";
            this.CtrlViewTPDevices.Size = new System.Drawing.Size(459, 374);
            this.CtrlViewTPDevices.TabIndex = 2;
            this.CtrlViewTPDevices.Text = "Устройства";
            this.CtrlViewTPDevices.UseVisualStyleBackColor = true;
            // 
            // CtrlViewDGVDevices
            // 
            this.CtrlViewDGVDevices.AllowUserToAddRows = false;
            this.CtrlViewDGVDevices.AllowUserToDeleteRows = false;
            this.CtrlViewDGVDevices.AllowUserToResizeColumns = false;
            this.CtrlViewDGVDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CtrlViewDGVDevices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CtrlViewDGVDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlViewDGVDevices.ColumnHeadersVisible = false;
            this.CtrlViewDGVDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlViewDGVDevices.Location = new System.Drawing.Point(0, 0);
            this.CtrlViewDGVDevices.Name = "CtrlViewDGVDevices";
            this.CtrlViewDGVDevices.ReadOnly = true;
            this.CtrlViewDGVDevices.RowHeadersVisible = false;
            this.CtrlViewDGVDevices.Size = new System.Drawing.Size(459, 374);
            this.CtrlViewDGVDevices.TabIndex = 0;
            // 
            // CtrlViewLblKitchen
            // 
            this.CtrlViewLblKitchen.AutoSize = true;
            this.CtrlViewLblKitchen.Location = new System.Drawing.Point(3, 41);
            this.CtrlViewLblKitchen.Name = "CtrlViewLblKitchen";
            this.CtrlViewLblKitchen.Size = new System.Drawing.Size(42, 13);
            this.CtrlViewLblKitchen.TabIndex = 5;
            this.CtrlViewLblKitchen.Text = "Кухня: ";
            // 
            // CtrlViewTBLink
            // 
            this.CtrlViewTBLink.Location = new System.Drawing.Point(64, 3);
            this.CtrlViewTBLink.Name = "CtrlViewTBLink";
            this.CtrlViewTBLink.ReadOnly = true;
            this.CtrlViewTBLink.Size = new System.Drawing.Size(409, 20);
            this.CtrlViewTBLink.TabIndex = 2;
            // 
            // CtrlViewLblLink
            // 
            this.CtrlViewLblLink.AutoSize = true;
            this.CtrlViewLblLink.Location = new System.Drawing.Point(3, 6);
            this.CtrlViewLblLink.Name = "CtrlViewLblLink";
            this.CtrlViewLblLink.Size = new System.Drawing.Size(52, 13);
            this.CtrlViewLblLink.TabIndex = 1;
            this.CtrlViewLblLink.Text = "Ссылка: ";
            // 
            // CtrlViewTBKitchen
            // 
            this.CtrlViewTBKitchen.Location = new System.Drawing.Point(64, 38);
            this.CtrlViewTBKitchen.Multiline = true;
            this.CtrlViewTBKitchen.Name = "CtrlViewTBKitchen";
            this.CtrlViewTBKitchen.ReadOnly = true;
            this.CtrlViewTBKitchen.Size = new System.Drawing.Size(121, 21);
            this.CtrlViewTBKitchen.TabIndex = 6;
            // 
            // CBKitchen
            // 
            this.CBKitchen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBKitchen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBKitchen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBKitchen.FormattingEnabled = true;
            this.CBKitchen.Location = new System.Drawing.Point(64, 38);
            this.CBKitchen.Name = "CBKitchen";
            this.CBKitchen.Size = new System.Drawing.Size(121, 21);
            this.CBKitchen.TabIndex = 9;
            // 
            // CtrlViewDGVNames
            // 
            this.CtrlViewDGVNames.AllowUserToAddRows = false;
            this.CtrlViewDGVNames.AllowUserToDeleteRows = false;
            this.CtrlViewDGVNames.AllowUserToResizeColumns = false;
            this.CtrlViewDGVNames.AllowUserToResizeRows = false;
            this.CtrlViewDGVNames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CtrlViewDGVNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlViewDGVNames.ColumnHeadersVisible = false;
            this.CtrlViewDGVNames.Location = new System.Drawing.Point(3, 47);
            this.CtrlViewDGVNames.MultiSelect = false;
            this.CtrlViewDGVNames.Name = "CtrlViewDGVNames";
            this.CtrlViewDGVNames.ReadOnly = true;
            this.CtrlViewDGVNames.RowHeadersVisible = false;
            this.CtrlViewDGVNames.RowHeadersWidth = 18;
            this.CtrlViewDGVNames.Size = new System.Drawing.Size(260, 418);
            this.CtrlViewDGVNames.TabIndex = 1;
            // 
            // CtrlTCMain
            // 
            this.CtrlTCMain.Controls.Add(this.CtrlTPView);
            this.CtrlTCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlTCMain.Location = new System.Drawing.Point(0, 0);
            this.CtrlTCMain.Name = "CtrlTCMain";
            this.CtrlTCMain.SelectedIndex = 0;
            this.CtrlTCMain.Size = new System.Drawing.Size(756, 529);
            this.CtrlTCMain.TabIndex = 3;
            // 
            // CBType
            // 
            this.CBType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBType.FormattingEnabled = true;
            this.CBType.Location = new System.Drawing.Point(334, 37);
            this.CBType.Name = "CBType";
            this.CBType.Size = new System.Drawing.Size(128, 21);
            this.CBType.TabIndex = 10;
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
            this.CtrlTPView.ResumeLayout(false);
            this.CtrlTPView.PerformLayout();
            this.CtrlViewPanel.ResumeLayout(false);
            this.CtrlViewPanel.PerformLayout();
            this.CtrlViewTCMisc.ResumeLayout(false);
            this.CtrlViewTPText.ResumeLayout(false);
            this.CtrlViewTPText.PerformLayout();
            this.CtrlViewTPIngreds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CtrlViewDGVIngreds)).EndInit();
            this.CtrlViewTPDevices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CtrlViewDGVDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlViewDGVNames)).EndInit();
            this.CtrlTCMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage CtrlTPView;
        private System.Windows.Forms.Button CtrlBtnReject;
        private System.Windows.Forms.Button CtrlBtnAccept;
        private System.Windows.Forms.RadioButton CtrlRBEdit;
        private System.Windows.Forms.RadioButton CtrlRBSelect;
        private System.Windows.Forms.Panel CtrlViewPanel;
        private System.Windows.Forms.TextBox CtrlViewTBType;
        private System.Windows.Forms.Label CtrlViewLblType;
        private System.Windows.Forms.TabControl CtrlViewTCMisc;
        private System.Windows.Forms.TabPage CtrlViewTPText;
        private System.Windows.Forms.TextBox CtrlViewTBText;
        private System.Windows.Forms.TabPage CtrlViewTPIngreds;
        private System.Windows.Forms.DataGridView CtrlViewDGVIngreds;
        private System.Windows.Forms.TabPage CtrlViewTPDevices;
        private System.Windows.Forms.DataGridView CtrlViewDGVDevices;
        private System.Windows.Forms.Label CtrlViewLblKitchen;
        private System.Windows.Forms.TextBox CtrlViewTBLink;
        private System.Windows.Forms.Label CtrlViewLblLink;
        private System.Windows.Forms.TextBox CtrlViewTBKitchen;
        private System.Windows.Forms.ComboBox CBKitchen;
        private System.Windows.Forms.DataGridView CtrlViewDGVNames;
        private System.Windows.Forms.TabControl CtrlTCMain;
        private System.Windows.Forms.ComboBox CBType;
    }
}

