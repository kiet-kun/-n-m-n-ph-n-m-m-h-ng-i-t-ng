using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Data.Entity;

namespace QuanLyKho.Data.Seed
{
    internal class TransactionTypeSeed : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.HasData(new TransactionType { Id = 1, TransactionTypeName = "Nhập kho", CreateDate = DateTime.Now },
                            new TransactionType { Id = 2, TransactionTypeName = "Xuất kho", CreateDate = DateTime.Now },
                            new TransactionType { Id = 3, TransactionTypeName = "Chuyển hàng", CreateDate = DateTime.Now });
        }
    }
}
