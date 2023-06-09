USE [TutorialDB]
GO
/****** Object:  Table [dbo].[MonthlyRevenue]    Script Date: 19. 4. 2023 15:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonthlyRevenue](
	[RevenueId] [int] IDENTITY(1,1) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[MonthYear] [date] NOT NULL,
	[Revenue] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RevenueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MonthlyRevenue] ON 

INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (1, N'USA', CAST(N'2022-01-01' AS Date), CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (2, N'USA', CAST(N'2022-02-01' AS Date), CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (3, N'Canada', CAST(N'2022-01-01' AS Date), CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (4, N'Canada', CAST(N'2022-02-01' AS Date), CAST(75000.00 AS Decimal(18, 2)))
INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (5, N'Slovakia', CAST(N'2022-01-01' AS Date), CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (6, N'Slovakia', CAST(N'2022-02-01' AS Date), CAST(150000.00 AS Decimal(18, 2)))
INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (8, N'Slovakia', CAST(N'2022-04-01' AS Date), CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (9, N'Slovakia', CAST(N'2022-03-01' AS Date), CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (10, N'Brasil', CAST(N'2022-04-01' AS Date), CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (11, N'Brasil', CAST(N'2022-05-01' AS Date), CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[MonthlyRevenue] ([RevenueId], [Country], [MonthYear], [Revenue]) VALUES (12, N'Brasil', CAST(N'2022-06-01' AS Date), CAST(100000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[MonthlyRevenue] OFF
GO
