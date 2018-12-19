using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Physics_Project
{
    public partial class ColorPicker : Form
    {
        public Color ChosenColor;
        public Random rnd = new Random();

        public ColorPicker()
        {
            InitializeComponent();

            ChosenColor = Color.FromArgb(255, (int)rNUPDO.Value, (int)gNUPDO.Value, (int)bNUPDO.Value);
            previewPIBO.BackColor = ChosenColor;
        }

        private void chooseBU_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rNUPDO_ValueChanged(object sender, EventArgs e)
        {
            ChosenColor = Color.FromArgb(255, (int)rNUPDO.Value, (int)gNUPDO.Value, (int)bNUPDO.Value);
            previewPIBO.BackColor = ChosenColor;
        }
        private void gNUPDO_ValueChanged(object sender, EventArgs e)
        {
            ChosenColor = Color.FromArgb(255, (int)rNUPDO.Value, (int)gNUPDO.Value, (int)bNUPDO.Value);
            previewPIBO.BackColor = ChosenColor;
        }
        private void bNUPDO_ValueChanged(object sender, EventArgs e)
        {
            ChosenColor = Color.FromArgb(255, (int)rNUPDO.Value, (int)gNUPDO.Value, (int)bNUPDO.Value);
            previewPIBO.BackColor = ChosenColor;
        }

        private void randomBU_Click(object sender, EventArgs e)
        {
            

            rNUPDO.Value = rnd.Next(0, 256);
            gNUPDO.Value = rnd.Next(0, 256);
            bNUPDO.Value = rnd.Next(0, 256);

            ChosenColor = Color.FromArgb(255, (int)rNUPDO.Value, (int)gNUPDO.Value, (int)bNUPDO.Value);

            previewPIBO.BackColor = ChosenColor;

        }
    }
}
