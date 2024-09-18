
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__EFMigrationsHistory]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
  [MigrationId] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] SET (LOCK_ESCALATION = TABLE)
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240417110905_initial', N'7.0.0')
GO

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ChiTietDonHang]') AND type IN ('U'))
	DROP TABLE [dbo].[ChiTietDonHang]
GO

CREATE TABLE [dbo].[ChiTietDonHang] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [IDSanPham] int  NULL,
  [Gia] int  NULL,
  [IDDonHang] int  NULL,
  [SoLuong] int  NULL
)
GO

ALTER TABLE [dbo].[ChiTietDonHang] SET (LOCK_ESCALATION = TABLE)
GO

SET IDENTITY_INSERT [dbo].[ChiTietDonHang] ON
GO

INSERT INTO [dbo].[ChiTietDonHang] ([ID], [IDSanPham], [Gia], [IDDonHang], [SoLuong]) VALUES (N'73', N'21', N'50000', N'31', N'2')
GO

INSERT INTO [dbo].[ChiTietDonHang] ([ID], [IDSanPham], [Gia], [IDDonHang], [SoLuong]) VALUES (N'74', N'21', N'11499000', N'33', N'1')
GO

INSERT INTO [dbo].[ChiTietDonHang] ([ID], [IDSanPham], [Gia], [IDDonHang], [SoLuong]) VALUES (N'75', N'24', N'50', N'34', N'2')
GO

INSERT INTO [dbo].[ChiTietDonHang] ([ID], [IDSanPham], [Gia], [IDDonHang], [SoLuong]) VALUES (N'76', N'21', N'11499000', N'34', N'1')
GO

INSERT INTO [dbo].[ChiTietDonHang] ([ID], [IDSanPham], [Gia], [IDDonHang], [SoLuong]) VALUES (N'77', N'24', N'50', N'35', N'2')
GO

INSERT INTO [dbo].[ChiTietDonHang] ([ID], [IDSanPham], [Gia], [IDDonHang], [SoLuong]) VALUES (N'78', N'21', N'11499000', N'35', N'1')
GO

INSERT INTO [dbo].[ChiTietDonHang] ([ID], [IDSanPham], [Gia], [IDDonHang], [SoLuong]) VALUES (N'79', N'24', N'50', N'36', N'2')
GO

INSERT INTO [dbo].[ChiTietDonHang] ([ID], [IDSanPham], [Gia], [IDDonHang], [SoLuong]) VALUES (N'80', N'29', N'668000', N'37', N'2')
GO

SET IDENTITY_INSERT [dbo].[ChiTietDonHang] OFF
GO

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[DonHang]') AND type IN ('U'))
	DROP TABLE [dbo].[DonHang]
GO

CREATE TABLE [dbo].[DonHang] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [Ten] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [NgayDat] date  NULL,
  [DiaChi] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[DonHang] SET (LOCK_ESCALATION = TABLE)
GO

SET IDENTITY_INSERT [dbo].[DonHang] ON
GO

INSERT INTO [dbo].[DonHang] ([ID], [Ten], [NgayDat], [DiaChi]) VALUES (N'31', N'Test', N'2024-04-16', N'123')
GO

INSERT INTO [dbo].[DonHang] ([ID], [Ten], [NgayDat], [DiaChi]) VALUES (N'33', N'khách 123', N'2024-04-20', N'Việt Nam 123')
GO

INSERT INTO [dbo].[DonHang] ([ID], [Ten], [NgayDat], [DiaChi]) VALUES (N'34', N'khách 123', N'2024-04-20', N'Việt Nam 123')
GO

INSERT INTO [dbo].[DonHang] ([ID], [Ten], [NgayDat], [DiaChi]) VALUES (N'35', N'khách 123', N'2024-04-20', N'Việt Nam 123')
GO

INSERT INTO [dbo].[DonHang] ([ID], [Ten], [NgayDat], [DiaChi]) VALUES (N'36', N'khách 123', N'2024-04-20', N'Việt Nam')
GO

INSERT INTO [dbo].[DonHang] ([ID], [Ten], [NgayDat], [DiaChi]) VALUES (N'37', N'admin', N'2024-04-20', N'Việt Nam - Số nhà 34')
GO

SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Loai]') AND type IN ('U'))
	DROP TABLE [dbo].[Loai]
GO

CREATE TABLE [dbo].[Loai] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [Ten] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Loai] SET (LOCK_ESCALATION = TABLE)
GO

SET IDENTITY_INSERT [dbo].[Loai] ON
GO

INSERT INTO [dbo].[Loai] ([ID], [Ten]) VALUES (N'1', N'Giày đá banh NIKE')
GO

INSERT INTO [dbo].[Loai] ([ID], [Ten]) VALUES (N'3', N'Giày đá banh Adidas')
GO

INSERT INTO [dbo].[Loai] ([ID], [Ten]) VALUES (N'4', N'Giày đá banh Kamito')
GO

INSERT INTO [dbo].[Loai] ([ID], [Ten]) VALUES (N'5', N'Giày đá banh Mizuno')
GO

SET IDENTITY_INSERT [dbo].[Loai] OFF
GO

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[NguoiDung]') AND type IN ('U'))
	DROP TABLE [dbo].[NguoiDung]
GO

CREATE TABLE [dbo].[NguoiDung] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [TaiKhoan] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [MatKhau] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Ten] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Quyen] int  NULL,
  [DiaChi] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[NguoiDung] SET (LOCK_ESCALATION = TABLE)
GO

SET IDENTITY_INSERT [dbo].[NguoiDung] ON
GO

INSERT INTO [dbo].[NguoiDung] ([ID], [TaiKhoan], [MatKhau], [Ten], [Quyen], [DiaChi]) VALUES (N'6', N'admin', N'123456', N'admin', N'1', N'Việt Nam')
GO

INSERT INTO [dbo].[NguoiDung] ([ID], [TaiKhoan], [MatKhau], [Ten], [Quyen], [DiaChi]) VALUES (N'7', N'khachhang', N'123456', N'khách', N'2', N'Việt Nam')
GO

SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SanPham]') AND type IN ('U'))
	DROP TABLE [dbo].[SanPham]
GO

CREATE TABLE [dbo].[SanPham] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [Ten] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Anh] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Gia] int  NULL,
  [SoLuong] int  NULL,
  [MoTa] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [MauSac] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ThongSo] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [IDLoai] int  NULL
)
GO

ALTER TABLE [dbo].[SanPham] SET (LOCK_ESCALATION = TABLE)
GO

SET IDENTITY_INSERT [dbo].[SanPham] ON
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'21', N'Nike DBreak-Type-CJ1156', N'331879349_906308600491579_8927915326992198538_n(1).jpg', N'68000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'1')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'24', N'Adidas Glaxy6', N'3623786537786666640568734354580345816071754n.jpg', N'168000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'1')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'25', N'Nike Killshosst2', N'33659071313093724396409357123564677518865722n.jpg', N'268000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đỏ', N'28,29,30,31,32', N'1')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'26', N'Nike SB Alleyoop', N'3021249458093772538095718416589690714064179n.jpg', N'368000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'1')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'27', N'Nike Air Force 1 Low White', N'34131502410270367549335838621237450207328204n.jpg', N'468000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'1')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'28', N'Nike Courrt', N'3004418976337081916020202244423564837021422n.jpg', N'568000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'1')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'29', N'Mizuno MRL Sala Club', N'3623786537786666640568734354580345816071754n.jpg', N'668000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Trắng', N'28,29,30,31,32', N'5')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'30', N'Mizuno MRL Club TF Xanh', N'33659071313093724396409357123564677518865722n.jpg', N'22000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'5')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'31', N'Kamito Velocidad', N'3021249458093772538095718416589690714064179n.jpg', N'45000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'1')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'32', N'Nike Street Gato Đỏ', N'34131502410270367549335838621237450207328204n.jpg', N'2000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'1')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'33', N'Kamito TA11 IC Woncup', N'3074060706457141769051521889519930543921985n.jpg', N'26000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'1')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'34', N'Adidas QH 19', N'3144127244488150371882455860206247225298398n.jpg', N'46000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Xanh', N'28,29,30,31,32', N'3')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'35', N'Adidas X Tango 18.3 IN-', N'3623786537786666640568734354580345816071754n.jpg', N'76000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'3')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'36', N'Nike JR Vapor 13 Academy TF', N'3004418976337081916020202244423564837021422n.jpg', N'89777', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'4')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'37', N'Kamito TA11- AS-F21001', N'30205794011249847117254668488885375737646791n.jpg', N'776000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'4')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'38', N'Kamito TA11-AS - F21002-', N'3332999815435979645312575398645158414363505n.jpg', N'8996000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'4')
GO

INSERT INTO [dbo].[SanPham] ([ID], [Ten], [Anh], [Gia], [SoLuong], [MoTa], [MauSac], [ThongSo], [IDLoai]) VALUES (N'39', N'Kamito TA11-AS - F21003-', N'3144127244488150371882455860206247225298398n.jpg', N'666000', N'100', N'Để vinh danh cũng như ghi nhận những đóng góp của cầu thủ Nguyễn Tuấn Anh, KAMITO đã cho ra mắt “TA11” – mẫu giày bóng đá được đặt theo tên và số áo của Tuấn Anh với rất nhiều điểm đặc biệt và thú vị: ', N'Đen', N'28,29,30,31,32', N'4')
GO

SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TinTuc]') AND type IN ('U'))
	DROP TABLE [dbo].[TinTuc]
GO

CREATE TABLE [dbo].[TinTuc] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [Ten] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [NoiDung] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Anh] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [NgayDang] date  NULL
)
GO

ALTER TABLE [dbo].[TinTuc] SET (LOCK_ESCALATION = TABLE)
GO

SET IDENTITY_INSERT [dbo].[TinTuc] ON
GO

INSERT INTO [dbo].[TinTuc] ([ID], [Ten], [NoiDung], [Anh], [NgayDang]) VALUES (N'4', N'Tiêu đề', N'Nội dung', N'436315376_818577290304079_4193879076837918196_n.jpg', NULL)
GO

SET IDENTITY_INSERT [dbo].[TinTuc] OFF
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

DBCC CHECKIDENT ('[dbo].[ChiTietDonHang]', RESEED, 80)
GO

ALTER TABLE [dbo].[ChiTietDonHang] ADD CONSTRAINT [PK__ChiTietD__3214EC2756639339] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

DBCC CHECKIDENT ('[dbo].[DonHang]', RESEED, 37)
GO

ALTER TABLE [dbo].[DonHang] ADD CONSTRAINT [PK__DonHang__3214EC2707933225] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

DBCC CHECKIDENT ('[dbo].[Loai]', RESEED, 5)
GO

ALTER TABLE [dbo].[Loai] ADD CONSTRAINT [PK__Loai__3214EC2711E64392] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

DBCC CHECKIDENT ('[dbo].[NguoiDung]', RESEED, 11)
GO

ALTER TABLE [dbo].[NguoiDung] ADD CONSTRAINT [PK__NguoiDun__3214EC27A9EA874A] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

DBCC CHECKIDENT ('[dbo].[SanPham]', RESEED, 39)
GO

ALTER TABLE [dbo].[SanPham] ADD CONSTRAINT [PK__SanPham__3214EC27B76A92E1] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

DBCC CHECKIDENT ('[dbo].[TinTuc]', RESEED, 6)
GO

ALTER TABLE [dbo].[TinTuc] ADD CONSTRAINT [PK__KhuyenMa__3214EC27C1FBAC88] PRIMARY KEY CLUSTERED ([ID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

ALTER TABLE [dbo].[ChiTietDonHang] ADD CONSTRAINT [IDSanPham_ChiTietDonHang] FOREIGN KEY ([IDSanPham]) REFERENCES [dbo].[SanPham] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[ChiTietDonHang] ADD CONSTRAINT [IDDonHang_DonHang] FOREIGN KEY ([IDDonHang]) REFERENCES [dbo].[DonHang] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[SanPham] ADD CONSTRAINT [IDLoai_SanPham] FOREIGN KEY ([IDLoai]) REFERENCES [dbo].[Loai] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

