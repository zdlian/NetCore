using KTU.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using KTU.Domain.User;

namespace KTU.DataAccess.Mapping
{
	public class UserMapping
    {
		public UserMapping(EntityTypeBuilder<User> entityBuilder)
		{
			entityBuilder.HasKey(x => x.Id);
			entityBuilder.Property(s => s.Id).ValueGeneratedOnAdd();
			entityBuilder.Property(s => s.Password);

			// Mapping one to one to UserDetail
			entityBuilder.HasOne(s=>s.UserDetail)
				          .WithOne(s => s.User)
						  .HasForeignKey<User>(s => s.UserDetailId);

			// Mapping one to many with Address
			entityBuilder.HasMany(s=>s.Address).WithOne(s => s.User).HasForeignKey(s=>s.UserId);

			// Mapping one to many with User Image
			entityBuilder.HasMany(s=>s.UserImage).WithOne(s => s.User).HasForeignKey(s=>s.UserId);

			entityBuilder.ToTable("User");

		}
    }
}
