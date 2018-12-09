using GeoAPI.Geometries;
using System;

namespace RecycleAPI.ViewModel
{
    public class RecycleTypeViewModel
    {
        public string Id { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public string Status { get; set; }
    }
}
