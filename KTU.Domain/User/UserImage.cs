using KTU.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTU.Domain.User
{
    public class UserImage : Entity
    {
		public string FileName { get; set; }
		public byte[] Photo { get; set; }

		public int UserId { get; set; }

		public virtual User User { get; set; }
    }
}
