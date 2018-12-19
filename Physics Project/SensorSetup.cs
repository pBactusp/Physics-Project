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

        private int _SelectedSensor;
        public Sensor[] Sensors;
        public Sensor SelectedSensor
        {
            get { return Sensors[_SelectedSensor]; }
            set { Sensors[_SelectedSensor] = value; }
        }
        

        public SensorSetup()
        {
            InitializeComponent();

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
            _SelectedSensor = 0;

            foreach (string sensorName in GlobalData.SensorTypes)
                sensorCOBO.Items.Add(sensorName);
            sensorCOBO.SelectedIndex = 0;


        }


        private void DrawQuarters()
        {
            Graphics g = Graphics.FromImage(systemImagePIBO.BackgroundImage);
            g.Clear(clearColor);

            for (int i = 1; i < 4; i++)
                g.DrawLine(Pens.Black, i * quarter, 0, i * quarter, systemImagePIBO.Height);
            g.FillEllipse(Brushes.Red, quarter * _SelectedSensor + quarter / 2 - 5, systemImagePIBO.Height / 2 - 5, 10, 10);

            systemImagePIBO.Refresh();
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
                    _SelectedSensor = 0;
                else if (e.X < quarter * 2)
                    _SelectedSensor = 1;
                else if (e.X < quarter * 3)
                    _SelectedSensor = 2;
                else
                    _SelectedSensor = 3;
            }

            Update2();
        }



        #region Sensor setup functions

        private void Update2()
        {
            samplingRateNUPDO.Value = SelectedSensor.SampleRate;
            sensorCOBO.SelectedIndex = SelectedSensor.Type;

            switch (SelectedSensor.TypeS)
            {
                case "Empty":
                    EmptySensor();

                    break;


                case "Ultrasonic":
                    SetupUltrasonic();

                    break;


                default:


                    break;
            }


            DrawQuarters();
        }

        private void EmptySensor()
        {
            connectionsLIBO.Items.Clear();

            connectionsGRBO.Enabled = false;
            samplingGRBO.Enabled = false;
        }

        private void SetupUltrasonic()
        {
            connectionsGRBO.Enabled = true;
            samplingGRBO.Enabled = true;

            connectionsLIBO.Items.Clear();
            foreach (Pin pin in SelectedSensor.Pins)
            {
                connectionsLIBO.Items.Add(pin.Name + ": " + pin.Number.ToString());
            }




        }




        #endregion

        private void sensorCOBO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedSensor.Type != sensorCOBO.SelectedIndex)
                SelectedSensor = new Sensor(sensorCOBO.SelectedIndex);
            Update2();
        }

        private void setPinNumBU_Click(object sender, EventArgs e)
        {
            Pin tempPin = new Pin() {
                Name = SelectedSensor.Pins[connectionsLIBO.SelectedIndex].Name,
                Number = (int)pinNumNUPDO.Value
            };

            SelectedSensor.Pins[connectionsLIBO.SelectedIndex] = tempPin;
            Update2();
        }

        private void samplingRateNUPDO_ValueChanged(object sender, EventArgs e)
        {
            SelectedSensor.SampleRate = (int)samplingRateNUPDO.Value;
        }
    }
}
