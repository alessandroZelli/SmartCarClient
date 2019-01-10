using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Client.Architecture
{
    interface IConnectionController
    {
        string connectionString { get; set; }
        string url { get; set; }


        
    }
}
