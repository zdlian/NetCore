using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTU.Core;

namespace KTU.Domain.User
{
    public class User : Entity
    {
	    public string UserName { get; set; }
	    public string Password { get; set; }

		public int UserDetailId { get; set; }

		public virtual IList<Address> Address { get; set; }
		public virtual UserDetail UserDetail{ get; set; }
		public virtual IList<UserImage> UserImage { get; set; }
    }
}
