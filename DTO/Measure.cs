using System;
using System.Text;
using Newtonsoft.Json;

namespace Client.DTO
{
    public class Measure
    {
        public Measure()
        {

        }
        public Measure(int id, string mu)
        {
            Timestamp = generateTimestamp();
            SensorId = id;
            MeasurementUnit = mu;

        }
        public decimal Value { get; set; }
        public string MeasurementUnit { get; set; }
        public int SensorId { get; set; }
        public long Timestamp { get; set; }

        private long generateTimestamp() {
            DateTime now = DateTime.Now;
            long ts = now.Ticks * 100;
            return ts;

        }
        public string ToJSON(){
            string MeasureJSON = JsonConvert.SerializeObject(this);
            return MeasureJSON;
        }

    }
}
