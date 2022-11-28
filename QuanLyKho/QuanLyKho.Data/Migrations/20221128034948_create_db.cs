﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyKho.Data.Migrations
{
    public partial class create_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhoTong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    khotongcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoTong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhaCungCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitOfMeasureName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Isocode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    cmnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ToStoreId = table.Column<int>(type: "int", nullable: true),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Store_ToStoreId",
                        column: x => x.ToStoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreStock",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreStock", x => new { x.StoreId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_StoreStock_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreStock_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetail",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetail", x => new { x.TransactionId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "CreateDate" },
                values: new object[,]
                {
                    { 1, "THỊT, CÁ, TRỨNG, HẢI SẢN", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7837) },
                    { 2, "RAU, CỦ, TRÁI CÂY", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7901) },
                    { 3, "THỰC PHẨM ĐÔNG - MÁT", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7903) },
                    { 4, "MÌ, MIẾN, CHÁO, PHỞ", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7905) },
                    { 5, "GẠO, BỘT, ĐỒ KHÔ", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7907) },
                    { 6, "DẦU ĂN, NƯỚC CHẤM, GIA VỊ", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7909) },
                    { 7, "BIA, NƯỚC GIẢI KHÁT", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7911) },
                    { 8, "SỮA CÁC LOẠI", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7913) },
                    { 9, "BÁNH KẸO CÁC LOẠI", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7915) },
                    { 10, "CHĂM SÓC CÁ NHÂN", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7917) },
                    { 11, "SẢN PHẨM CHO MẸ VÀ BÉ", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7918) },
                    { 12, "VỆ SINH NHÀ CỬA", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7920) },
                    { 13, "ĐỒ DÙNG GIA ĐÌNH", new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(7922) }
                });

            migrationBuilder.InsertData(
                table: "NhaCungCap",
                columns: new[] { "Id", "CreateDate", "DiaChi", "Email", "NguoiDaiDien", "SoDienThoai", "TenNhaCungCap" },
                values: new object[,]
                {
                    { 5, new DateTime(2022, 11, 28, 10, 49, 47, 468, DateTimeKind.Local).AddTicks(6042), "216R Quang Trung, P. 10, Q. Gò Vấp, Tp. Hồ Chí Minh (TPHCM), Việt Nam", "info@oriflame.com.vn", "Lê Gia Ðức ", "0975 559 016", "Công Ty TNHH Oriflame Việt Nam" },
                    { 3, new DateTime(2022, 11, 28, 10, 49, 47, 468, DateTimeKind.Local).AddTicks(6037), "Khu Công Nghiệp Cát Lái, 934D1 Đường D, P. Thạnh Mỹ Lợi, Q. 2, Tp. Hồ Chí Minh (TPHCM), Việt Nam", "phongkinhdoanh@gasaco.com.vn", "Nguyễn Ðức Bảo", "(028) 37421343", "Công Ty TNHH Chế Biến Thực Phẩm Nước Giải Khát Quang Minh" },
                    { 4, new DateTime(2022, 11, 28, 10, 49, 47, 468, DateTimeKind.Local).AddTicks(6039), "E4/20 Nguyễn Hữu Trí, Thị Trấn Tân Túc, Huyện Bình Chánh, Tp. Hồ Chí Minh (TPHCM), Việt Nam", "tmdt@nosafood.com", "Nguyễn Vinh Diệu", "0972 333 601", "Gia Vị Nosafood - Công Ty Cổ Phần Nosafood" },
                    { 1, new DateTime(2022, 11, 28, 10, 49, 47, 468, DateTimeKind.Local).AddTicks(5942), "Lô A4- Đường NB, Cụm Nhị Xuân, X. Xuân Thới Sơn, H. Hóc Môn Tp. Hồ Chí Minh (TPHCM)", "cd@congdanh.vn", "Ngô Bình An", "0908 838 848", "Thực Phẩm Công Danh - Công Ty TNHH MTV SX TM Thực Phẩm Công Danh" },
                    { 2, new DateTime(2022, 11, 28, 10, 49, 47, 468, DateTimeKind.Local).AddTicks(6034), "368/4 Tỉnh Lộ 15, Ấp Bến Cỏ, X. Phú Hòa Đông, H. Củ Chi, Tp. Hồ Chí Minh (TPHCM)", "duyanhfoodscuchi@gmail.com", "Trần Phú Ân", "0903 646 487", "Thực Phẩm Duy Anh - Công Ty TNHH Xuất Nhập Khẩu Thực Phẩm Duy Anh" }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "CreateDate", "StoreCode", "StoreName", "diachi" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 28, 10, 49, 47, 465, DateTimeKind.Local).AddTicks(6152), "KQT-HCM", "CỬA HÀNG KQT 81-81A ĐƯỜNG 339 TẠI HỒ CHÍ MINH", "81-81A Đường 339, Khu phố 4, phường Phước Long B, thành phố Thủ Đức, Thành phố Hồ Chí Minh" },
                    { 2, new DateTime(2022, 11, 28, 10, 49, 47, 465, DateTimeKind.Local).AddTicks(6234), "KQT-HCM", "CỬA HÀNG KQT THỬA ĐẤT SỐ 1509 - 1512 TẠI HỒ CHÍ MINH", "Thửa đất số 1509 - 1512, tờ bản đồ số 22, phường Thạnh Mỹ Lợi, Tp. Thủ Đức, TP Hồ Chí Minh" },
                    { 3, new DateTime(2022, 11, 28, 10, 49, 47, 465, DateTimeKind.Local).AddTicks(6237), "KQT-HCM", "CỬA HÀNG KQT SỐ 1B THÍCH QUẢNG ĐỨC TẠI HỒ CHÍ MINH", "Số 1B Thích Quảng Đức, Phường 03, Quận Phú Nhuận, TP. Hồ Chí Minh (ngã 4 Thích Quảng Đức - Phan Đăng Lưu" },
                    { 4, new DateTime(2022, 11, 28, 10, 49, 47, 465, DateTimeKind.Local).AddTicks(6239), "KQT-HCM", "CỬA HÀNG KQT 28/10B TẠI HỒ CHÍ MINH", "28/10B, Ấp Trung Đông, Xã Thới Tam Thôn, Huyện Hóc Môn, Thành phố Hồ Chí Minh, Việt Nam" },
                    { 5, new DateTime(2022, 11, 28, 10, 49, 47, 465, DateTimeKind.Local).AddTicks(6241), "KQT-HCM", "CỬA HÀNG KQT 32 ĐƯỜNG THẠNH XUÂN 25 TẠI HỒ CHÍ MINH", "32 đường Thạnh Xuân 25, Khu phố 3, Phường Thạnh Xuân, Quận 12, Thành phố Hồ Chí Minh, Việt Nam" }
                });

            migrationBuilder.InsertData(
                table: "TransactionType",
                columns: new[] { "Id", "CreateDate", "TransactionTypeName" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 11, 28, 10, 49, 47, 456, DateTimeKind.Local).AddTicks(3897), "Xuất kho" },
                    { 1, new DateTime(2022, 11, 28, 10, 49, 47, 455, DateTimeKind.Local).AddTicks(2151), "Nhập kho" },
                    { 3, new DateTime(2022, 11, 28, 10, 49, 47, 456, DateTimeKind.Local).AddTicks(3932), "Chuyển hàng" }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasure",
                columns: new[] { "Id", "CreateDate", "Isocode", "UnitOfMeasureName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(414), "sp", "Sản phẩm" },
                    { 2, new DateTime(2022, 11, 28, 10, 49, 47, 458, DateTimeKind.Local).AddTicks(792), "kg", "Kilôgram" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Email", "Name", "Password", "Surname", "cmnd", "ngaysinh", "sdt" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 11, 28, 10, 49, 47, 464, DateTimeKind.Local).AddTicks(9590), "LeQuocThang@gmail.com", "Thắng", "827ccb0eea8a706c4c34a16891f84e7b", "Lê Quốc", "6373891990", new DateTime(2022, 11, 28, 10, 49, 47, 464, DateTimeKind.Local).AddTicks(9623), "099 198 37 36" },
                    { 4, new DateTime(2022, 11, 28, 10, 49, 47, 465, DateTimeKind.Local).AddTicks(254), "NguyenNhatTien@gmail.com", "Tiến", "827ccb0eea8a706c4c34a16891f84e7b", "Nguyễn Nhất", "6373891990", new DateTime(2022, 11, 28, 10, 49, 47, 465, DateTimeKind.Local).AddTicks(259), "099 198 37 36" },
                    { 1, new DateTime(2022, 11, 28, 10, 49, 47, 464, DateTimeKind.Local).AddTicks(8276), "admin@admin.com", "Admin", "827ccb0eea8a706c4c34a16891f84e7b", "Admin", null, null, null },
                    { 2, new DateTime(2022, 11, 28, 10, 49, 47, 464, DateTimeKind.Local).AddTicks(8704), "TranHuuThong@gmail.com", "Thống", "827ccb0eea8a706c4c34a16891f84e7b", "Trần Hữu", "6373891990", null, "099 198 37 36" },
                    { 5, new DateTime(2022, 11, 28, 10, 49, 47, 465, DateTimeKind.Local).AddTicks(305), "ChuMinhNghia@gmail.com", "Chu", "827ccb0eea8a706c4c34a16891f84e7b", "Minh Nghĩa", "6373891990", new DateTime(2022, 11, 28, 10, 49, 47, 465, DateTimeKind.Local).AddTicks(306), "099 198 37 36" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Barcode", "CategoryId", "CreateDate", "Description", "Image", "Price", "ProductName", "UnitOfMeasureId" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(7917), null, null, null, "Thịt ba rọi bò Thảo Tiến Foods khay 300g", 1 },
                    { 54, null, 8, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9424), null, null, null, "Thùng 48 hộp sữa tươi tiệt trùng vị tự nhiên TH true MILK Hilo 180ml", 1 },
                    { 53, null, 8, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9421), null, null, null, "Thùng 48 hộp sữa tươi có đường Vinamilk 180ml", 1 },
                    { 52, null, 7, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9417), null, null, null, "Cà phê sữa VinaCafé Gold Original 480g", 1 },
                    { 51, null, 7, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9414), null, null, null, "Cà phê sữa đá NesCafé nhân đôi sánh quyện 600g", 1 },
                    { 50, null, 7, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9412), null, null, null, "Đá me hạt mềm Thanh Bình 900g", 1 },
                    { 49, null, 7, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9411), null, null, null, "6 chai Sting hương dâu 330ml", 1 },
                    { 48, null, 7, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9409), null, null, null, "6 lon nước tăng lực Redbull 250ml", 1 },
                    { 47, null, 7, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9407), null, null, null, "6 chai nước ngọt Sprite hương chanh 390ml", 1 },
                    { 46, null, 7, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9405), null, null, null, "6 lon nước ngọt Coca Cola 235ml", 1 },
                    { 45, null, 7, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9404), null, null, null, "Rượu soju Good Day vị đào 13.5% chai 360ml", 1 },
                    { 44, null, 7, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9402), null, null, null, "Thùng 24 lon bia Heineken Sleek 330ml", 1 },
                    { 43, null, 7, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9400), null, null, null, "Thùng 24 lon bia Sài Gòn Lager 330ml", 1 },
                    { 42, null, 6, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9394), null, null, null, "Dầu hào đậm đặc Maggi chai 530g", 1 },
                    { 41, null, 6, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9392), null, null, null, "Nước tương đậu nành đậm đặc Maggi chai 700ml", 1 },
                    { 40, null, 6, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9390), null, null, null, "Nước mắm Nam Ngư 10 độ đạm chai 900ml", 1 },
                    { 55, null, 9, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9429), null, null, null, "Kẹo mút hữu cơ 4 hương vị trái cây Yumearth gói 241g", 1 },
                    { 39, null, 6, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9388), null, null, null, "Muối biển Bạc Liêu cao cấp gói 500g", 1 },
                    { 56, null, 9, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9431), null, null, null, "Bánh quy kem vị cacao Lotte Sand hộp 315g", 1 },
                    { 58, null, 10, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9439), null, null, null, "Khăn ướt Yuniku hương trà xanh gói 20 miếng - giao màu ngẫu nhiên", 1 },
                    { 73, null, 13, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9512), null, null, null, "Bộ 3 nồi nhôm quai tròn xi bóng t3 nhỏ Kim Hằng Bạch Đằng", 1 },
                    { 72, null, 13, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9510), null, null, null, "Bộ bình ly thuỷ tinh Luminarc Rotterdam Blue 5pcs 350ml", 1 },
                    { 71, null, 13, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9508), null, null, null, "Lốc 3 cuộn túi rác đen tự huỷ sinh học Bách Hóa XANH 64x78cm (1kg)", 1 },
                    { 70, null, 12, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9469), null, null, null, "Nước lau sàn Sunlight tinh dầu thảo mộc hương chanh yuzu và sả ngăn côn trùng túi 3.38 lít", 1 },
                    { 69, null, 12, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9467), null, null, null, "Nước gel tẩy bồn cầu VIM xanh biển diệt khuẩn hương dịu nhẹ chai 880ml", 1 },
                    { 68, null, 12, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9465), null, null, null, "Nước rửa chén Lix Vitamin E siêu sạch hương trà xanh can 3.53 lít", 1 },
                    { 67, null, 12, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9463), null, null, null, "Bột giặt IZI HOME trắng sáng 3kg", 1 },
                    { 66, null, 11, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9458), null, null, null, "Tã quần Huggies Dry size XL 62 miếng (cho bé 12 - 17kg)", 1 },
                    { 65, null, 11, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9454), null, null, null, "Sữa bột Frisolac Gold số 4 lon 380g", 1 },
                    { 64, null, 10, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9450), null, null, null, "Khẩu trang y tế Promask N95 FFP2 5 lớp hộp 20 cái", 1 },
                    { 63, null, 10, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9448), null, null, null, "Bộ 3 bàn chải đánh răng Puri Slim Tips Charcoal siêu mềm", 1 },
                    { 62, null, 10, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9446), null, null, null, "Kem đánh răng Colgate MaxFresh hương trà xanh 230g", 1 },
                    { 61, null, 10, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9444), null, null, null, "Sữa tắm bảo vệ khỏi vi khuẩn Lifebuoy 980ml", 1 },
                    { 60, null, 10, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9443), null, null, null, "Dầu gội sạch gàu Clear Men Deep Cleanse sạch sâu 175ml", 1 },
                    { 59, null, 10, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9441), null, null, null, "Dầu gội tinh dầu Iron Stone For Men Woody Space 620ml", 1 },
                    { 57, null, 9, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9433), null, null, null, "Socola sữa hạnh nhân Bernique hộp 450g", 1 },
                    { 74, null, 13, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9514), null, null, null, "Bộ 10 đôi đũa gỗ cẩm lai tiện tròn Thanh Tú 25cm", 1 },
                    { 38, null, 6, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9386), null, null, null, "Bột ngọt hạt lớn Ajinomoto gói 454g", 1 },
                    { 36, null, 6, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9382), null, null, null, "Dầu thực vật Nakydaco Cooking Oil chai 1 lít", 1 },
                    { 16, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9201), null, null, null, "Táo Queen nhập khẩu New Zealand hộp 1kg (5-7 trái)", 1 },
                    { 15, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9199), null, null, null, "Bí đỏ tròn túi 500g", 1 },
                    { 14, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9197), null, null, null, "Khoai lang Nhật túi 1kg (4 - 10 củ)", 1 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Barcode", "CategoryId", "CreateDate", "Description", "Image", "Price", "ProductName", "UnitOfMeasureId" },
                values: new object[,]
                {
                    { 13, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9195), null, null, null, "Khổ qua khay 500g (3-5 trái)", 1 },
                    { 12, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9193), null, null, null, "Cà rốt baby vỉ 500g", 1 },
                    { 11, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9191), null, null, null, "Tắc trái túi 200g (20 - 21 trái)", 1 },
                    { 10, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9189), null, null, null, "Ớt hiểm trái túi 50g", 1 },
                    { 9, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9160), null, null, null, "Giá đậu xanh gói 200g", 1 },
                    { 8, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9097), null, null, null, "Xà lách lolo xanh thủy canh gói 300g", 1 },
                    { 7, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9095), null, null, null, "Cải bẹ xanh baby gói 300g", 1 },
                    { 6, null, 1, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9078), null, null, null, "Hộp 10 trứng gà tươi 4KFarm", 1 },
                    { 5, null, 1, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9071), null, null, null, "Cá hồi đông lạnh cắt khúc khay 300g", 1 },
                    { 4, null, 1, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9070), null, null, null, "Tôm thẻ nguyên con khay 250g (10 - 13 con)", 1 },
                    { 3, null, 1, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9067), null, null, null, "Ức gà tươi phi lê C.P khay 500g (1-3 miếng)", 1 },
                    { 2, null, 1, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9026), null, null, null, "Ba rọi heo C.P khay 500g", 1 },
                    { 17, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9203), null, null, null, "Táo Ninh Thuận túi 1kg (25 - 30 trái)", 1 },
                    { 37, null, 6, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9384), null, null, null, "Đường mía thượng hạng Biên Hòa gói 1kg", 1 },
                    { 18, null, 2, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9207), null, null, null, "Bưởi năm roi trái từ 1.3kg - 1.4kg", 1 },
                    { 20, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9216), null, null, null, "2 hộp kem vani sốt socola Wall's 450g", 1 },
                    { 35, null, 5, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9376), null, null, null, "Gạo trắng Thiên Nhật túi 5kg", 1 },
                    { 34, null, 5, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9374), null, null, null, "Gạo thơm A An ST21 túi 5kg", 1 },
                    { 33, null, 4, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9365), null, null, null, "Thùng 30 gói mì Kokomi 90 tôm chua cay 90g", 1 },
                    { 32, null, 4, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9362), null, null, null, "Thùng 30 gói mì 3 Miền tôm chua cay 65g", 1 },
                    { 31, null, 4, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9240), null, null, null, "Thùng 30 gói mì Hảo Hảo tôm chua cay 75g", 1 },
                    { 30, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9234), null, null, null, "Ớt ngâm chua ngọt Sông Hương hũ 350g", 1 },
                    { 29, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9233), null, null, null, "Kim chi cải thảo cắt lát Bibigo Ông Kim's gói 100g", 1 },
                    { 28, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9231), null, null, null, "Sữa uống lên men hương tự nhiên Betagen chai 400ml", 1 },
                    { 27, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9229), null, null, null, "Phô mai Vinamilk hộp 120g (8 miếng)", 1 },
                    { 26, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9227), null, null, null, "Mực viên Bếp 5 sao gói 200g", 1 },
                    { 25, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9225), null, null, null, "Chả giò hải sản trái cây La Cusina gói 300g", 1 },
                    { 24, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9224), null, null, null, "Xúc xích phô mai Kichi Kichi Icook khay 340g", 1 },
                    { 23, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9222), null, null, null, "TChả lụa bì ớt xiêm xanh G Kitchen cây 500g", 1 },
                    { 22, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9220), null, null, null, "Bánh mì que không nhân Vbread túi 10 cái x 30g", 1 },
                    { 21, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9218), null, null, null, "Bánh mì tươi đông lạnh O'smiles 350g", 1 },
                    { 19, null, 3, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9214), null, null, null, "Kem que Topten Socola Wall's 55g", 1 },
                    { 75, null, 13, new DateTime(2022, 11, 28, 10, 49, 47, 467, DateTimeKind.Local).AddTicks(9516), null, null, null, "Khay đá nhỏ nhựa 10 viên Hofaco HPL04 (giao màu ngẫu nhiên)", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitOfMeasureId",
                table: "Product",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreStock_ProductId",
                table: "StoreStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_StoreId",
                table: "Transaction",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ToStoreId",
                table: "Transaction",
                column: "ToStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_ProductId",
                table: "TransactionDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhoTong");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "StoreStock");

            migrationBuilder.DropTable(
                name: "TransactionDetail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "UnitOfMeasure");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "TransactionType");
        }
    }
}
