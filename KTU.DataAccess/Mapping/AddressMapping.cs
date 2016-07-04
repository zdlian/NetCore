using KTU.Domain.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KTU.DataAccess.Mapping
{
    public class AddressMapping
    {
		public AddressMapping(EntityTypeBuilder<Address> builder)
		{
			builder.HasKey(s => s.Id);
			builder.Property(s => s.HouseNo);
			builder.Property(s => s.PostCode);
			builder.Property(s => s.Street);
		}
	}
}
