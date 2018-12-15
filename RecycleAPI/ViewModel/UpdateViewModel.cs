using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleAPI.ViewModel
{
    public class UpdateViewModel
    {
        public string Id { get; set; }
        public TypeEnum TypeId { get; set; }
        public StatusEnum StatusId { get; set; }
    }
}
