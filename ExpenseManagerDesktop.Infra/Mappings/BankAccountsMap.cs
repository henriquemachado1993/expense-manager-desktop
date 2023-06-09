﻿using ExpenseManagerDesktop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ExpenseManagerDesktop.Infra.Mappings
{
    public class BankAccountsMap : MapBase<BankAccounts>
    {
        public override void Configure(EntityTypeBuilder<BankAccounts> builder)
        {
            base.Configure(builder);
            builder.ToTable("BankAccounts");
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.AccountValue).IsRequired().HasColumnType("Decimal(14,2)");

            // Relationships
            builder.HasOne(x => x.User);
        }
    }
}
