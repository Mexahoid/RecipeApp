namespace RecipeApp.Forms
{
    partial class IngredsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CtrlDGV = new System.Windows.Forms.DataGridView();
            this.CtrlNUD = new System.Windows.Forms.NumericUpDown();
            this.CtrlLblAftQty = new System.Windows.Forms.Label();
            this.CtrlTB = new System.Windows.Forms.TextBox();
            this.CtrlLblAftUnits = new System.Windows.Forms.Label();
            this.CtrlBtnOK = new System.Windows.Forms.Button();
            this.CtrlBtnCancel = new System.Windows.Forms.Button();
            this.CtrlLblBef = new System.Windows.Forms.Label();
            this.CtrlLblBefName = new System.Windows.Forms.Label();
            this.CtrlLblBefQty = new System.Windows.Forms.Label();
            this.CtrlLblBefUnits = new System.Windows.Forms.Label();
            this.CtrlLblBefNameValue = new System.Windows.Forms.Label();
            this.CtrlLblBefQtyValue = new System.Windows.Forms.Label();
            this.CtrlLblBefUnitsValue = new System.Windows.Forms.Label();
            this.CtrlLblAft = new System.Windows.Forms.Label();
            this.CtrlLblAftName = new System.Windows.Forms.Label();
            this.CtrlLblAftNameValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlDGV
            // 
            this.CtrlDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlDGV.Location = new System.Drawing.Point(12, 12);
            this.CtrlDGV.Name = "CtrlDGV";
            this.CtrlDGV.Size = new System.Drawing.Size(225, 398);
            this.CtrlDGV.TabIndex = 0;
            this.CtrlDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CtrlDGV_CellClick);
            this.CtrlDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CtrlDGV_CellContentClick);
            // 
            // CtrlNUD
            // 
            this.CtrlNUD.Location = new System.Drawing.Point(420, 148);
            this.CtrlNUD.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.CtrlNUD.Name = "CtrlNUD";
            this.CtrlNUD.Size = new System.Drawing.Size(77, 20);
            this.CtrlNUD.TabIndex = 1;
            // 
            // CtrlLblAftQty
            // 
            this.CtrlLblAftQty.AutoSize = true;
            this.CtrlLblAftQty.Location = new System.Drawing.Point(341, 150);
            this.CtrlLblAftQty.Name = "CtrlLblAftQty";
            this.CtrlLblAftQty.Size = new System.Drawing.Size(69, 13);
            this.CtrlLblAftQty.TabIndex = 2;
            this.CtrlLblAftQty.Text = "Количество:";
            // 
            // CtrlTB
            // 
            this.CtrlTB.Location = new System.Drawing.Point(420, 182);
            this.CtrlTB.Name = "CtrlTB";
            this.CtrlTB.Size = new System.Drawing.Size(100, 20);
            this.CtrlTB.TabIndex = 3;
            // 
            // CtrlLblAftUnits
            // 
            this.CtrlLblAftUnits.AutoSize = true;
            this.CtrlLblAftUnits.Location = new System.Drawing.Point(341, 185);
            this.CtrlLblAftUnits.Name = "CtrlLblAftUnits";
            this.CtrlLblAftUnits.Size = new System.Drawing.Size(61, 13);
            this.CtrlLblAftUnits.TabIndex = 4;
            this.CtrlLblAftUnits.Text = "Ед. измер:";
            // 
            // CtrlBtnOK
            // 
            this.CtrlBtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CtrlBtnOK.Location = new System.Drawing.Point(274, 274);
            this.CtrlBtnOK.Name = "CtrlBtnOK";
            this.CtrlBtnOK.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnOK.TabIndex = 5;
            this.CtrlBtnOK.Text = "Сохранить";
            this.CtrlBtnOK.UseVisualStyleBackColor = true;
            this.CtrlBtnOK.Click += new System.EventHandler(this.CtrlBtnOK_Click);
            // 
            // CtrlBtnCancel
            // 
            this.CtrlBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CtrlBtnCancel.Location = new System.Drawing.Point(393, 274);
            this.CtrlBtnCancel.Name = "CtrlBtnCancel";
            this.CtrlBtnCancel.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnCancel.TabIndex = 6;
            this.CtrlBtnCancel.Text = "Отменить";
            this.CtrlBtnCancel.UseVisualStyleBackColor = true;
            this.CtrlBtnCancel.Click += new System.EventHandler(this.CtrlBtnCancel_Click);
            // 
            // CtrlLblBef
            // 
            this.CtrlLblBef.AutoSize = true;
            this.CtrlLblBef.Location = new System.Drawing.Point(274, 12);
            this.CtrlLblBef.Name = "CtrlLblBef";
            this.CtrlLblBef.Size = new System.Drawing.Size(37, 13);
            this.CtrlLblBef.TabIndex = 7;
            this.CtrlLblBef.Text = "Было:";
            // 
            // CtrlLblBefName
            // 
            this.CtrlLblBefName.AutoSize = true;
            this.CtrlLblBefName.Location = new System.Drawing.Point(341, 12);
            this.CtrlLblBefName.Name = "CtrlLblBefName";
            this.CtrlLblBefName.Size = new System.Drawing.Size(60, 13);
            this.CtrlLblBefName.TabIndex = 8;
            this.CtrlLblBefName.Text = "Название:";
            // 
            // CtrlLblBefQty
            // 
            this.CtrlLblBefQty.AutoSize = true;
            this.CtrlLblBefQty.Location = new System.Drawing.Point(341, 38);
            this.CtrlLblBefQty.Name = "CtrlLblBefQty";
            this.CtrlLblBefQty.Size = new System.Drawing.Size(69, 13);
            this.CtrlLblBefQty.TabIndex = 9;
            this.CtrlLblBefQty.Text = "Количество:";
            // 
            // CtrlLblBefUnits
            // 
            this.CtrlLblBefUnits.AutoSize = true;
            this.CtrlLblBefUnits.Location = new System.Drawing.Point(341, 64);
            this.CtrlLblBefUnits.Name = "CtrlLblBefUnits";
            this.CtrlLblBefUnits.Size = new System.Drawing.Size(61, 13);
            this.CtrlLblBefUnits.TabIndex = 10;
            this.CtrlLblBefUnits.Text = "Ед. измер:";
            // 
            // CtrlLblBefNameValue
            // 
            this.CtrlLblBefNameValue.AutoSize = true;
            this.CtrlLblBefNameValue.Location = new System.Drawing.Point(417, 12);
            this.CtrlLblBefNameValue.Name = "CtrlLblBefNameValue";
            this.CtrlLblBefNameValue.Size = new System.Drawing.Size(63, 13);
            this.CtrlLblBefNameValue.TabIndex = 11;
            this.CtrlLblBefNameValue.Text = "SampleText";
            // 
            // CtrlLblBefQtyValue
            // 
            this.CtrlLblBefQtyValue.AutoSize = true;
            this.CtrlLblBefQtyValue.Location = new System.Drawing.Point(417, 38);
            this.CtrlLblBefQtyValue.Name = "CtrlLblBefQtyValue";
            this.CtrlLblBefQtyValue.Size = new System.Drawing.Size(63, 13);
            this.CtrlLblBefQtyValue.TabIndex = 12;
            this.CtrlLblBefQtyValue.Text = "SampleText";
            // 
            // CtrlLblBefUnitsValue
            // 
            this.CtrlLblBefUnitsValue.AutoSize = true;
            this.CtrlLblBefUnitsValue.Location = new System.Drawing.Point(417, 64);
            this.CtrlLblBefUnitsValue.Name = "CtrlLblBefUnitsValue";
            this.CtrlLblBefUnitsValue.Size = new System.Drawing.Size(63, 13);
            this.CtrlLblBefUnitsValue.TabIndex = 13;
            this.CtrlLblBefUnitsValue.Text = "SampleText";
            // 
            // CtrlLblAft
            // 
            this.CtrlLblAft.AutoSize = true;
            this.CtrlLblAft.Location = new System.Drawing.Point(274, 120);
            this.CtrlLblAft.Name = "CtrlLblAft";
            this.CtrlLblAft.Size = new System.Drawing.Size(45, 13);
            this.CtrlLblAft.TabIndex = 14;
            this.CtrlLblAft.Text = "Станет:";
            // 
            // CtrlLblAftName
            // 
            this.CtrlLblAftName.AutoSize = true;
            this.CtrlLblAftName.Location = new System.Drawing.Point(341, 120);
            this.CtrlLblAftName.Name = "CtrlLblAftName";
            this.CtrlLblAftName.Size = new System.Drawing.Size(60, 13);
            this.CtrlLblAftName.TabIndex = 15;
            this.CtrlLblAftName.Text = "Название:";
            // 
            // CtrlLblAftNameValue
            // 
            this.CtrlLblAftNameValue.AutoSize = true;
            this.CtrlLblAftNameValue.Location = new System.Drawing.Point(417, 120);
            this.CtrlLblAftNameValue.Name = "CtrlLblAftNameValue";
            this.CtrlLblAftNameValue.Size = new System.Drawing.Size(63, 13);
            this.CtrlLblAftNameValue.TabIndex = 16;
            this.CtrlLblAftNameValue.Text = "SampleText";
            // 
            // IngredsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 422);
            this.Controls.Add(this.CtrlLblAftNameValue);
            this.Controls.Add(this.CtrlLblAftName);
            this.Controls.Add(this.CtrlLblAft);
            this.Controls.Add(this.CtrlLblBefUnitsValue);
            this.Controls.Add(this.CtrlLblBefQtyValue);
            this.Controls.Add(this.CtrlLblBefNameValue);
            this.Controls.Add(this.CtrlLblBefUnits);
            this.Controls.Add(this.CtrlLblBefQty);
            this.Controls.Add(this.CtrlLblBefName);
            this.Controls.Add(this.CtrlLblBef);
            this.Controls.Add(this.CtrlBtnCancel);
            this.Controls.Add(this.CtrlBtnOK);
            this.Controls.Add(this.CtrlLblAftUnits);
            this.Controls.Add(this.CtrlTB);
            this.Controls.Add(this.CtrlLblAftQty);
            this.Controls.Add(this.CtrlNUD);
            this.Controls.Add(this.CtrlDGV);
            this.Name = "IngredsForm";
            this.Text = "Редактор ингредиентов";
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CtrlDGV;
        private System.Windows.Forms.NumericUpDown CtrlNUD;
        private System.Windows.Forms.Label CtrlLblAftQty;
        private System.Windows.Forms.TextBox CtrlTB;
        private System.Windows.Forms.Label CtrlLblAftUnits;
        private System.Windows.Forms.Button CtrlBtnOK;
        private System.Windows.Forms.Button CtrlBtnCancel;
        private System.Windows.Forms.Label CtrlLblBef;
        private System.Windows.Forms.Label CtrlLblBefName;
        private System.Windows.Forms.Label CtrlLblBefQty;
        private System.Windows.Forms.Label CtrlLblBefUnits;
        private System.Windows.Forms.Label CtrlLblBefNameValue;
        private System.Windows.Forms.Label CtrlLblBefQtyValue;
        private System.Windows.Forms.Label CtrlLblBefUnitsValue;
        private System.Windows.Forms.Label CtrlLblAft;
        private System.Windows.Forms.Label CtrlLblAftName;
        private System.Windows.Forms.Label CtrlLblAftNameValue;
    }
}