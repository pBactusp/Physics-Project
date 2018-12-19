namespace Physics_Project
{
    partial class ExportWindow
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
            this.saveB = new System.Windows.Forms.Button();
            this.findFolderB = new System.Windows.Forms.Button();
            this.directoryTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveB
            // 
            this.saveB.Location = new System.Drawing.Point(318, 58);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(79, 27);
            this.saveB.TabIndex = 0;
            this.saveB.Text = "Save";
            this.saveB.UseVisualStyleBackColor = true;
            // 
            // findFolderB
            // 
            this.findFolderB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.findFolderB.Location = new System.Drawing.Point(367, 29);
            this.findFolderB.Name = "findFolderB";
            this.findFolderB.Size = new System.Drawing.Size(30, 23);
            this.findFolderB.TabIndex = 1;
            this.findFolderB.Text = "...";
            this.findFolderB.UseVisualStyleBackColor = true;
            this.findFolderB.Click += new System.EventHandler(this.button1_Click);
            // 
            // directoryTB
            // 
            this.directoryTB.Location = new System.Drawing.Point(15, 29);
            this.directoryTB.Name = "directoryTB";
            this.directoryTB.Size = new System.Drawing.Size(346, 22);
            this.directoryTB.TabIndex = 2;
            this.directoryTB.TextChanged += new System.EventHandler(this.directoryTB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Export to:";
            // 
            // ExportWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(409, 97);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.directoryTB);
            this.Controls.Add(this.findFolderB);
            this.Controls.Add(this.saveB);
            this.Name = "ExportWindow";
            this.Text = "ExportWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.Button findFolderB;
        private System.Windows.Forms.TextBox directoryTB;
        private System.Windows.Forms.Label label1;
    }
}