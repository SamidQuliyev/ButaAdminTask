using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ButaAdminTask.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Bu sahə boş ola bilməz")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bu sahə boş ola bilməz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bu sahə boş ola bilməz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu sahə boş ola bilməz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu sahə boş ola bilməz")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string CheckPassword { get; set; }
        
    }
}
