USE [AkilliTicaret]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 13.07.2022 18:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProducts]    Script Date: 13.07.2022 18:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProducts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[Price] [decimal](19, 1) NULL,
 CONSTRAINT [PK_OrderProducts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 13.07.2022 18:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[Price] [decimal](19, 4) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 13.07.2022 18:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[ProductName] [nvarchar](50) NULL,
	[Price] [decimal](19, 4) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [ParentID], [CategoryName]) VALUES (1, NULL, N'elektronik')
INSERT [dbo].[Categories] ([ID], [ParentID], [CategoryName]) VALUES (2, 1, N'bilgisayar')
INSERT [dbo].[Categories] ([ID], [ParentID], [CategoryName]) VALUES (3, NULL, N'ayakkabı')
INSERT [dbo].[Categories] ([ID], [ParentID], [CategoryName]) VALUES (4, 1, N'telefon')
INSERT [dbo].[Categories] ([ID], [ParentID], [CategoryName]) VALUES (5, 1, N'klima')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[OrderProducts] ON 

INSERT [dbo].[OrderProducts] ([ID], [OrderID], [ProductID], [Price]) VALUES (1, 1, 3, CAST(80.0 AS Decimal(19, 1)))
INSERT [dbo].[OrderProducts] ([ID], [OrderID], [ProductID], [Price]) VALUES (2, 2, 2, CAST(160.0 AS Decimal(19, 1)))
INSERT [dbo].[OrderProducts] ([ID], [OrderID], [ProductID], [Price]) VALUES (3, 3, 4, CAST(950.0 AS Decimal(19, 1)))
SET IDENTITY_INSERT [dbo].[OrderProducts] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [CustomerID], [Price]) VALUES (1, 1, CAST(80.0000 AS Decimal(19, 4)))
INSERT [dbo].[Orders] ([ID], [CustomerID], [Price]) VALUES (2, 1, CAST(160.0000 AS Decimal(19, 4)))
INSERT [dbo].[Orders] ([ID], [CustomerID], [Price]) VALUES (3, 1, CAST(950.0000 AS Decimal(19, 4)))
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [CategoryID], [ProductName], [Price]) VALUES (1, 4, N'Iphone 6', CAST(150.0000 AS Decimal(19, 4)))
INSERT [dbo].[Products] ([ID], [CategoryID], [ProductName], [Price]) VALUES (2, 4, N'Iphone 8', CAST(300.0000 AS Decimal(19, 4)))
INSERT [dbo].[Products] ([ID], [CategoryID], [ProductName], [Price]) VALUES (3, 2, N'Notebook', CAST(500.0000 AS Decimal(19, 4)))
INSERT [dbo].[Products] ([ID], [CategoryID], [ProductName], [Price]) VALUES (4, 5, N'klima', CAST(1000.0000 AS Decimal(19, 4)))
SET IDENTITY_INSERT [dbo].[Products] OFF
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [dbo].[OrderProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrderProducts_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[OrderProducts] CHECK CONSTRAINT [FK_OrderProducts_Orders]
GO
ALTER TABLE [dbo].[OrderProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrderProducts_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[OrderProducts] CHECK CONSTRAINT [FK_OrderProducts_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
