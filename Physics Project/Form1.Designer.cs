namespace Physics_Project
{
    partial class mainForm
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
            this.startB = new System.Windows.Forms.Button();
            this.stopB = new System.Windows.Forms.Button();
            this.pauseB = new System.Windows.Forms.Button();
            this.detectARSystemB = new System.Windows.Forms.Button();
            this.adsCB = new System.Windows.Forms.CheckBox();
            this.systemConnectedCB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // startB
            // 
            this.startB.Location = new System.Drawing.Point(2, 2);
            this.startB.Margin = new System.Windows.Forms.Padding(2);
            this.startB.Name = "startB";
            this.startB.Size = new System.Drawing.Size(46, 37);
            this.startB.TabIndex = 0;
            this.startB.Text = "Start";
            this.startB.UseVisualStyleBackColor = true;
            this.startB.Click += new System.EventHandler(this.startB_Click);
            // 
            // stopB
            // 
            this.stopB.Enabled = false;
            this.stopB.Location = new System.Drawing.Point(52, 2);
            this.stopB.Margin = new System.Windows.Forms.Padding(2);
            this.stopB.Name = "stopB";
            this.stopB.Size = new System.Drawing.Size(46, 37);
            this.stopB.TabIndex = 2;
            this.stopB.Text = "Stop";
            this.stopB.UseVisualStyleBackColor = true;
            this.stopB.Click += new System.EventHandler(this.stopB_Click);
            // 
            // pauseB
            // 
            this.pauseB.Enabled = false;
            this.pauseB.Location = new System.Drawing.Point(102, 2);
            this.pauseB.Margin = new System.Windows.Forms.Padding(2);
            this.pauseB.Name = "pauseB";
            this.pauseB.Size = new System.Drawing.Size(45, 37);
            this.pauseB.TabIndex = 3;
            this.pauseB.Text = "Pause";
            this.pauseB.UseVisualStyleBackColor = true;
            this.pauseB.Click += new System.EventHandler(this.pauseB_Click);
            // 
            // detectARSystemB
            // 
            this.detectARSystemB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detectARSystemB.Location = new System.Drawing.Point(4, 16);
            this.detectARSystemB.Margin = new System.Windows.Forms.Padding(2);
            this.detectARSystemB.Name = "detectARSystemB";
            this.detectARSystemB.Size = new System.Drawing.Size(144, 37);
            this.detectARSystemB.TabIndex = 4;
            this.detectARSystemB.Text = "Detect system";
            this.detectARSystemB.UseVisualStyleBackColor = true;
            this.detectARSystemB.Click += new System.EventHandler(this.detectARSystemB_Click);
            // 
            // adsCB
            // 
            this.adsCB.AutoSize = true;
            this.adsCB.Checked = true;
            this.adsCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.adsCB.Location = new System.Drawing.Point(4, 57);
            this.adsCB.Margin = new System.Windows.Forms.Padding(2);
            this.adsCB.Name = "adsCB";
            this.adsCB.Size = new System.Drawing.Size(116, 17);
            this.adsCB.TabIndex = 5;
            this.adsCB.Text = "Auto-detect system";
            this.adsCB.UseVisualStyleBackColor = true;
            // 
            // systemConnectedCB
            // 
            this.systemConnectedCB.AutoSize = true;
            this.systemConnectedCB.Enabled = false;
            this.systemConnectedCB.Location = new System.Drawing.Point(4, 79);
            this.systemConnectedCB.Margin = new System.Windows.Forms.Padding(2);
            this.systemConnectedCB.Name = "systemConnectedCB";
            this.systemConnectedCB.Size = new System.Drawing.Size(78, 17);
            this.systemConnectedCB.TabIndex = 6;
            this.systemConnectedCB.Text = "Connected";
            this.systemConnectedCB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.detectARSystemB);
            this.groupBox1.Controls.Add(this.systemConnectedCB);
            this.groupBox1.Controls.Add(this.adsCB);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.Location = new System.Drawing.Point(674, 122);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(152, 102);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.95761F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.04239F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 10);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.13115F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.86885F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(828, 543);
            this.tableLayoutPanel1.TabIndex = 8;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 122);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(583, 419);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Controls.Add(this.startB, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pauseB, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.stopB, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 75);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainForm";
            this.Text = "Main";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startB;
        private System.Windows.Forms.Button stopB;
        private System.Windows.Forms.Button pauseB;
        private System.Windows.Forms.Button detectARSystemB;
        private System.Windows.Forms.CheckBox adsCB;
        private System.Windows.Forms.CheckBox systemConnectedCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

