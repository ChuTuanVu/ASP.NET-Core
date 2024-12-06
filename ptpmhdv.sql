USE [ptpmhdv]
GO
/****** Object:  Table [dbo].[bill]    Script Date: 06/12/2024 11:10:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bill](
	[billid] [varchar](32) NOT NULL,
	[userid] [varchar](32) NOT NULL,
	[billdate] [datetime] NULL,
	[updatedtime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[billid] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[billdetail]    Script Date: 06/12/2024 11:10:02 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[billdetail](
	[billdetailid] [varchar](32) NOT NULL,
	[billid] [varchar](32) NOT NULL,
	[itemid] [varchar](32) NULL,
	[quantity] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[subtotal] [decimal](18, 2) NULL,
	[staffid] [varchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[billdetailid] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[categoryid] [varchar](32) NOT NULL,
	[categoryname] [nvarchar](256) NOT NULL,
	[description] [nvarchar](256) NULL,
	[createdtime] [datetime] NULL,
	[updatedtime] [datetime] NULL,
 CONSTRAINT [PK__category__23CAF1D8C5A588D2] PRIMARY KEY CLUSTERED 
(
	[categoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[item]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[item](
	[itemid] [varchar](32) NOT NULL,
	[itemname] [nvarchar](256) NULL,
	[description] [nvarchar](256) NULL,
	[price] [decimal](18, 2) NULL,
	[stock] [int] NULL,
	[categoryid] [varchar](32) NULL,
	[createdtime] [datetime] NULL,
	[updatedtime] [datetime] NULL,
 CONSTRAINT [PK__item__56A128AABAA7EA4F] PRIMARY KEY CLUSTERED 
(
	[itemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[roleId] [int] NOT NULL,
	[roleName] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[staff]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staff](
	[staffid] [varchar](32) NOT NULL,
	[staffname] [nvarchar](128) NOT NULL,
	[email] [varchar](128) NOT NULL,
	[phone] [varchar](15) NULL,
	[createdtime] [datetime] NULL,
	[updatedtime] [datetime] NULL,
 CONSTRAINT [PK__staff__6465E07E0180F143] PRIMARY KEY CLUSTERED 
(
	[staffid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[userid] [varchar](32) NOT NULL,
	[username] [varchar](24) NOT NULL,
	[password] [varchar](256) NOT NULL,
	[roleid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userid] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userinfo]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userinfo](
	[userid] [varchar](32) NOT NULL,
	[name] [nvarchar](64) NULL,
	[email] [varchar](256) NULL,
	[phone] [varchar](15) NULL,
	[imgurl] [varchar](256) NULL,
	[address] [varchar](256) NULL,
	[dateofbirth] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'1', N'Kono Momoe', N'hmVTVpN6f4', CAST(253.10 AS Decimal(18, 2)), 881, N'7T3cgfO64G', CAST(N'2007-10-29T12:59:00.000' AS DateTime), CAST(N'2014-05-02T05:35:28.000' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'10', N'Yamaguchi Mitsuki', N'1Vxscp9Hbq', CAST(326.94 AS Decimal(18, 2)), 257, N'l27PVa4C4D', CAST(N'2024-01-03T02:50:06.000' AS DateTime), CAST(N'2003-08-10T01:09:26.000' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'123', N'12312', N'31231', CAST(3123.00 AS Decimal(18, 2)), 123, N'123', NULL, NULL)
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'17d575d6-7f2d-44a6-bb5a-3a023f5b', N'string', N'string', CAST(0.00 AS Decimal(18, 2)), 0, N'string', CAST(N'2024-12-06T15:56:58.510' AS DateTime), CAST(N'2024-12-06T15:56:58.510' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'2', N'Yamazaki Itsuki', N'9Wl3APtcpZ', CAST(419.01 AS Decimal(18, 2)), 681, N'xnppewWVuZ', CAST(N'2001-08-13T17:18:21.000' AS DateTime), CAST(N'2015-09-11T16:12:47.000' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'4', N'Tang Shihan', N'dfccBTp4ne', CAST(278.38 AS Decimal(18, 2)), 382, N'OABsgTOhFn', CAST(N'2002-10-22T06:20:42.000' AS DateTime), CAST(N'2011-07-04T06:44:23.000' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'43de4340-6edf-4f50-a684-20c6d5bf', N'string', N'string', CAST(0.00 AS Decimal(18, 2)), 0, N'string', CAST(N'2024-12-06T15:58:07.193' AS DateTime), CAST(N'2024-12-06T15:58:07.193' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'5', N'Noguchi Ayano', N'bNjmRkNPZK', CAST(268.74 AS Decimal(18, 2)), 27, N'hTRliEMUb2', CAST(N'2009-05-29T14:32:04.000' AS DateTime), CAST(N'2015-03-24T09:46:07.000' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'529789cc-46a4-4c03-af49-fea51dc1', N'string', N'string', CAST(0.00 AS Decimal(18, 2)), 0, N'string', CAST(N'2024-12-06T15:56:05.187' AS DateTime), CAST(N'2024-12-06T15:56:05.187' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'6', N'Maeda Ikki', N'2jsKqDLMQZ', CAST(168.04 AS Decimal(18, 2)), 760, N'K0n3ZspO4B', CAST(N'2007-09-04T09:06:07.000' AS DateTime), CAST(N'2024-03-18T18:00:02.000' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'7', N'Miyazaki Takuya', N'XuDRK8tUZ8', CAST(694.23 AS Decimal(18, 2)), 347, N'Wf2GOoP1pl', CAST(N'2006-03-19T01:20:24.000' AS DateTime), CAST(N'2019-12-15T23:45:57.000' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'8', N'Takagi Mai', N'iSeeHGBKHq', CAST(998.14 AS Decimal(18, 2)), 590, N'Rt5yPH8Et9', CAST(N'2016-04-14T07:11:12.000' AS DateTime), CAST(N'2023-12-04T01:40:43.000' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'9', N'Chen Xiaoming', N'sBQ7b0L05Q', CAST(860.86 AS Decimal(18, 2)), 611, N'gp9qPSsnhk', CAST(N'2015-02-06T18:42:50.000' AS DateTime), CAST(N'2022-11-17T02:55:12.000' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'a53d3590-0eea-48c0-b63e-e7148873', N'string', N'string', CAST(0.00 AS Decimal(18, 2)), 0, N'string', CAST(N'2024-12-06T15:58:07.193' AS DateTime), CAST(N'2024-12-06T15:58:07.193' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'f4ef1a69-738d-4bc7-8eac-f3dc5d76', N'string', N'string', CAST(0.00 AS Decimal(18, 2)), 0, N'string', CAST(N'2024-12-06T15:55:10.373' AS DateTime), CAST(N'2024-12-06T15:55:10.373' AS DateTime))
INSERT [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime]) VALUES (N'f611d8d1-c5bf-4964-a6e1-77c42704', N'string', N'string', CAST(0.00 AS Decimal(18, 2)), 0, N'string', CAST(N'2024-12-06T15:58:07.193' AS DateTime), CAST(N'2024-12-06T15:58:07.193' AS DateTime))
GO
INSERT [dbo].[role] ([roleId], [roleName]) VALUES (0, N'admin')
INSERT [dbo].[role] ([roleId], [roleName]) VALUES (1, N'user')
GO
INSERT [dbo].[staff] ([staffid], [staffname], [email], [phone], [createdtime], [updatedtime]) VALUES (N'', N'', N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__role__B1947861AB5C5B7D]    Script Date: 06/12/2024 11:10:03 CH ******/
ALTER TABLE [dbo].[role] ADD UNIQUE NONCLUSTERED 
(
	[roleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__userInfo__AB6E616473CB1FDB]    Script Date: 06/12/2024 11:10:03 CH ******/
ALTER TABLE [dbo].[userinfo] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[category_add]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[category_add] @categoryid VARCHAR (32),
@categoryname NVARCHAR (256),
@description NVARCHAR (256),
@createdtime DATETIME,
@updatedtime DATETIME AS BEGIN
  INSERT INTO [dbo].[category] ([categoryid], [categoryname], [description], [createdtime], [updatedtime])
  VALUES
(@categoryid, @categoryname, @description, @createdtime, @updatedtime);
END;
GO
/****** Object:  StoredProcedure [dbo].[category_delete]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[category_delete] @categoryid VARCHAR (32) AS BEGIN
  DELETE 
  FROM
    [dbo].[category] 
  WHERE
[categoryid] = @categoryid;
END;
GO
/****** Object:  StoredProcedure [dbo].[category_get_all]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[category_get_all] AS BEGIN
  SELECT
    * 
  FROM
[dbo].[category];
END;
GO
/****** Object:  StoredProcedure [dbo].[category_get_by_id]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[category_get_by_id] @categoryid VARCHAR (32) AS BEGIN
  SELECT
    * 
  FROM
    [dbo].[category] 
  WHERE
[categoryid] = @categoryid;
END;
GO
/****** Object:  StoredProcedure [dbo].[category_update]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[category_update] @categoryid VARCHAR (32),
@categoryname NVARCHAR (256),
@description NVARCHAR (256),
@updatedtime DATETIME AS BEGIN
  UPDATE [dbo].[category] 
  SET [categoryname] = @categoryname,
  [description] = @description,
  [updatedtime] = @updatedtime 
  WHERE
[categoryid] = @categoryid;
END;
GO
/****** Object:  StoredProcedure [dbo].[item_add]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[item_add] @itemid VARCHAR (32),
@itemname NVARCHAR (256),
@description NVARCHAR (256),
@price DECIMAL (18, 2),
@stock INT,
@categoryid VARCHAR (32),
@createdtime DATETIME,
@updatedtime DATETIME AS BEGIN
  INSERT INTO [dbo].[item] ([itemid], [itemname], [description], [price], [stock], [categoryid], [createdtime], [updatedtime])
  VALUES
    (@itemid,
      @itemname,
      @description,
      @price,
      @stock,
      @categoryid,
      @createdtime,
    @updatedtime);

END
GO
/****** Object:  StoredProcedure [dbo].[item_delete]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[item_delete]
@itemid VARCHAR (32) AS BEGIN
  DELETE 
  FROM
    [dbo].[item] 
  WHERE
    [itemid] = @itemid;
END
GO
/****** Object:  StoredProcedure [dbo].[item_get_all]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[item_get_all] AS BEGIN
  SELECT
    * 
  FROM
item 
END
GO
/****** Object:  StoredProcedure [dbo].[item_get_by_id]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[item_get_by_id]
@itemid VARCHAR (32) AS BEGIN
  SELECT
    * 
  FROM
    [dbo].[item] 
  WHERE
    [itemid] = @itemid;

END
GO
/****** Object:  StoredProcedure [dbo].[item_update]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[item_update]
@itemid VARCHAR (32),
@itemname NVARCHAR (256),
@description NVARCHAR (256),
@price DECIMAL (18, 2),
@stock INT,
@categoryid VARCHAR (32),
@updatedtime DATETIME AS BEGIN
  UPDATE [dbo].[item] 
  SET [itemname] = @itemname,
  [description] = @description,
  [price] = @price,
  [stock] = @stock,
  [categoryid] = @categoryid,
  [updatedtime] = @updatedtime 
  WHERE
    [itemid] = @itemid;

END
GO
/****** Object:  StoredProcedure [dbo].[staff_add]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[staff_add] @staffid VARCHAR (32),
@staffname NVARCHAR (128),
@email VARCHAR (128),
@phone VARCHAR (15),
@createdtime DATETIME,
@updatedtime DATETIME AS BEGIN
  INSERT INTO [dbo].[staff] ([staffid], [staffname], [email], [phone], [createdtime], [updatedtime])
  VALUES
    (@staffid, @staffname, @email, @phone, @createdtime, @updatedtime);
  
END;
GO
/****** Object:  StoredProcedure [dbo].[staff_delete]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[staff_delete] @staffid VARCHAR (32) AS BEGIN
  DELETE 
  FROM
    [dbo].[staff] 
  WHERE
[staffid] = @staffid;
END;
GO
/****** Object:  StoredProcedure [dbo].[staff_get_all]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[staff_get_all] AS BEGIN
  SELECT
    * 
  FROM
    [dbo].[staff];

END;
GO
/****** Object:  StoredProcedure [dbo].[staff_get_by_id]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[staff_get_by_id] @staffid VARCHAR (32) AS BEGIN
  SELECT
    * 
  FROM
    [dbo].[staff] 
  WHERE
[staffid] = @staffid;
END;
GO
/****** Object:  StoredProcedure [dbo].[staff_update]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[staff_update] @staffid VARCHAR (32),
@staffname NVARCHAR (128),
@email VARCHAR (128),
@phone VARCHAR (15),
@updatedtime DATETIME AS BEGIN
  UPDATE [dbo].[staff] 
  SET [staffname] = @staffname,
  [email] = @email,
  [phone] = @phone,
  [updatedtime] = @updatedtime 
  WHERE
    [staffid] = @staffid;

END;
GO
/****** Object:  StoredProcedure [dbo].[user_add]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_add] @userid VARCHAR (32),
@username VARCHAR (24),
@password VARCHAR (256),
@roleid INT,
@name NVARCHAR (64),
@email VARCHAR (256),
@phone VARCHAR (15),
@imgurl VARCHAR (256),
@address NVARCHAR (256), @dateofbirth DATE AS BEGIN
  INSERT INTO [user] ([userid], [username], [password], [roleid])
  VALUES
    (@userid, @username, @password, @roleid);
  INSERT INTO userinfo ([userid], name, email, phone, imgurl, address, dateofbirth)
  VALUES
(@userid,@name,@email,@phone,@imgurl,@address,@dateofbirth) 
END
GO
/****** Object:  StoredProcedure [dbo].[user_delete]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_delete]
@userid VARCHAR (32) AS BEGIN
  DELETE 
  FROM
    userinfo 
  WHERE
    userid = @userid DELETE 
  FROM
    [user] 
  WHERE
userid = @userid 
END
GO
/****** Object:  StoredProcedure [dbo].[user_get_all]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_get_all] AS BEGIN
  SELECT
    userid, username, roleid 
  FROM [user]
END
GO
/****** Object:  StoredProcedure [dbo].[user_get_by_username_password]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_get_by_username_password] (@username VARCHAR (24),
  @password VARCHAR (256)) AS BEGIN
  SELECT *
    FROM [user] 
  WHERE
username = @username and password = @password 
END
GO
/****** Object:  StoredProcedure [dbo].[user_get_info]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_get_info] @userid VARCHAR (32) AS BEGIN
  SELECT
    * 
  FROM
    userInfo 
  WHERE
[userid] = @userid 
END
GO
/****** Object:  StoredProcedure [dbo].[user_get_role]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_get_role] @id VARCHAR (30) AS BEGIN
  SELECT
    roleName 
  FROM
    role 
  WHERE
roleID = @id 
END
GO
/****** Object:  StoredProcedure [dbo].[user_update]    Script Date: 06/12/2024 11:10:03 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_update] @userid VARCHAR (32),
@password VARCHAR (256),
@name NVARCHAR (64),
@email VARCHAR (256),
@phone VARCHAR (15),
@imgurl VARCHAR (256),
@address NVARCHAR (256),
@dateofbirth DATE AS BEGIN
  UPDATE [user] 
  SET [password] = @password 
  WHERE
    [userId] = @userid;
  UPDATE [userInfo] 
  SET [name] = @name,
  [email] = @email,
  [phone] = @phone,
  [imgUrl] = @imgurl,
  [address] = @address,
  [dateOfBirth] = @dateofbirth 
  WHERE
[userId] = @userid;
END;
GO
