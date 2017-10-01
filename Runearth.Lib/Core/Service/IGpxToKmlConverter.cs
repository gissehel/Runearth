using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runearth.Lib.Core.Service
{
    public interface IGpxToKmlConverter
    {
        void Convert(string gpxPath, string kmlFilename);
    }
}
