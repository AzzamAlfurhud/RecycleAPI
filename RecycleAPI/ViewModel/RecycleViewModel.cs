using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleAPI.ViewModel
{
    public class RecycleViewModel
    {
        
        public Coordinate Coordinates { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public TypeEnum TypeId { get; set; }

        public StatusEnum StatusId { get; set; }
    }
}
