using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UnitunesMvc.Models
{
    public class LoginViewModel
    {
   
        [Required]
        public string Email{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
   
    }
}