using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using Client.DTO;

namespace Client.Sensors
{
    public class Sensor : ISensor
    {
        public int Id { get; set; }
        public string ValueName { get; set; }
        public string MeasurementUnit { get; set; }
        public decimal Range { get; set; }
        public decimal Minimum { get; set; }
        public int Timeout { get; set; }

        public Measure GenerateMeasure()
        {

            Thread.Sleep(Timeout);
            Measure m = new Measure(Id, MeasurementUnit)
            {
                Value = GenerateValue()
            };
            return m;
        }

        private decimal GenerateValue()
        {
            Random random = new Random();
            decimal mod = (decimal)random.NextDouble();
            decimal randomValue = Minimum + Range * mod;
            return randomValue;
        }

       
       

        
    }
}
