using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ButaAdminTask.Models
{
    public class Members
    {
        public int Id { get; set; }       
        public string FullName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string University { get; set; }
        public string Profession { get; set; }
        public string Course { get; set; }
        public bool IsDeactive { get; set; }


    }
}
