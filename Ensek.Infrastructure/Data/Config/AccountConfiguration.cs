using Ensek.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ensek.Infrastructure.Data.Config
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(c => c.AccountId).ValueGeneratedNever();
            builder.Property(c => c.FirstName).IsRequired().HasColumnType("varchar(100)");
            builder.Property(c => c.LastName).IsRequired().IsRequired().HasColumnType("varchar(100)");
        }
    }
}