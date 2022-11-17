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
            builder.HasData(new UnitOfMeasure { Id = 1, UnitOfMeasureName = "Mẩu", Isocode = "pc", CreateDate = DateTime.Now });
            builder.HasData(new UnitOfMeasure { Id = 2, UnitOfMeasureName = "Kilôgram", Isocode = "kg", CreateDate = DateTime.Now });
            builder.HasData(new UnitOfMeasure { Id = 3, UnitOfMeasureName = "Mét", Isocode = "m", CreateDate = DateTime.Now });
        }
    }
}
