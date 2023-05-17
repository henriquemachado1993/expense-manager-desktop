
using ExpenseManagerDesktop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ExpenseManagerDesktop.Infra.Mappings
{
    public class ExpenseMap : MapBase<Expense>
    {
        public override void Configure(EntityTypeBuilder<Expense> builder)
        {
            base.Configure(builder);
            builder.ToTable("Expense");
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasColumnType("Decimal(14,2)");

            // Relationships
            builder.HasOne(x => x.Category);
            builder.HasOne(x => x.User);
        }
    }
}
