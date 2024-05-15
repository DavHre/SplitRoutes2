using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitRoutes
{
    class RoutesOut
    {
        [Name("lat")]
        [Index(0)]
        public string lat { get; set; }
        [Name("log")]
        [Index(1)]
        public string log { get; set; }
        [Name("icon")]
        [Index(2)]
        public string icon { get; set; }
        [Name("notes")]
        [Index(3)]
        public string notes { get; set; }
        [Name("status")]
        [Index(4)]
        public string status { get; set; }
        [Name("address")]
        [Index(5)]
        public string address { get; set; }
        [Name("reading")]
        [Index(6)]
        public string reading { get; set; }
        [Name("lastReading")]
        [Index(7)]
        public float lastReading { get; set; }
        [Name("dateTime")]
        [Index(8)]
        public string dateTime { get; set; }
        [Name("noAccesss")]
        [Index(9)]
        public string noAccess { get; set; }
        [Name("Address")]
        [Index(10)]
        public string clientName { get; set; }
        [Name("meterNumber")]
        [Index(11)]
        public string meterNumber { get; set; }


    }
}
