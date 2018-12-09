using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleAPI.Models
{
    public class Property
    {
        public string RecycleId { get; set; }
        public string RecycleType { get; set; }
        public string RecycleStatus { get; set; }

        public Property(string id,string type, string status)
        {
            RecycleId = id;
            RecycleType = type;
            RecycleStatus = status;
        }
    }
}
