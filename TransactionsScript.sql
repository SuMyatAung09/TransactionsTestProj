USE [TransactionTestDB]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 5/30/2022 7:21:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [nchar](36) NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[PaymentCurrencyCode] [nvarchar](50) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Transactions] ([Id], [Amount], [PaymentCurrencyCode], [TransactionDate], [Status]) VALUES (N'Inv00001                            ', CAST(200.00 AS Decimal(10, 2)), N'USD', CAST(N'2019-01-23T13:45:10.000' AS DateTime), N'Done')
INSERT [dbo].[Transactions] ([Id], [Amount], [PaymentCurrencyCode], [TransactionDate], [Status]) VALUES (N'Inv00002                            ', CAST(10000.00 AS Decimal(10, 2)), N'ERU', CAST(N'2019-01-24T16:09:15.000' AS DateTime), N'Rejected')
INSERT [dbo].[Transactions] ([Id], [Amount], [PaymentCurrencyCode], [TransactionDate], [Status]) VALUES (N'Invoice0000001                      ', CAST(100.00 AS Decimal(10, 2)), N'USD', CAST(N'2022-05-29T16:03:29.807' AS DateTime), N'Approved')
INSERT [dbo].[Transactions] ([Id], [Amount], [PaymentCurrencyCode], [TransactionDate], [Status]) VALUES (N'Invoice0000002                      ', CAST(200.00 AS Decimal(10, 2)), N'USD', CAST(N'2022-05-29T16:03:40.800' AS DateTime), N'Failed')
GO
