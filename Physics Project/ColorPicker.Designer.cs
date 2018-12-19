namespace Physics_Project
{
    partial class ColorPicker
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
            this.rNUPDO = new System.Windows.Forms.NumericUpDown();
            this.gNUPDO = new System.Windows.Forms.NumericUpDown();
            this.bNUPDO = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.previewPIBO = new System.Windows.Forms.PictureBox();
            this.chooseBU = new System.Windows.Forms.Button();
            this.randomBU = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rNUPDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNUPDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNUPDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPIBO)).BeginInit();
            this.SuspendLayout();
            // 
            // rNUPDO
            // 
            this.rNUPDO.Location = new System.Drawing.Point(74, 9);
            this.rNUPDO.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.rNUPDO.Name = "rNUPDO";
            this.rNUPDO.Size = new System.Drawing.Size(49, 20);
            this.rNUPDO.TabIndex = 0;
            this.rNUPDO.ValueChanged += new System.EventHandler(this.rNUPDO_ValueChanged);
            // 
            // gNUPDO
            // 
            this.gNUPDO.Location = new System.Drawing.Point(74, 35);
            this.gNUPDO.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.gNUPDO.Name = "gNUPDO";
            this.gNUPDO.Size = new System.Drawing.Size(49, 20);
            this.gNUPDO.TabIndex = 1;
            this.gNUPDO.ValueChanged += new System.EventHandler(this.gNUPDO_ValueChanged);
            // 
            // bNUPDO
            // 
            this.bNUPDO.Location = new System.Drawing.Point(74, 61);
            this.bNUPDO.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bNUPDO.Name = "bNUPDO";
            this.bNUPDO.Size = new System.Drawing.Size(49, 20);
            this.bNUPDO.TabIndex = 2;
            this.bNUPDO.ValueChanged += new System.EventHandler(this.bNUPDO_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Red:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Green:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Blue:";
            // 
            // previewPIBO
            // 
            this.previewPIBO.Location = new System.Drawing.Point(129, 9);
            this.previewPIBO.Name = "previewPIBO";
            this.previewPIBO.Size = new System.Drawing.Size(72, 72);
            this.previewPIBO.TabIndex = 6;
            this.previewPIBO.TabStop = false;
            // 
            // chooseBU
            // 
            this.chooseBU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chooseBU.Location = new System.Drawing.Point(12, 87);
            this.chooseBU.Name = "chooseBU";
            this.chooseBU.Size = new System.Drawing.Size(111, 36);
            this.chooseBU.TabIndex = 7;
            this.chooseBU.Text = "Choose color";
            this.chooseBU.UseVisualStyleBackColor = true;
            this.chooseBU.Click += new System.EventHandler(this.chooseBU_Click);
            // 
            // randomBU
            // 
            this.randomBU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.randomBU.Location = new System.Drawing.Point(129, 87);
            this.randomBU.Name = "randomBU";
            this.randomBU.Size = new System.Drawing.Size(72, 36);
            this.randomBU.TabIndex = 8;
            this.randomBU.Text = "Random";
            this.randomBU.UseVisualStyleBackColor = true;
            this.randomBU.Click += new System.EventHandler(this.randomBU_Click);
            // 
            // ColorPicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(213, 127);
            this.Controls.Add(this.randomBU);
            this.Controls.Add(this.chooseBU);
            this.Controls.Add(this.previewPIBO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bNUPDO);
            this.Controls.Add(this.gNUPDO);
            this.Controls.Add(this.rNUPDO);
            this.Name = "ColorPicker";
            this.Text = "ColorPicker";
            ((System.ComponentModel.ISupportInitialize)(this.rNUPDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNUPDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNUPDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPIBO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown rNUPDO;
        private System.Windows.Forms.NumericUpDown gNUPDO;
        private System.Windows.Forms.NumericUpDown bNUPDO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox previewPIBO;
        private System.Windows.Forms.Button chooseBU;
        private System.Windows.Forms.Button randomBU;
    }
}