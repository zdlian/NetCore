using KTU.Domain.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace KTU.DataAccess.Mapping
{
    public class UserImageMapping
    {
		public UserImageMapping(EntityTypeBuilder<UserImage> builder)
		{
			builder.HasKey(s => s.Id);
			builder.Property(s => s.FileName);
			builder.Property(s => s.Photo);

			builder.ToTable("UserImage");
		}
    }
}
