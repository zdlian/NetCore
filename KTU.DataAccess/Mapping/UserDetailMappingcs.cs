using KTU.Domain.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace KTU.DataAccess.Mapping
{
    public class UserDetailMappingcs
    {
		public UserDetailMappingcs(EntityTypeBuilder<UserDetail> builder)
		{
			builder.HasKey(s => s.Id);
			builder.Property(s => s.Id).ValueGeneratedOnAdd();
			builder.Property(s => s.Company);
			builder.Property(s => s.DayOfBirth);
			builder.Property(s => s.Email);
			builder.Property(s => s.FirstName);
			builder.Property(s => s.LastName);
			builder.ToTable("UserDetail");
		}
	}
}
