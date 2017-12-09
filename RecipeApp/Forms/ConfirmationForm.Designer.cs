namespace RecipeApp.Forms
{
    partial class ConfirmationForm
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
            this.CtrlBtnYes = new System.Windows.Forms.Button();
            this.CtrlBtnNo = new System.Windows.Forms.Button();
            this.CtrlLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CtrlBtnYes
            // 
            this.CtrlBtnYes.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CtrlBtnYes.Location = new System.Drawing.Point(24, 54);
            this.CtrlBtnYes.Name = "CtrlBtnYes";
            this.CtrlBtnYes.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnYes.TabIndex = 0;
            this.CtrlBtnYes.Text = "Да";
            this.CtrlBtnYes.UseVisualStyleBackColor = true;
            this.CtrlBtnYes.Click += new System.EventHandler(this.CtrlBtnYes_Click);
            // 
            // CtrlBtnNo
            // 
            this.CtrlBtnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CtrlBtnNo.Location = new System.Drawing.Point(129, 54);
            this.CtrlBtnNo.Name = "CtrlBtnNo";
            this.CtrlBtnNo.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnNo.TabIndex = 1;
            this.CtrlBtnNo.Text = "Нет";
            this.CtrlBtnNo.UseVisualStyleBackColor = true;
            this.CtrlBtnNo.Click += new System.EventHandler(this.CtrlBtnNo_Click);
            // 
            // CtrlLbl
            // 
            this.CtrlLbl.AutoSize = true;
            this.CtrlLbl.Location = new System.Drawing.Point(39, 21);
            this.CtrlLbl.Name = "CtrlLbl";
            this.CtrlLbl.Size = new System.Drawing.Size(135, 13);
            this.CtrlLbl.TabIndex = 2;
            this.CtrlLbl.Text = "Действительно удалить?";
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 92);
            this.Controls.Add(this.CtrlLbl);
            this.Controls.Add(this.CtrlBtnNo);
            this.Controls.Add(this.CtrlBtnYes);
            this.Name = "ConfirmationForm";
            this.Text = "ConfirmationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CtrlBtnYes;
        private System.Windows.Forms.Button CtrlBtnNo;
        private System.Windows.Forms.Label CtrlLbl;
    }
}