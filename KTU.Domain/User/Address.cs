using KTU.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTU.Domain.User
{
    public class Address : Entity
    {
		public string Street { get; set; }
		public string HouseNo { get; set; }
		public string PostCode { get; set; }

		public int UserId { get; set; }

		public virtual User User {get;set;}
	}
}
