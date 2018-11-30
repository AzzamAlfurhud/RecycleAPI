using GeoAPI.Geometries;
using System;

namespace RecycleAPI.Data.Entities
{
    public class Recycle
    {
        public int Id { get; set; }
        public IPoint Location { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public TypeEnum TypeId { get; set; }
        public Type Type { get; set; }

        public StatusEnum StatusId { get; set; }
        public Status Status { get; set; }
    }
}
