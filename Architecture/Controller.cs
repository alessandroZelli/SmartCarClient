using System;
using Client.Sensors;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Client.DTO;

namespace Client.Architecture
{
    class Controller
    {
        List<ISensor> _sensorList;
        Queue<string> _measureList;
        List<Thread> _threads;

        public Controller()
        {
            _measureList = new Queue<string>();
            _sensorList = new List<ISensor>();
            _threads = new List<Thread>();
        }

        public Controller(params ISensor[] sensors)
        {
            _measureList = new Queue<string>();
            _sensorList = new List<ISensor>(sensors);
            _threads = new List<Thread>();
        }



        public void GetMeasures()
        {
            for (int i = 0; i < _sensorList.Capacity; i++)
            {
                var elem = _sensorList.ElementAt(i);
                var t = new Thread(() =>
                {
                    while (true)
                    {
                        var m = new Measure();

                        m = elem.GenerateMeasure();

                        AddMeasure(m);
                    }
                });
                _threads.Add(t);
                t.Start();
                
            }
        }

        public void ShowMeasures() {
            

            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    var str = _measureList.Dequeue();
                    Console.WriteLine(str);
                }
                catch (Exception e)
                {
                    Console.Write("Coda Vuota");
                    
                }
            }
        }

        private void AddMeasure(Measure m) {
            string str = m.ToJSON();
            _measureList.Enqueue(str);

        }
    }
}
