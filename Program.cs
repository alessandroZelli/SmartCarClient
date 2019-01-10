using System.Collections.Generic;
using Client.Sensors;
using Client.Architecture;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {


            // init sensors
            //ISensor temperatureSensor = new Sensor();
            //temperatureSensor = JsonConvert.DeserializeObject<Sensor>(File.ReadAllText(@"C:/Users/Utente/Documents/AdvancedNetworking/iot-protocols/client/Client/TestFiles/Sensori.json"));
            //Console.WriteLine("{0},{1}", temperatureSensor.Id, temperatureSensor.ValueName);
            ISensor[] sensorList  =JsonConvert.DeserializeObject<Sensor[]>(File.ReadAllText(@"C:/Users/Utente/Documents/AdvancedNetworking/iot-protocols/client/Client/TestFiles/Sensori.json"));
            Controller ctr = new Controller(sensorList);

            //GENERA MISURE SULLA LISTA DEI SENSORI
            Thread w = new Thread(() => ctr.GetMeasures());
            
            Thread r = new Thread(() => ctr.ShowMeasures());
            w.Start();
           
            r.Start();
            // TODO add more sensors
            
            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/cars/AB123CD");
            //httpWebRequest.ContentType = "text/json";
            //httpWebRequest.Method = "POST";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    streamWriter.Write(temperatureSensor.ToJson());
            //}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //Console.Out.WriteLine(httpResponse.StatusCode);

            Thread.Sleep(10000);



        }

    }

}
