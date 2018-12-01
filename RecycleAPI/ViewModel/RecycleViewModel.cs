using System;

namespace RecycleAPI.ViewModel
{
    public class RecycleViewModel
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int SRID { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public TypeEnum TypeId { get; set; }

        public StatusEnum StatusId { get; set; }
    }
}
