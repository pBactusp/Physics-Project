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
    public partial class SensorSetup : Form
    {
        private float quarter { get { return systemImagePIBO.Width / 4; } }
        private Color clearColor { get { return Color.FromArgb(0, 0, 0, 0); } }
        private int selectedSensor;

        public Sensor[] Sensors;
        

        public SensorSetup()
        {
            InitializeComponent();

            foreach (string sensorName in GlobalData.SensorTypes)
                sensorCOBO.Items.Add(sensorName);

            systemImagePIBO.BackgroundImage = new Bitmap(systemImagePIBO.Width, systemImagePIBO.Height);
            DrawQuarters();


            Sensor tempSensor1 = new Sensor();
            Sensor tempSensor2 = new Sensor();
            Sensor tempSensor3 = new Sensor();
            Sensor tempSensor4 = new Sensor();

            Sensors = new Sensor[] 
            {
                tempSensor1,
                tempSensor2,
                tempSensor3,
                tempSensor4
            };
            selectedSensor = 0;



        }


        private void DrawQuarters()
        {
            Graphics g = Graphics.FromImage(systemImagePIBO.BackgroundImage);
            g.Clear(clearColor);

            for (int i = 1; i < 4; i++)
                g.DrawLine(Pens.Black, i * quarter, 0, i * quarter, systemImagePIBO.Height);
        }

        private void systemImagePIBO_SizeChanged(object sender, EventArgs e)
        {
            DrawQuarters();
        }
        private void systemImagePIBO_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X < quarter)
                {

                }
                else if (e.X < quarter * 2)
                {

                }
                else if (e.X < quarter * 3)
                {

                }
                else
                {

                }

            }
        }



        #region Sensor setup functions

        private void EmptySensor()
        {
            connectionsLIBO.Items.Clear();
        }

        private void SetupUltrasonic()
        {
            connectionsLIBO.Items.Clear();
            connectionsLIBO.Items.Add(Sensors[selectedSensor]);


        }




        #endregion

        private void sensorCOBO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
