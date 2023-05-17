
using ExpenseManagerDesktop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManagerDesktop.Infra.Mappings
{
    public class UserMap : MapBase<User>
    {
        public virtual void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("User");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Keyword).IsRequired();
            builder.Property(x => x.Password).IsRequired();

            // Relationships
            builder.HasMany(x => x.Expenses);
            builder.HasMany(x => x.BankAccounts);
        }
    }
}
