using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTU.Services.Services.UserService;
using KTU.Domain.User;

namespace KTU.Services
{
    public interface IUserService
    {
		IEnumerable<User> Get();
		bool CheckUser(string userName, string password);
	}
}
