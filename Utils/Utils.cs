using System.Collections.Generic;
using Client.Sensors;
using Newtonsoft.Json;

namespace Client.Utils
{
    public static class Utils
    {
        public static List<ISensor> JSONToSensorList(string filePath) {
            List<ISensor> returnList = new List<ISensor>();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                Sensor obj = SensorFromJSON(lines[i]);
                returnList.Add(obj);
            }          
            return returnList;
        }

        public static Sensor SensorFromJSON(string jsonString) {
            Sensor s = JsonConvert.DeserializeObject<Sensor>(jsonString);
            return s;
        }
    }
}
