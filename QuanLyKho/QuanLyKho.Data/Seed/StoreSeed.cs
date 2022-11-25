using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Data.Entity;

namespace QuanLyKho.Data.Seed
{
    internal class StoreSeed : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(
                    new Store { 
                        Id = 1, 
                        StoreCode = "KQT-HCM", 
                        StoreName = "CỬA HÀNG KQT 81-81A ĐƯỜNG 339 TẠI HỒ CHÍ MINH", 
                        diachi = "81-81A Đường 339, Khu phố 4, phường Phước Long B, thành phố Thủ Đức, Thành phố Hồ Chí Minh",
                        CreateDate = DateTime.Now 
                    },
                    new Store
                    {
                        Id = 2,
                        StoreCode = "KQT-HCM",
                        StoreName = "CỬA HÀNG KQT THỬA ĐẤT SỐ 1509 - 1512 TẠI HỒ CHÍ MINH",
                        diachi = "Thửa đất số 1509 - 1512, tờ bản đồ số 22, phường Thạnh Mỹ Lợi, Tp. Thủ Đức, TP Hồ Chí Minh",
                        CreateDate = DateTime.Now
                    },
                    new Store
                    {
                        Id = 3,
                        StoreCode = "KQT-HCM",
                        StoreName = "CỬA HÀNG KQT SỐ 1B THÍCH QUẢNG ĐỨC TẠI HỒ CHÍ MINH",
                        diachi = "Số 1B Thích Quảng Đức, Phường 03, Quận Phú Nhuận, TP. Hồ Chí Minh (ngã 4 Thích Quảng Đức - Phan Đăng Lưu",
                        CreateDate = DateTime.Now
                    },
                    new Store
                    {
                        Id = 4,
                        StoreCode = "KQT-HCM",
                        StoreName = "CỬA HÀNG KQT 28/10B TẠI HỒ CHÍ MINH",
                        diachi = "28/10B, Ấp Trung Đông, Xã Thới Tam Thôn, Huyện Hóc Môn, Thành phố Hồ Chí Minh, Việt Nam",
                        CreateDate = DateTime.Now
                    },
                    new Store
                    {
                        Id = 5,
                        StoreCode = "KQT-HCM",
                        StoreName = "CỬA HÀNG KQT 32 ĐƯỜNG THẠNH XUÂN 25 TẠI HỒ CHÍ MINH",
                        diachi = "32 đường Thạnh Xuân 25, Khu phố 3, Phường Thạnh Xuân, Quận 12, Thành phố Hồ Chí Minh, Việt Nam",
                        CreateDate = DateTime.Now
                    }
                );
           
        }
    }
}
