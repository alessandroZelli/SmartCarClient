using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.DTO;

namespace Client.Sensors
{
    public interface ISensor
    {
        int Id { get; set; }
        string MeasurementUnit { get; set; }
        string ValueName { get; set; }
        decimal Range { get; set; }
        decimal Minimum { get; set; }
        int Timeout { get; set; }


        Measure GenerateMeasure();
        
    }
}
