
using ExpenseManagerDesktop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ExpenseManagerDesktop.Infra.Mappings
{
    public class CategoryMap : MapBase<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.ToTable("Category");
            builder.Property(x => x.Title).IsRequired();

            // Relationships
            builder.HasMany(x => x.Expenses);
        }
    }
}
