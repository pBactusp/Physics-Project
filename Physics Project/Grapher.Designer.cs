namespace Physics_Project
{
    partial class Grapher
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
            this.components = new System.ComponentModel.Container();
            this.displayPB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fitLinB = new System.Windows.Forms.Button();
            this.powerValueNUD = new System.Windows.Forms.NumericUpDown();
            this.polyResNUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataSetsTV = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.zoomModeCB = new System.Windows.Forms.ComboBox();
            this.treeViewMEST = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.displayPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerValueNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.polyResNUD)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.treeViewMEST.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayPB
            // 
            this.displayPB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.displayPB.Location = new System.Drawing.Point(3, 68);
            this.displayPB.MinimumSize = new System.Drawing.Size(31, 21);
            this.displayPB.Name = "displayPB";
            this.displayPB.Size = new System.Drawing.Size(517, 355);
            this.displayPB.TabIndex = 0;
            this.displayPB.TabStop = false;
            this.displayPB.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.displayPB_MouseDoubleClick);
            this.displayPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.displayPB_MouseDown);
            this.displayPB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.displayPB_MouseMove);
            this.displayPB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.displayPB_MouseUp);
            this.displayPB.Resize += new System.EventHandler(this.displayPB_Resize);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selected dataset:";
            // 
            // fitLinB
            // 
            this.fitLinB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fitLinB.Location = new System.Drawing.Point(3, 3);
            this.fitLinB.Name = "fitLinB";
            this.fitLinB.Size = new System.Drawing.Size(160, 25);
            this.fitLinB.TabIndex = 3;
            this.fitLinB.Text = "Fit polynom";
            this.fitLinB.UseVisualStyleBackColor = true;
            this.fitLinB.Click += new System.EventHandler(this.fitPolinom_Click);
            // 
            // powerValueNUD
            // 
            this.powerValueNUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.powerValueNUD.Location = new System.Drawing.Point(169, 3);
            this.powerValueNUD.Name = "powerValueNUD";
            this.powerValueNUD.Size = new System.Drawing.Size(69, 20);
            this.powerValueNUD.TabIndex = 4;
            this.powerValueNUD.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // polyResNUD
            // 
            this.polyResNUD.Location = new System.Drawing.Point(173, 3);
            this.polyResNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.polyResNUD.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.polyResNUD.Name = "polyResNUD";
            this.polyResNUD.Size = new System.Drawing.Size(60, 20);
            this.polyResNUD.TabIndex = 6;
            this.polyResNUD.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Polynom resolution:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Zoom mode:";
            // 
            // dataSetsTV
            // 
            this.dataSetsTV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataSetsTV.CheckBoxes = true;
            this.dataSetsTV.Location = new System.Drawing.Point(3, 37);
            this.dataSetsTV.Name = "dataSetsTV";
            this.dataSetsTV.Size = new System.Drawing.Size(241, 247);
            this.dataSetsTV.TabIndex = 16;
            this.dataSetsTV.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.dataSetsTV_AfterCheck);
            this.dataSetsTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.dataSetsTV_AfterSelect);
            this.dataSetsTV.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.dataSetsTV_NodeMouseClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.52577F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.47423F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.displayPB, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.45189F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.5481F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 426);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataSetsTV, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(526, 68);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.08791F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.91209F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(247, 355);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.07895F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.92105F));
            this.tableLayoutPanel3.Controls.Add(this.fitLinB, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.powerValueNUD, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 290);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(241, 32);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.83334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.16667F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.polyResNUD, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 328);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(241, 24);
            this.tableLayoutPanel4.TabIndex = 18;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.zoomModeCB, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(100, 53);
            this.tableLayoutPanel5.TabIndex = 18;
            // 
            // zoomModeCB
            // 
            this.zoomModeCB.FormattingEnabled = true;
            this.zoomModeCB.Items.AddRange(new object[] {
            "To Mouse",
            "To Center"});
            this.zoomModeCB.Location = new System.Drawing.Point(3, 19);
            this.zoomModeCB.Name = "zoomModeCB";
            this.zoomModeCB.Size = new System.Drawing.Size(94, 21);
            this.zoomModeCB.TabIndex = 8;
            this.zoomModeCB.Text = "To Center";
            // 
            // treeViewMEST
            // 
            this.treeViewMEST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeColorToolStripMenuItem});
            this.treeViewMEST.Name = "treeViewMEST";
            this.treeViewMEST.Size = new System.Drawing.Size(148, 26);
            // 
            // changeColorToolStripMenuItem
            // 
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            this.changeColorToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.changeColorToolStripMenuItem.Text = "Change Color";
            this.changeColorToolStripMenuItem.Click += new System.EventHandler(this.changeColorToolStripMenuItem_Click);
            // 
            // Grapher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "Grapher";
            this.Text = "Grapher";
            ((System.ComponentModel.ISupportInitialize)(this.displayPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerValueNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.polyResNUD)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.treeViewMEST.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox displayPB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button fitLinB;
        private System.Windows.Forms.NumericUpDown powerValueNUD;
        private System.Windows.Forms.NumericUpDown polyResNUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView dataSetsTV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ComboBox zoomModeCB;
        private System.Windows.Forms.ContextMenuStrip treeViewMEST;
        private System.Windows.Forms.ToolStripMenuItem changeColorToolStripMenuItem;
    }
}