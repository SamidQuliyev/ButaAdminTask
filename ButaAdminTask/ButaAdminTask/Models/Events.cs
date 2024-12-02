using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButaAdminTask.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventPlace { get; set; }
        public string Duration { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsDeactive { get; set; }
    }
}

