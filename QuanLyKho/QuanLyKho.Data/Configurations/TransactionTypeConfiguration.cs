﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Data.Entity;

namespace QuanLyKho.Data.Configurations
{
    internal class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TransactionTypeName).IsRequired().HasMaxLength(50);
            builder.ToTable("TransactionType");
        }
    }
}
