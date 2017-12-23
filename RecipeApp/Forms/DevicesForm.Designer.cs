namespace RecipeApp.Forms
{
    partial class DevicesForm
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
            this.CtrlLblTxtOld = new System.Windows.Forms.Label();
            this.CtrlLblTxtNew = new System.Windows.Forms.Label();
            this.CtrlButOK = new System.Windows.Forms.Button();
            this.CtrlButCancel = new System.Windows.Forms.Button();
            this.CtrlLblOld = new System.Windows.Forms.Label();
            this.CtrlLblNew = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlDGV
            // 
            this.CtrlDGV.AllowUserToAddRows = false;
            this.CtrlDGV.AllowUserToDeleteRows = false;
            this.CtrlDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CtrlDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CtrlDGV.ColumnHeadersVisible = false;
            this.CtrlDGV.Location = new System.Drawing.Point(12, 12);
            this.CtrlDGV.MultiSelect = false;
            this.CtrlDGV.Name = "CtrlDGV";
            this.CtrlDGV.RowHeadersVisible = false;
            this.CtrlDGV.Size = new System.Drawing.Size(210, 428);
            this.CtrlDGV.TabIndex = 0;
            this.CtrlDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CtrlDGV_CellClick);
            this.CtrlDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CtrlDGV_CellContentClick);
            // 
            // CtrlLblTxtOld
            // 
            this.CtrlLblTxtOld.AutoSize = true;
            this.CtrlLblTxtOld.Location = new System.Drawing.Point(261, 48);
            this.CtrlLblTxtOld.Name = "CtrlLblTxtOld";
            this.CtrlLblTxtOld.Size = new System.Drawing.Size(97, 13);
            this.CtrlLblTxtOld.TabIndex = 1;
            this.CtrlLblTxtOld.Text = "Старое название:";
            // 
            // CtrlLblTxtNew
            // 
            this.CtrlLblTxtNew.AutoSize = true;
            this.CtrlLblTxtNew.Location = new System.Drawing.Point(261, 125);
            this.CtrlLblTxtNew.Name = "CtrlLblTxtNew";
            this.CtrlLblTxtNew.Size = new System.Drawing.Size(93, 13);
            this.CtrlLblTxtNew.TabIndex = 2;
            this.CtrlLblTxtNew.Text = "Новое название:";
            // 
            // CtrlButOK
            // 
            this.CtrlButOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CtrlButOK.Location = new System.Drawing.Point(264, 356);
            this.CtrlButOK.Name = "CtrlButOK";
            this.CtrlButOK.Size = new System.Drawing.Size(75, 23);
            this.CtrlButOK.TabIndex = 3;
            this.CtrlButOK.Text = "Сохранить";
            this.CtrlButOK.UseVisualStyleBackColor = true;
            this.CtrlButOK.Click += new System.EventHandler(this.CtrlButOK_Click);
            // 
            // CtrlButCancel
            // 
            this.CtrlButCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CtrlButCancel.Location = new System.Drawing.Point(417, 356);
            this.CtrlButCancel.Name = "CtrlButCancel";
            this.CtrlButCancel.Size = new System.Drawing.Size(75, 23);
            this.CtrlButCancel.TabIndex = 4;
            this.CtrlButCancel.Text = "Отменить";
            this.CtrlButCancel.UseVisualStyleBackColor = true;
            this.CtrlButCancel.Click += new System.EventHandler(this.CtrlButCancel_Click);
            // 
            // CtrlLblOld
            // 
            this.CtrlLblOld.AutoSize = true;
            this.CtrlLblOld.Location = new System.Drawing.Point(364, 48);
            this.CtrlLblOld.Name = "CtrlLblOld";
            this.CtrlLblOld.Size = new System.Drawing.Size(63, 13);
            this.CtrlLblOld.TabIndex = 5;
            this.CtrlLblOld.Text = "SampleText";
            // 
            // CtrlLblNew
            // 
            this.CtrlLblNew.AutoSize = true;
            this.CtrlLblNew.Location = new System.Drawing.Point(364, 125);
            this.CtrlLblNew.Name = "CtrlLblNew";
            this.CtrlLblNew.Size = new System.Drawing.Size(63, 13);
            this.CtrlLblNew.TabIndex = 6;
            this.CtrlLblNew.Text = "SampleText";
            // 
            // DevicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 461);
            this.Controls.Add(this.CtrlLblNew);
            this.Controls.Add(this.CtrlLblOld);
            this.Controls.Add(this.CtrlButCancel);
            this.Controls.Add(this.CtrlButOK);
            this.Controls.Add(this.CtrlLblTxtNew);
            this.Controls.Add(this.CtrlLblTxtOld);
            this.Controls.Add(this.CtrlDGV);
            this.Name = "DevicesForm";
            this.Text = "Редактор устройств";
            ((System.ComponentModel.ISupportInitialize)(this.CtrlDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CtrlDGV;
        private System.Windows.Forms.Label CtrlLblTxtOld;
        private System.Windows.Forms.Label CtrlLblTxtNew;
        private System.Windows.Forms.Button CtrlButOK;
        private System.Windows.Forms.Button CtrlButCancel;
        private System.Windows.Forms.Label CtrlLblOld;
        private System.Windows.Forms.Label CtrlLblNew;
    }
}