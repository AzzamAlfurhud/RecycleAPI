using GeoAPI.Geometries;
using System;


namespace RecycleAPI.ViewModel
{
    public class RecycleStatusViewModel
    {
        public string Id { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public string Type { get; set; }
    }
}
