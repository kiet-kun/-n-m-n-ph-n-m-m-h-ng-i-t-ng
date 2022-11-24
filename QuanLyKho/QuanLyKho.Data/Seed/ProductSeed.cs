using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

using QuanLyKho.Data.Entity;
using System.Collections.Generic;

namespace QuanLyKho.Data.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            List<Product> list = new List<Product>();
            List<string> name = new List<string>();
            int index = 0;

            //THỊT, CÁ, TRỨNG, HẢI SẢN
            name = new List<string>(
                new string[]
                {
                    "Thịt ba rọi bò Thảo Tiến Foods khay 300g",
                    "Ba rọi heo C.P khay 500g",
                    "Ức gà tươi phi lê C.P khay 500g (1-3 miếng)",
                    "Tôm thẻ nguyên con khay 250g (10 - 13 con)",
                    "Cá hồi đông lạnh cắt khúc khay 300g",
                    "Hộp 10 trứng gà tươi 4KFarm"
                }
            );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 1;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //RAU, CỦ, TRÁI CÂY
            name = new List<string>(
               new string[]
               {
                    "Cải bẹ xanh baby gói 300g",
                    "Xà lách lolo xanh thủy canh gói 300g",
                    "Giá đậu xanh gói 200g",
                    "Ớt hiểm trái túi 50g",
                    "Tắc trái túi 200g (20 - 21 trái)",
                    "Cà rốt baby vỉ 500g",
                    "Khổ qua khay 500g (3-5 trái)",
                    "Khoai lang Nhật túi 1kg (4 - 10 củ)",
                    "Bí đỏ tròn túi 500g",
                    "Táo Queen nhập khẩu New Zealand hộp 1kg (5-7 trái)",
                    "Táo Ninh Thuận túi 1kg (25 - 30 trái)",
                    "Bưởi năm roi trái từ 1.3kg - 1.4kg"
               }
           );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 2;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //THỰC PHẨM ĐÔNG - MÁT
            name = new List<string>(
               new string[]
               {
                    "Kem que Topten Socola Wall's 55g",
                    "2 hộp kem vani sốt socola Wall's 450g",
                    "Bánh mì tươi đông lạnh O'smiles 350g",
                    "Bánh mì que không nhân Vbread túi 10 cái x 30g",
                    "TChả lụa bì ớt xiêm xanh G Kitchen cây 500g",
                    "Xúc xích phô mai Kichi Kichi Icook khay 340g",
                    "Chả giò hải sản trái cây La Cusina gói 300g",
                    "Mực viên Bếp 5 sao gói 200g",
                    "Phô mai Vinamilk hộp 120g (8 miếng)",
                    "Sữa uống lên men hương tự nhiên Betagen chai 400ml",
                    "Kim chi cải thảo cắt lát Bibigo Ông Kim's gói 100g",
                    "Ớt ngâm chua ngọt Sông Hương hũ 350g"
               }
           );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 3;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //MÌ, MIẾN, CHÁO, PHỞ
            name = new List<string>(
               new string[]
               {
                    "Thùng 30 gói mì Hảo Hảo tôm chua cay 75g",
                    "Thùng 30 gói mì 3 Miền tôm chua cay 65g",
                    "Thùng 30 gói mì Kokomi 90 tôm chua cay 90g",
               }
           );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 4;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //GẠO, BỘT, ĐỒ KHÔ
            name = new List<string>(
               new string[]
               {
                    "Gạo thơm A An ST21 túi 5kg",
                    "Gạo trắng Thiên Nhật túi 5kg",
               }
           );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 5;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //DẦU ĂN, NƯỚC CHẤM, GIA VỊ
            name = new List<string>(
              new string[]
              {
                    "Dầu thực vật Nakydaco Cooking Oil chai 1 lít",
                    "Đường mía thượng hạng Biên Hòa gói 1kg",
                    "Bột ngọt hạt lớn Ajinomoto gói 454g",
                    "Muối biển Bạc Liêu cao cấp gói 500g",
                    "Nước mắm Nam Ngư 10 độ đạm chai 900ml",
                    "Nước tương đậu nành đậm đặc Maggi chai 700ml",
                    "Dầu hào đậm đặc Maggi chai 530g",
              }
          );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 6;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //BIA, NƯỚC GIẢI KHÁT
            name = new List<string>(
              new string[]
              {
                    "Thùng 24 lon bia Sài Gòn Lager 330ml",
                    "Thùng 24 lon bia Heineken Sleek 330ml",
                    "Rượu soju Good Day vị đào 13.5% chai 360ml",
                    "6 lon nước ngọt Coca Cola 235ml",
                    "6 chai nước ngọt Sprite hương chanh 390ml",
                    "6 lon nước tăng lực Redbull 250ml",
                    "6 chai Sting hương dâu 330ml",
                    "Đá me hạt mềm Thanh Bình 900g",
                    "Cà phê sữa đá NesCafé nhân đôi sánh quyện 600g",
                    "Cà phê sữa VinaCafé Gold Original 480g"
              }
          );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 7;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //SỮA CÁC LOẠI
            name = new List<string>(
              new string[]
              {
                    "Thùng 48 hộp sữa tươi có đường Vinamilk 180ml",
                    "Thùng 48 hộp sữa tươi tiệt trùng vị tự nhiên TH true MILK Hilo 180ml",
              }
          );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 8;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //BÁNH KẸO CÁC LOẠI
            name = new List<string>(
              new string[]
              {
                    "Kẹo mút hữu cơ 4 hương vị trái cây Yumearth gói 241g",
                    "Bánh quy kem vị cacao Lotte Sand hộp 315g",
                    "Socola sữa hạnh nhân Bernique hộp 450g"
              }
          );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 9;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //CHĂM SÓC CÁ NHÂN
            name = new List<string>(
              new string[]
              {
                    "Khăn ướt Yuniku hương trà xanh gói 20 miếng - giao màu ngẫu nhiên",
                    "Dầu gội tinh dầu Iron Stone For Men Woody Space 620ml",
                    "Dầu gội sạch gàu Clear Men Deep Cleanse sạch sâu 175ml",
                    "Sữa tắm bảo vệ khỏi vi khuẩn Lifebuoy 980ml",
                    "Kem đánh răng Colgate MaxFresh hương trà xanh 230g",
                    "Bộ 3 bàn chải đánh răng Puri Slim Tips Charcoal siêu mềm",
                    "Khẩu trang y tế Promask N95 FFP2 5 lớp hộp 20 cái"
              }
          );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 10;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //SẢN PHẨM CHO MẸ VÀ BÉ
            name = new List<string>(
              new string[]
              {
                    "Sữa bột Frisolac Gold số 4 lon 380g",
                    "Tã quần Huggies Dry size XL 62 miếng (cho bé 12 - 17kg)",
              }
          );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 11;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //VỆ SINH NHÀ CỬA
            name = new List<string>(
              new string[]
              {
                    "Bột giặt IZI HOME trắng sáng 3kg",
                    "Nước rửa chén Lix Vitamin E siêu sạch hương trà xanh can 3.53 lít",
                    "Nước gel tẩy bồn cầu VIM xanh biển diệt khuẩn hương dịu nhẹ chai 880ml",
                    "Nước lau sàn Sunlight tinh dầu thảo mộc hương chanh yuzu và sả ngăn côn trùng túi 3.38 lít",

              }
          );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 12;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            //ĐỒ DÙNG GIA ĐÌNH
            name = new List<string>(
              new string[]
              {
                    "Lốc 3 cuộn túi rác đen tự huỷ sinh học Bách Hóa XANH 64x78cm (1kg)",
                    "Bộ bình ly thuỷ tinh Luminarc Rotterdam Blue 5pcs 350ml",
                    "Bộ 3 nồi nhôm quai tròn xi bóng t3 nhỏ Kim Hằng Bạch Đằng",
                    "Bộ 10 đôi đũa gỗ cẩm lai tiện tròn Thanh Tú 25cm",
                    "Khay đá nhỏ nhựa 10 viên Hofaco HPL04 (giao màu ngẫu nhiên)",
              }
          );
            foreach (var item in name)
            {
                Product product = new Product();
                index++;
                product.Id = index;
                product.CreateDate = DateTime.Now;
                product.ProductName = item;
                product.CategoryId = 13;
                product.UnitOfMeasureId = 1; // sản phẩm
                list.Add(product);
            }

            builder.HasData(
                list.ToArray()
            );
        }
    }
}
