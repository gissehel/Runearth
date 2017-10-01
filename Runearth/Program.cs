﻿using Runearth.Lib.Core.Service;
using Runearth.Lib.Service;

namespace Runearth
{
    class Program
    {
        static void Main(string[] args)
        {
            IGpxReader gpxReader = new GpxReader();
            IKmlWriter kmlWriter = new KmlWriter();
            IGpxToKmlConverter gpxToKmlConverter = new GpxToKmlConverter(gpxReader, kmlWriter);

            gpxToKmlConverter.Convert(args[0], args[1]);
        }
    }
}