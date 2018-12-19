using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Physics_Project
{
    public class Sensor
    {
        private string _Name;

        private int _Type;
        public string TypeS
        {
            get { return GlobalData.SensorTypes[_Type]; }
        }
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public List<Pin> Pins;

        private int _SampleRate;
        public int SampleRate
        {
            get { return _SampleRate; }
            set { _SampleRate = value; }
        }


        public Sensor()
        {
            _Type = 0;
        }

        public Sensor(int type)
        {
            _SampleRate = 100;
            Pins = new List<Pin>();

            _Type = type;

            switch (_Type)
            {
                case 0:

                    break;

                case 1:
                    Ultrasonic();
                    break;



                default:
                    break;
            }
        }


        private void Ultrasonic()
        {
            Pins = new List<Pin>() {
                new Pin() { Name = "VccPin", Number = 0 },
                new Pin() { Name = "GroundPin", Number = 0 },
                new Pin() { Name = "TrigerPin", Number = 0 },
                new Pin() { Name = "EchoPin", Number = 0 }
            };
        }


    }

    public struct Pin
    {
        public string Name;
        public int Number;
    }


}
