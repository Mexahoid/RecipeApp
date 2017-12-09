namespace RecipeApp
{
    partial class RenameForm
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
            this.CtrlTBName = new System.Windows.Forms.TextBox();
            this.CtrlBtnAdd = new System.Windows.Forms.Button();
            this.CtrlBtnReject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CtrlTBName
            // 
            this.CtrlTBName.Location = new System.Drawing.Point(12, 12);
            this.CtrlTBName.Name = "CtrlTBName";
            this.CtrlTBName.Size = new System.Drawing.Size(235, 20);
            this.CtrlTBName.TabIndex = 0;
            // 
            // CtrlBtnAdd
            // 
            this.CtrlBtnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CtrlBtnAdd.Location = new System.Drawing.Point(12, 55);
            this.CtrlBtnAdd.Name = "CtrlBtnAdd";
            this.CtrlBtnAdd.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnAdd.TabIndex = 1;
            this.CtrlBtnAdd.Text = "Добавить";
            this.CtrlBtnAdd.UseVisualStyleBackColor = true;
            this.CtrlBtnAdd.Click += new System.EventHandler(this.CtrlBtnAdd_Click);
            // 
            // CtrlBtnReject
            // 
            this.CtrlBtnReject.Location = new System.Drawing.Point(172, 55);
            this.CtrlBtnReject.Name = "CtrlBtnReject";
            this.CtrlBtnReject.Size = new System.Drawing.Size(75, 23);
            this.CtrlBtnReject.TabIndex = 2;
            this.CtrlBtnReject.Text = "Отменить";
            this.CtrlBtnReject.UseVisualStyleBackColor = true;
            this.CtrlBtnReject.Click += new System.EventHandler(this.CtrlBtnReject_Click);
            // 
            // Adder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 87);
            this.Controls.Add(this.CtrlBtnReject);
            this.Controls.Add(this.CtrlBtnAdd);
            this.Controls.Add(this.CtrlTBName);
            this.Name = "RenameForm";
            this.Text = "Adder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CtrlTBName;
        private System.Windows.Forms.Button CtrlBtnAdd;
        private System.Windows.Forms.Button CtrlBtnReject;
    }
}