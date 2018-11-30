using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleAPI.Models
{
    public class Property
    {
        public string RecycleType { get; set; }
        public string RecycleStatus { get; set; }

        public Property(string type, string status)
        {
            RecycleType = type;
            RecycleStatus = status;
        }
    }
}
