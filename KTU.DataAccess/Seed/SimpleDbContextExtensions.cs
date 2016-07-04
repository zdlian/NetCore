using KTU.DataAccess;
using KTU.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTU.DataAccess.Seed
{
	public static class SimpleDbContextExtensions
	{
		public static void EnsureSeedData(this SimpleDbContext context)
		{
			context.Database.EnsureCreated();

			if (!context.Users.Any())
			{
				context.Users.Add(new Domain.User.User()
				{
					UserName = "tiepkn",
					Password = "gcsvn123",
					Address = new List<Address>() { },
					UserDetail = new UserDetail() {
						Company = "Test",
						DayOfBirth = DateTime.Now,
						Email = "test@gmail.com",
						LastName ="Nguyen",
						FirstName = "ff",
						PhoneNo = "tiep",
					},
					UserImage = new List<UserImage>(),
				});
				context.SaveChanges();
			}

		}
	}

}
