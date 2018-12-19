namespace Physics_Project
{
    partial class SensorSetup
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
            this.systemImagePIBO = new System.Windows.Forms.PictureBox();
            this.connectionsGRBO = new System.Windows.Forms.GroupBox();
            this.pinNumNUPDO = new System.Windows.Forms.NumericUpDown();
            this.setPinNumBU = new System.Windows.Forms.Button();
            this.connectionsLIBO = new System.Windows.Forms.ListBox();
            this.propertiesGRBO = new System.Windows.Forms.GroupBox();
            this.samplingGRBO = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.samplingRateNUPDO = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.mainPA = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sensorCOBO = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.systemImagePIBO)).BeginInit();
            this.connectionsGRBO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pinNumNUPDO)).BeginInit();
            this.samplingGRBO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplingRateNUPDO)).BeginInit();
            this.mainPA.SuspendLayout();
            this.SuspendLayout();
            // 
            // systemImagePIBO
            // 
            this.systemImagePIBO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.systemImagePIBO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.systemImagePIBO.Location = new System.Drawing.Point(12, 12);
            this.systemImagePIBO.Name = "systemImagePIBO";
            this.systemImagePIBO.Size = new System.Drawing.Size(639, 204);
            this.systemImagePIBO.TabIndex = 0;
            this.systemImagePIBO.TabStop = false;
            this.systemImagePIBO.SizeChanged += new System.EventHandler(this.systemImagePIBO_SizeChanged);
            this.systemImagePIBO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.systemImagePIBO_MouseClick);
            // 
            // connectionsGRBO
            // 
            this.connectionsGRBO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionsGRBO.Controls.Add(this.pinNumNUPDO);
            this.connectionsGRBO.Controls.Add(this.setPinNumBU);
            this.connectionsGRBO.Controls.Add(this.connectionsLIBO);
            this.connectionsGRBO.Enabled = false;
            this.connectionsGRBO.Location = new System.Drawing.Point(3, 6);
            this.connectionsGRBO.Name = "connectionsGRBO";
            this.connectionsGRBO.Size = new System.Drawing.Size(151, 194);
            this.connectionsGRBO.TabIndex = 0;
            this.connectionsGRBO.TabStop = false;
            this.connectionsGRBO.Text = "Connections:";
            // 
            // pinNumNUPDO
            // 
            this.pinNumNUPDO.Location = new System.Drawing.Point(87, 159);
            this.pinNumNUPDO.Name = "pinNumNUPDO";
            this.pinNumNUPDO.Size = new System.Drawing.Size(58, 20);
            this.pinNumNUPDO.TabIndex = 2;
            // 
            // setPinNumBU
            // 
            this.setPinNumBU.Location = new System.Drawing.Point(6, 159);
            this.setPinNumBU.Name = "setPinNumBU";
            this.setPinNumBU.Size = new System.Drawing.Size(75, 20);
            this.setPinNumBU.TabIndex = 1;
            this.setPinNumBU.Text = "Set";
            this.setPinNumBU.UseVisualStyleBackColor = true;
            this.setPinNumBU.Click += new System.EventHandler(this.setPinNumBU_Click);
            // 
            // connectionsLIBO
            // 
            this.connectionsLIBO.FormattingEnabled = true;
            this.connectionsLIBO.Location = new System.Drawing.Point(6, 19);
            this.connectionsLIBO.Name = "connectionsLIBO";
            this.connectionsLIBO.Size = new System.Drawing.Size(139, 134);
            this.connectionsLIBO.TabIndex = 0;
            // 
            // propertiesGRBO
            // 
            this.propertiesGRBO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesGRBO.Enabled = false;
            this.propertiesGRBO.Location = new System.Drawing.Point(160, 6);
            this.propertiesGRBO.Name = "propertiesGRBO";
            this.propertiesGRBO.Size = new System.Drawing.Size(150, 194);
            this.propertiesGRBO.TabIndex = 1;
            this.propertiesGRBO.TabStop = false;
            this.propertiesGRBO.Text = "Properties:";
            // 
            // samplingGRBO
            // 
            this.samplingGRBO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.samplingGRBO.Controls.Add(this.label3);
            this.samplingGRBO.Controls.Add(this.samplingRateNUPDO);
            this.samplingGRBO.Controls.Add(this.label2);
            this.samplingGRBO.Enabled = false;
            this.samplingGRBO.Location = new System.Drawing.Point(316, 6);
            this.samplingGRBO.Name = "samplingGRBO";
            this.samplingGRBO.Size = new System.Drawing.Size(151, 194);
            this.samplingGRBO.TabIndex = 2;
            this.samplingGRBO.TabStop = false;
            this.samplingGRBO.Text = "Sampling:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hz";
            // 
            // samplingRateNUPDO
            // 
            this.samplingRateNUPDO.Location = new System.Drawing.Point(9, 38);
            this.samplingRateNUPDO.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.samplingRateNUPDO.Name = "samplingRateNUPDO";
            this.samplingRateNUPDO.Size = new System.Drawing.Size(48, 20);
            this.samplingRateNUPDO.TabIndex = 1;
            this.samplingRateNUPDO.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.samplingRateNUPDO.ValueChanged += new System.EventHandler(this.samplingRateNUPDO_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sampling rate:";
            // 
            // mainPA
            // 
            this.mainPA.Controls.Add(this.connectionsGRBO);
            this.mainPA.Controls.Add(this.samplingGRBO);
            this.mainPA.Controls.Add(this.propertiesGRBO);
            this.mainPA.Location = new System.Drawing.Point(181, 222);
            this.mainPA.Name = "mainPA";
            this.mainPA.Size = new System.Drawing.Size(470, 200);
            this.mainPA.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sensor:";
            // 
            // sensorCOBO
            // 
            this.sensorCOBO.FormattingEnabled = true;
            this.sensorCOBO.Location = new System.Drawing.Point(15, 247);
            this.sensorCOBO.Name = "sensorCOBO";
            this.sensorCOBO.Size = new System.Drawing.Size(128, 21);
            this.sensorCOBO.TabIndex = 6;
            this.sensorCOBO.SelectedIndexChanged += new System.EventHandler(this.sensorCOBO_SelectedIndexChanged);
            // 
            // SensorSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(663, 434);
            this.Controls.Add(this.sensorCOBO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainPA);
            this.Controls.Add(this.systemImagePIBO);
            this.Name = "SensorSetup";
            this.Text = "SensorSetup";
            ((System.ComponentModel.ISupportInitialize)(this.systemImagePIBO)).EndInit();
            this.connectionsGRBO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pinNumNUPDO)).EndInit();
            this.samplingGRBO.ResumeLayout(false);
            this.samplingGRBO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplingRateNUPDO)).EndInit();
            this.mainPA.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox systemImagePIBO;
        private System.Windows.Forms.GroupBox connectionsGRBO;
        private System.Windows.Forms.GroupBox samplingGRBO;
        private System.Windows.Forms.GroupBox propertiesGRBO;
        private System.Windows.Forms.Panel mainPA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sensorCOBO;
        private System.Windows.Forms.NumericUpDown pinNumNUPDO;
        private System.Windows.Forms.Button setPinNumBU;
        private System.Windows.Forms.ListBox connectionsLIBO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown samplingRateNUPDO;
        private System.Windows.Forms.Label label3;
    }
}