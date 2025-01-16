using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace meeting_app.Models
{
    public class UserInfo
    {
        public int Id {get ; set;}
        [Required(ErrorMessage ="Bu alan zorunludur.")]
        public string? Name {get; set;}
        [Required(ErrorMessage ="Bu alan zorunludur.")]
        public string? Phone {get; set;}
        [Required(ErrorMessage ="Bu alan zorunludur.")]
        [EmailAddress(ErrorMessage ="Hatali Mail")]
        public string? Email {get; set;}
        [Required(ErrorMessage ="Bu alan zorunludur.")]
        public bool WillAttend {get; set;}
    }
}