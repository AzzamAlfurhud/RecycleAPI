using GeoAPI.Geometries;
using RecycleAPI.Models;
using System;
using System.Collections.Generic;

namespace RecycleAPI.ViewModel
{
    public class RecycleFullViewModel
    {
        //featuresCollections
        public string Type { get; set; }
        public List<Feature> Features { get; set; }
        //public double[] Coordinates { get; set; }

        //public string RecycleType { get; set; }
        //public string RecycleStatus { get; set; }
    }
}
