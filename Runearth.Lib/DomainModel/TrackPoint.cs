using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runearth.Lib.DomainModel
{
    public class TrackPoint
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Elevation { get; set; }
        public DateTime DateTime { get; set; }
    }
}
