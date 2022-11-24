using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyKho.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Data.Seed
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                 new Category { Id = 1 , CategoryName = "THỊT, CÁ, TRỨNG, HẢI SẢN", CreateDate = DateTime.Now},
                 new Category { Id = 2, CategoryName = "RAU, CỦ, TRÁI CÂY", CreateDate = DateTime.Now },
                 new Category { Id = 3, CategoryName = "THỰC PHẨM ĐÔNG - MÁT", CreateDate = DateTime.Now },
                 new Category { Id = 4, CategoryName = "MÌ, MIẾN, CHÁO, PHỞ", CreateDate = DateTime.Now },
                 new Category { Id = 5, CategoryName = "GẠO, BỘT, ĐỒ KHÔ", CreateDate = DateTime.Now },
                 new Category { Id = 6, CategoryName = "DẦU ĂN, NƯỚC CHẤM, GIA VỊ", CreateDate = DateTime.Now },
                 new Category { Id = 7, CategoryName = "BIA, NƯỚC GIẢI KHÁT", CreateDate = DateTime.Now },
                 new Category { Id = 8, CategoryName = "SỮA CÁC LOẠI", CreateDate = DateTime.Now },
                 new Category { Id = 9, CategoryName = "BÁNH KẸO CÁC LOẠI", CreateDate = DateTime.Now },
                 new Category { Id = 10, CategoryName = "CHĂM SÓC CÁ NHÂN", CreateDate = DateTime.Now },
                 new Category { Id = 11, CategoryName = "SẢN PHẨM CHO MẸ VÀ BÉ", CreateDate = DateTime.Now },
                 new Category { Id = 12, CategoryName = "VỆ SINH NHÀ CỬA", CreateDate = DateTime.Now },
                 new Category { Id = 13, CategoryName = "ĐỒ DÙNG GIA ĐÌNH", CreateDate = DateTime.Now }
            ) ;
        }
    }
}
