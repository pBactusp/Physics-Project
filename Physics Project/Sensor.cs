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
        public string Type => GlobalData.SensorTypes[_Type];

        private int _VccPin,
            _GroundPin;
        public int VccPin { get { return _VccPin; } }
        public int GroundPin { get { return _GroundPin; } }

        private int[] _OutputPins;
        private int[] _InputPins;

        private object[] _Args;

        public Sensor()
        {
            _Type = 0;
        }
        public Sensor(string name, int type)
        {
            _Name = name;
            _Type = type;

            switch (_Type)
            {
                case 0:




                default:
                    break;
            }
        }


        private void Ultrasonic()
        {
            _VccPin = 0;
            _GroundPin = 0;

            _OutputPins = new int[] { 0 };
            _InputPins = new int[] { 0 };
        }


    }


}
