USE [SFProcuct-Anh-Boi]
GO
/****** Object:  Table [dbo].[tblAgent]    Script Date: 12/12/2022 11:09:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAgent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Agent] [varchar](50) NOT NULL,
	[Contact] [varchar](50) NOT NULL,
	[Address] [text] NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Mail] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblSupplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBrand]    Script Date: 12/12/2022 11:09:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBrand](
	[BID] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblBrand] PRIMARY KEY CLUSTERED 
(
	[BID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 12/12/2022 11:09:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[CID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGoodReceived]    Script Date: 12/12/2022 11:09:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGoodReceived](
	[GRID] [int] IDENTITY(1,1) NOT NULL,
	[GRdate] [date] NOT NULL,
	[Pcode] [int] NOT NULL,
	[AID] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_tblGoodReceived] PRIMARY KEY CLUSTERED 
(
	[GRID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 12/12/2022 11:09:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[Pcode] [varchar](50) NOT NULL,
	[Pname] [varchar](max) NOT NULL,
	[BID] [int] NOT NULL,
	[CID] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Qty] [int] NULL,
	[Reorder] [int] NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[Pcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 12/12/2022 11:09:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Role] [varchar](50) NOT NULL,
	[Fullname] [varchar](50) NOT NULL,
	[Isactive] [varchar](50) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblAgent] ON 

INSERT [dbo].[tblAgent] ([ID], [Agent], [Contact], [Address], [Phone], [Mail]) VALUES (3, N'QuyenDao', N'QuyenDao', N'Anh', N'0912312412', N'Quyendao@124')
INSERT [dbo].[tblAgent] ([ID], [Agent], [Contact], [Address], [Phone], [Mail]) VALUES (6, N'Gia Boi', N'Gia Boi', N'Gia Boi', N'091243124', N'GiaBoi@gmail.com')
SET IDENTITY_INSERT [dbo].[tblAgent] OFF
GO
SET IDENTITY_INSERT [dbo].[tblBrand] ON 

INSERT [dbo].[tblBrand] ([BID], [BrandName]) VALUES (1002, N'Mega We care')
INSERT [dbo].[tblBrand] ([BID], [BrandName]) VALUES (1003, N'Dr.Frei')
INSERT [dbo].[tblBrand] ([BID], [BrandName]) VALUES (1004, N'Dan Khang (VietNam)')
INSERT [dbo].[tblBrand] ([BID], [BrandName]) VALUES (1005, N'Cana Young')
INSERT [dbo].[tblBrand] ([BID], [BrandName]) VALUES (1006, N'Swiss Energy')
INSERT [dbo].[tblBrand] ([BID], [BrandName]) VALUES (1007, N'Dr. Frei Multivitamin Biotin')
SET IDENTITY_INSERT [dbo].[tblBrand] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCategory] ON 

INSERT [dbo].[tblCategory] ([CID], [CategoryName]) VALUES (1, N'Oral Pills')
INSERT [dbo].[tblCategory] ([CID], [CategoryName]) VALUES (2, N'Siro')
INSERT [dbo].[tblCategory] ([CID], [CategoryName]) VALUES (4, N'Cordyceps')
SET IDENTITY_INSERT [dbo].[tblCategory] OFF
GO
INSERT [dbo].[tblProduct] ([Pcode], [Pname], [BID], [CID], [Price], [Qty], [Reorder]) VALUES (N'01', N'Estro Her', 1002, 1, CAST(100000.00 AS Decimal(18, 2)), 0, 0)
INSERT [dbo].[tblProduct] ([Pcode], [Pname], [BID], [CID], [Price], [Qty], [Reorder]) VALUES (N'02', N'Oreful', 1002, 1, CAST(110000.00 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[tblProduct] ([Pcode], [Pname], [BID], [CID], [Price], [Qty], [Reorder]) VALUES (N'03', N'Siro Cana Young', 1005, 2, CAST(90000.00 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[tblProduct] ([Pcode], [Pname], [BID], [CID], [Price], [Qty], [Reorder]) VALUES (N'04', N'Welhair For Women', 1002, 1, CAST(150000.00 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[tblProduct] ([Pcode], [Pname], [BID], [CID], [Price], [Qty], [Reorder]) VALUES (N'05', N'Black Bull', 1004, 1, CAST(50000.00 AS Decimal(18, 2)), 0, 1)
INSERT [dbo].[tblProduct] ([Pcode], [Pname], [BID], [CID], [Price], [Qty], [Reorder]) VALUES (N'06', N'Swiss Energy Calcium', 1002, 1, CAST(1000000.00 AS Decimal(18, 2)), 0, 0)
INSERT [dbo].[tblProduct] ([Pcode], [Pname], [BID], [CID], [Price], [Qty], [Reorder]) VALUES (N'07', N'Baigout', 1006, 2, CAST(700000.00 AS Decimal(18, 2)), 0, 1)
GO
INSERT [dbo].[tblUser] ([Username], [Password], [Role], [Fullname], [Isactive]) VALUES (N'Quyenanh', N'123', N'Admin', N'Quyen Anh', N'True')
INSERT [dbo].[tblUser] ([Username], [Password], [Role], [Fullname], [Isactive]) VALUES (N'Quyenanh1', N'123', N'Accountants', N'Quyenanh2', N'True')
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_Qty]  DEFAULT ((0)) FOR [Qty]
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblProduct_BID] FOREIGN KEY([BID])
REFERENCES [dbo].[tblBrand] ([BID])
GO
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK_tblProduct_BID]
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblProduct_CID] FOREIGN KEY([CID])
REFERENCES [dbo].[tblCategory] ([CID])
GO
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK_tblProduct_CID]
GO
