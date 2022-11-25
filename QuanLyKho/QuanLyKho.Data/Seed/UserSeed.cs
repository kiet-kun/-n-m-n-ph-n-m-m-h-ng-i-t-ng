using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Data.Entity;
using QuanLyKho.Common.Extensions;

namespace QuanLyKho.Data.Seed
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        string adminPassword = "12345";
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Email = "admin@admin.com", Name = "Admin", Surname = "Admin", Password = adminPassword.MD5Hash(), CreateDate = DateTime.Now },
                new User { Id = 2, Email = "TranHuuThong@gmail.com", Name = "Thống", Surname = "Trần Hữu", Password = adminPassword.MD5Hash(), CreateDate = DateTime.Now,
                    sdt = "099 198 37 36",
                    cmnd = "6373891990",
                },
                new User
                {
                    Id = 3,
                    Email = "LeQuocThang@gmail.com",
                    Name = "Thắng",
                    Surname = "Lê Quốc",
                    Password = adminPassword.MD5Hash(),
                    CreateDate = DateTime.Now,
                    sdt = "099 198 37 36",
                    cmnd = "6373891990",
                    ngaysinh = DateTime.Now
                },
                new User
                {
                    Id = 4,
                    Email = "NguyenNhatTien@gmail.com",
                    Name = "Tiến",
                    Surname = "Nguyễn Nhất",
                    Password = adminPassword.MD5Hash(),
                    CreateDate = DateTime.Now,
                    sdt = "099 198 37 36",
                    cmnd = "6373891990",
                    ngaysinh = DateTime.Now
                },
                new User
                {
                    Id = 5,
                    Email = "ChuMinhNghia@gmail.com",
                    Name = "Chu",
                    Surname = "Minh Nghĩa",
                    Password = adminPassword.MD5Hash(),
                    CreateDate = DateTime.Now,
                    sdt = "099 198 37 36",
                    cmnd = "6373891990",
                    ngaysinh = DateTime.Now
                }
            );
        }
    }
}
