using KTU.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTU.Domain.User
{
    public class UserDetail : Entity
    {
		public string PhoneNo { get; set; }
		public DateTime DayOfBirth { get; set; }
		public string FirstName { get; set; }

		public string LastName { get; set; }
		public string Company { get; set; }
		public string Email { get; set; }


		public virtual User User { get; set; }

	}
}
