using GeoAPI.Geometries;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleAPI.Data.Entities
{
    public class Recycle
    {
        public string Id { get; set; }
        public IPoint Location { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public TypeEnum TypeId { get; set; }
        public Type Type { get; set; }

        public StatusEnum StatusId { get; set; }
        public Status Status { get; set; }

        public Recycle()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
