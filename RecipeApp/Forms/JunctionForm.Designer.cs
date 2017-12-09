namespace RecipeApp.Forms
{
    partial class JunctionForm
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
            this.CtrlBtnEdit = new System.Windows.Forms.Button();
            this.CtrlBtnDelete = new System.Windows.Forms.Button();
            this.CtrlLbl = new System.Windows.Forms.Label();
            this.CtrlBtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CtrlBtnEdit
            // 
            this.CtrlBtnEdit.Location = new System.Drawing.Point(45, 158);
            this.CtrlBtnEdit.Name = "CtrlBtnEdit";
            this.CtrlBtnEdit.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnEdit.TabIndex = 0;
            this.CtrlBtnEdit.Text = "Изменить";
            this.CtrlBtnEdit.UseVisualStyleBackColor = true;
            this.CtrlBtnEdit.Click += new System.EventHandler(this.CtrlBtnEdit_Click);
            // 
            // CtrlBtnDelete
            // 
            this.CtrlBtnDelete.Location = new System.Drawing.Point(165, 158);
            this.CtrlBtnDelete.Name = "CtrlBtnDelete";
            this.CtrlBtnDelete.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnDelete.TabIndex = 1;
            this.CtrlBtnDelete.Text = "Удалить";
            this.CtrlBtnDelete.UseVisualStyleBackColor = true;
            this.CtrlBtnDelete.Click += new System.EventHandler(this.CtrlBtnDelete_Click);
            // 
            // CtrlLbl
            // 
            this.CtrlLbl.AutoSize = true;
            this.CtrlLbl.Location = new System.Drawing.Point(42, 28);
            this.CtrlLbl.Name = "CtrlLbl";
            this.CtrlLbl.Size = new System.Drawing.Size(55, 13);
            this.CtrlLbl.TabIndex = 2;
            this.CtrlLbl.Text = "Выбрано:";
            // 
            // CtrlBtnCancel
            // 
            this.CtrlBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CtrlBtnCancel.Location = new System.Drawing.Point(284, 158);
            this.CtrlBtnCancel.Name = "CtrlBtnCancel";
            this.CtrlBtnCancel.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnCancel.TabIndex = 3;
            this.CtrlBtnCancel.Text = "Отменить";
            this.CtrlBtnCancel.UseVisualStyleBackColor = true;
            this.CtrlBtnCancel.Click += new System.EventHandler(this.CtrlBtnCancel_Click);
            // 
            // JunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 227);
            this.Controls.Add(this.CtrlBtnCancel);
            this.Controls.Add(this.CtrlLbl);
            this.Controls.Add(this.CtrlBtnDelete);
            this.Controls.Add(this.CtrlBtnEdit);
            this.Name = "JunctionForm";
            this.Text = "JunctionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CtrlBtnEdit;
        private System.Windows.Forms.Button CtrlBtnDelete;
        private System.Windows.Forms.Label CtrlLbl;
        private System.Windows.Forms.Button CtrlBtnCancel;
    }
}