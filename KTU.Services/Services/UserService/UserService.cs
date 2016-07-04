using System;
using System.Collections.Generic;
using System.Linq;
using KTU.DataAccess.Repository;
using KTU.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace KTU.Services.Services.UserService
{
    public class UserService : IUserService
    {
		private readonly IGenericRepository<User> _userRepository;

		public UserService(IGenericRepository<User> userRepository)
		{
			this._userRepository = userRepository;
		}

		public bool CheckUser(string userName, string password)
		{
			return _userRepository.Get(s => s.UserName == userName && 
											s.Password == password).Any();
		}

		IEnumerable<User> IUserService.Get()
		{
			return _userRepository.Get().Include(s=>s.UserDetail);
		}
	}
}
