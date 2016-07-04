using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTU.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using KTU.DataAccess.Mapping;
using KTU.Domain.User;

namespace KTU.DataAccess
{
    public class SimpleDbContext : DbContext
    {
	    public SimpleDbContext(DbContextOptions option) : base(option)
	    {
				
	    }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			new UserMapping(modelBuilder.Entity<User>());
			new UserDetailMappingcs(modelBuilder.Entity<UserDetail>());
			new UserImageMapping(modelBuilder.Entity<UserImage>());
			new AddressMapping(modelBuilder.Entity<Address>());

		}

		public DbSet<User> Users { get; set; }
		public DbSet<UserDetail> UserDetails { get; set; }
		public DbSet<UserImage> UserImages { get; set; }
		public DbSet<Address> Address { get; set; }

	}
}
