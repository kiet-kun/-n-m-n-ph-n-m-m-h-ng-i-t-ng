using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyKho.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.Data.Seed
{
    internal class NhaCungCapSeed : IEntityTypeConfiguration<NhaCungCap>
    {
        public void Configure(EntityTypeBuilder<NhaCungCap> builder)
        {
            builder.HasData(
                new NhaCungCap { 
                    Id = 1, 
                    TenNhaCungCap = "Thực Phẩm Công Danh - Công Ty TNHH MTV SX TM Thực Phẩm Công Danh", 
                    DiaChi = "Lô A4- Đường NB, Cụm Nhị Xuân, X. Xuân Thới Sơn, H. Hóc Môn Tp. Hồ Chí Minh (TPHCM)",
                    SoDienThoai = "0908 838 848",
                    Email = "cd@congdanh.vn",
                    NguoiDaiDien = "Ngô Bình An",
                    CreateDate = DateTime.Now
                },
                new NhaCungCap
                {
                    Id = 2,
                    TenNhaCungCap = "Thực Phẩm Duy Anh - Công Ty TNHH Xuất Nhập Khẩu Thực Phẩm Duy Anh",
                    DiaChi = "368/4 Tỉnh Lộ 15, Ấp Bến Cỏ, X. Phú Hòa Đông, H. Củ Chi, Tp. Hồ Chí Minh (TPHCM)",
                    SoDienThoai = "0903 646 487",
                    Email = "duyanhfoodscuchi@gmail.com",
                    NguoiDaiDien = "Trần Phú Ân",
                    CreateDate = DateTime.Now
                },
                new NhaCungCap
                {
                    Id = 3,
                    TenNhaCungCap = "Công Ty TNHH Chế Biến Thực Phẩm Nước Giải Khát Quang Minh",
                    DiaChi = "Khu Công Nghiệp Cát Lái, 934D1 Đường D, P. Thạnh Mỹ Lợi, Q. 2, Tp. Hồ Chí Minh (TPHCM), Việt Nam",
                    SoDienThoai = "(028) 37421343",
                    Email = "phongkinhdoanh@gasaco.com.vn",
                    NguoiDaiDien = "Nguyễn Ðức Bảo",
                    CreateDate = DateTime.Now
                },
                 new NhaCungCap
                 {
                     Id = 4,
                     TenNhaCungCap = "Gia Vị Nosafood - Công Ty Cổ Phần Nosafood",
                     DiaChi = "E4/20 Nguyễn Hữu Trí, Thị Trấn Tân Túc, Huyện Bình Chánh, Tp. Hồ Chí Minh (TPHCM), Việt Nam",
                     SoDienThoai = "0972 333 601",
                     Email = "tmdt@nosafood.com",
                     NguoiDaiDien = "Nguyễn Vinh Diệu",
                     CreateDate = DateTime.Now
                 },
                  new NhaCungCap
                  {
                      Id = 5,
                      TenNhaCungCap = "Công Ty TNHH Oriflame Việt Nam",
                      DiaChi = "216R Quang Trung, P. 10, Q. Gò Vấp, Tp. Hồ Chí Minh (TPHCM), Việt Nam",
                      SoDienThoai = "0975 559 016",
                      Email = "info@oriflame.com.vn",
                      NguoiDaiDien = "Lê Gia Ðức ",
                      CreateDate = DateTime.Now
                  }
            );
        }
    }
}
