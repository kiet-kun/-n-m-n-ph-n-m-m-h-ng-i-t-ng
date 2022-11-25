using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Data.Entity;

namespace QuanLyKho.Data.Seed
{
    internal class UnitOfMeasureSeed : IEntityTypeConfiguration<UnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            builder.HasData(new UnitOfMeasure { Id = 1, UnitOfMeasureName = "Sản phẩm", Isocode = "sp", CreateDate = DateTime.Now });
            builder.HasData(new UnitOfMeasure { Id = 2, UnitOfMeasureName = "Kilôgram", Isocode = "kg", CreateDate = DateTime.Now });
        }
    }
}
