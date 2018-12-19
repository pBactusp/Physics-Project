namespace Graph2
{
    partial class Graph2
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.displayP = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // displayP
            // 
            this.displayP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayP.Location = new System.Drawing.Point(3, 3);
            this.displayP.Name = "displayP";
            this.displayP.Size = new System.Drawing.Size(794, 444);
            this.displayP.TabIndex = 0;
            // 
            // Graph2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.displayP);
            this.Name = "Graph2";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel displayP;
    }
}
