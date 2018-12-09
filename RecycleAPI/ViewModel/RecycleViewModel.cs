using System;

namespace RecycleAPI.ViewModel
{
    public class RecycleViewModel
    {
        public string Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public TypeEnum TypeId { get; set; }

        public StatusEnum StatusId { get; set; }
    }
}
