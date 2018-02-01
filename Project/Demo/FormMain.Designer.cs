namespace Demo
{
    partial class FormMain
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
            this.iColorDialog = new System.Windows.Forms.ColorDialog();
            this.iButtonTestColorDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // iButtonTestColorDialog
            // 
            this.iButtonTestColorDialog.Location = new System.Drawing.Point(73, 139);
            this.iButtonTestColorDialog.Name = "iButtonTestColorDialog";
            this.iButtonTestColorDialog.Size = new System.Drawing.Size(75, 23);
            this.iButtonTestColorDialog.TabIndex = 0;
            this.iButtonTestColorDialog.Text = "Color";
            this.iButtonTestColorDialog.UseVisualStyleBackColor = true;
            this.iButtonTestColorDialog.Click += new System.EventHandler(this.iButtonTestColorDialog_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 459);
            this.Controls.Add(this.iButtonTestColorDialog);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog iColorDialog;
        private System.Windows.Forms.Button iButtonTestColorDialog;
    }
}

