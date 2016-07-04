using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace KTU.WebApp.Model
{
    public class LoginViewModel
    {
		[Required(ErrorMessage ="Please input this field")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Please input this field")]
		public string Password { get; set; }
    }
}
