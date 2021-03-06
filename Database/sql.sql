USE [elibraryDB]
GO
/****** Object:  Table [dbo].[admin_login_tbl]    Script Date: 12/31/2019 12:55:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin_login_tbl](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
	[full_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_admin_login_tbl] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[author_master_tbl]    Script Date: 12/31/2019 12:55:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[author_master_tbl](
	[author_id] [int] IDENTITY(2001,1) NOT NULL,
	[authorName] [nvarchar](50) NULL,
 CONSTRAINT [PK_author_master_tbl] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[book_master_tbl]    Script Date: 12/31/2019 12:55:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book_master_tbl](
	[book_id] [int] IDENTITY(1001,1) NOT NULL,
	[book_name] [nvarchar](max) NULL,
	[genre] [nvarchar](max) NULL,
	[authorId] [int] NOT NULL,
	[publisherId] [int] NOT NULL,
	[publish_date] [nvarchar](50) NULL,
	[language] [nvarchar](50) NULL,
	[edition] [nvarchar](50) NULL,
	[book_cost] [nchar](10) NULL,
	[no_of_pages] [nchar](10) NULL,
	[book_dscription] [nvarchar](max) NULL,
	[actual_stock] [nchar](10) NULL,
	[current_stock] [nchar](10) NULL,
	[book_img_link] [nvarchar](50) NULL,
 CONSTRAINT [PK_book_master_tbl] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IssuedBookTBL]    Script Date: 12/31/2019 12:55:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssuedBookTBL](
	[Id] [int] IDENTITY(101,1) NOT NULL,
	[MemberId] [int] NULL,
	[BookId] [int] NULL,
	[StartDate] [nchar](10) NULL,
	[ReturnDate] [nchar](10) NULL,
 CONSTRAINT [PK_IssuedBookTBL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[member_master_tbl]    Script Date: 12/31/2019 12:55:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[member_master_tbl](
	[member_id] [int] IDENTITY(100,1) NOT NULL,
	[full_name] [nvarchar](max) NULL,
	[dob] [nvarchar](50) NULL,
	[contact_no] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[state] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
	[pincode] [nvarchar](50) NULL,
	[full_address] [nvarchar](max) NULL,
	[password] [nvarchar](50) NULL,
	[account_status] [nvarchar](50) NULL,
 CONSTRAINT [PK_member_master_tbl] PRIMARY KEY CLUSTERED 
(
	[member_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[publisher_master_tbl]    Script Date: 12/31/2019 12:55:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[publisher_master_tbl](
	[publisher_id] [int] IDENTITY(201,1) NOT NULL,
	[publisher_name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_publisher_master_tbl] PRIMARY KEY CLUSTERED 
(
	[publisher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[BookIssuedView]    Script Date: 12/31/2019 12:55:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create View [dbo].[BookIssuedView]
as
select s.MemberId, m.full_name,s.BookId,b.book_name, s.StartDate, s.ReturnDate  From IssuedBookTBL as s Inner join
member_master_tbl as m on s.MemberId=m.member_id
inner join book_master_tbl as b on s.BookId=b.book_id
GO
/****** Object:  View [dbo].[View_Book]    Script Date: 12/31/2019 12:55:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Book] AS
select b.book_id, b.book_name, a.authorName,p.publisher_name,b.publish_date, b.genre,b.edition,b.book_dscription,b.book_cost,b.actual_stock,
b.current_stock, b.book_img_link,b.language,b.no_of_pages from book_master_tbl as b 
inner join author_master_tbl as a on a.author_id=b.authorId 
inner join publisher_master_tbl as p on p.publisher_id=b.publisherId 
GO
INSERT [dbo].[admin_login_tbl] ([username], [password], [full_name]) VALUES (N'shorifulba@gmail.com', N'12345', N'Md Shoriful Islam')
SET IDENTITY_INSERT [dbo].[author_master_tbl] ON 

INSERT [dbo].[author_master_tbl] ([author_id], [authorName]) VALUES (2002, N'Md Shoriful ')
INSERT [dbo].[author_master_tbl] ([author_id], [authorName]) VALUES (2004, N'Md Kamal Hossain')
INSERT [dbo].[author_master_tbl] ([author_id], [authorName]) VALUES (2005, N'Moniruzzaman')
INSERT [dbo].[author_master_tbl] ([author_id], [authorName]) VALUES (2006, N'Balagurusamy')
INSERT [dbo].[author_master_tbl] ([author_id], [authorName]) VALUES (2007, N'Saifur Rahman')
INSERT [dbo].[author_master_tbl] ([author_id], [authorName]) VALUES (2008, N'Santi Narayan')
INSERT [dbo].[author_master_tbl] ([author_id], [authorName]) VALUES (2009, N'Mahbub Alam')
SET IDENTITY_INSERT [dbo].[author_master_tbl] OFF
SET IDENTITY_INSERT [dbo].[book_master_tbl] ON 

INSERT [dbo].[book_master_tbl] ([book_id], [book_name], [genre], [authorId], [publisherId], [publish_date], [language], [edition], [book_cost], [no_of_pages], [book_dscription], [actual_stock], [current_stock], [book_img_link]) VALUES (1001, N'Baibel', N'Adventure', 2005, 201, N'2019-12-18', N'english', N'First', N'6000      ', N'800       ', N'this is holy book', N'4000      ', N'3998      ', N'~/BookInventory/feature2.jpg')
INSERT [dbo].[book_master_tbl] ([book_id], [book_name], [genre], [authorId], [publisherId], [publish_date], [language], [edition], [book_cost], [no_of_pages], [book_dscription], [actual_stock], [current_stock], [book_img_link]) VALUES (1002, N'Holy Quran', N'Self Help,Motivation', 2004, 201, N'2019-12-12', N'english', N'First', N'10000     ', N'2000      ', N'The Quran is a best and holy book in the world.', N'100000    ', N'99999     ', N'~/BookInventory/feature3.jpg')
INSERT [dbo].[book_master_tbl] ([book_id], [book_name], [genre], [authorId], [publisherId], [publish_date], [language], [edition], [book_cost], [no_of_pages], [book_dscription], [actual_stock], [current_stock], [book_img_link]) VALUES (1003, N'Software Engineering', N'Textbook,Science', 2002, 201, N'2019-12-25', N'english', N'First', N'500       ', N'300       ', N'the book for computer engineering', N'500       ', N'498       ', N'~/BookInventory/feature3.jpg')
INSERT [dbo].[book_master_tbl] ([book_id], [book_name], [genre], [authorId], [publisherId], [publish_date], [language], [edition], [book_cost], [no_of_pages], [book_dscription], [actual_stock], [current_stock], [book_img_link]) VALUES (1004, N'Numerical Methods', N'Textbook,Science', 2004, 201, N'2019-12-01', N'english', N'2nd ', N'210       ', N'320       ', N'Numerical analysis is the study of algorithms that use numerical approximation for the problems of mathematical analysis.', N'20        ', N'20        ', N'~/BookInventory/feature1.png')
SET IDENTITY_INSERT [dbo].[book_master_tbl] OFF
SET IDENTITY_INSERT [dbo].[IssuedBookTBL] ON 

INSERT [dbo].[IssuedBookTBL] ([Id], [MemberId], [BookId], [StartDate], [ReturnDate]) VALUES (101, 102, 1003, N'2019-12-29', N'2020-01-31')
INSERT [dbo].[IssuedBookTBL] ([Id], [MemberId], [BookId], [StartDate], [ReturnDate]) VALUES (105, 102, 1002, N'2019-12-17', N'2019-12-31')
INSERT [dbo].[IssuedBookTBL] ([Id], [MemberId], [BookId], [StartDate], [ReturnDate]) VALUES (106, 100, 1003, N'2019-12-29', N'2020-01-20')
INSERT [dbo].[IssuedBookTBL] ([Id], [MemberId], [BookId], [StartDate], [ReturnDate]) VALUES (107, 102, 1001, N'2019-12-30', N'2020-01-23')
INSERT [dbo].[IssuedBookTBL] ([Id], [MemberId], [BookId], [StartDate], [ReturnDate]) VALUES (108, 100, 1001, N'2019-12-29', N'2019-12-01')
SET IDENTITY_INSERT [dbo].[IssuedBookTBL] OFF
SET IDENTITY_INSERT [dbo].[member_master_tbl] ON 

INSERT [dbo].[member_master_tbl] ([member_id], [full_name], [dob], [contact_no], [email], [state], [city], [pincode], [full_address], [password], [account_status]) VALUES (100, N'Md Shoriful Islam', N'1995-04-04', N'01835971455', N'shorifulba@gmail.com', N'Magura', N'Magura', N'7600', N'Beroil, Magura', N'shorif123', N'Pending')
INSERT [dbo].[member_master_tbl] ([member_id], [full_name], [dob], [contact_no], [email], [state], [city], [pincode], [full_address], [password], [account_status]) VALUES (102, N'Md Abdul Mannan', N'1993-05-09', N'01765339911', N'mannan@gmail.com', N'Khulna', N'Jhenaidah', N'7300', N'Adassho para, Jhenaidah', N'mannan12', N'active')
INSERT [dbo].[member_master_tbl] ([member_id], [full_name], [dob], [contact_no], [email], [state], [city], [pincode], [full_address], [password], [account_status]) VALUES (104, N'', N'', N'', N'', N'Select', N'', N'', N'', N'', N'Pending')
SET IDENTITY_INSERT [dbo].[member_master_tbl] OFF
SET IDENTITY_INSERT [dbo].[publisher_master_tbl] ON 

INSERT [dbo].[publisher_master_tbl] ([publisher_id], [publisher_name]) VALUES (201, N'Al-Fatah Publication')
INSERT [dbo].[publisher_master_tbl] ([publisher_id], [publisher_name]) VALUES (202, N'Saifurs Publication')
INSERT [dbo].[publisher_master_tbl] ([publisher_id], [publisher_name]) VALUES (203, N'Panjeri Publication')
INSERT [dbo].[publisher_master_tbl] ([publisher_id], [publisher_name]) VALUES (204, N'Newton Publication')
INSERT [dbo].[publisher_master_tbl] ([publisher_id], [publisher_name]) VALUES (205, N'dignant Publication ')
SET IDENTITY_INSERT [dbo].[publisher_master_tbl] OFF
ALTER TABLE [dbo].[book_master_tbl]  WITH CHECK ADD  CONSTRAINT [FK_book_master_tbl_author_master_tbl] FOREIGN KEY([authorId])
REFERENCES [dbo].[author_master_tbl] ([author_id])
GO
ALTER TABLE [dbo].[book_master_tbl] CHECK CONSTRAINT [FK_book_master_tbl_author_master_tbl]
GO
ALTER TABLE [dbo].[book_master_tbl]  WITH CHECK ADD  CONSTRAINT [FK_book_master_tbl_publisher_master_tbl] FOREIGN KEY([publisherId])
REFERENCES [dbo].[publisher_master_tbl] ([publisher_id])
GO
ALTER TABLE [dbo].[book_master_tbl] CHECK CONSTRAINT [FK_book_master_tbl_publisher_master_tbl]
GO
ALTER TABLE [dbo].[IssuedBookTBL]  WITH CHECK ADD  CONSTRAINT [FK_IssuedBookTBL_book_master_tbl] FOREIGN KEY([BookId])
REFERENCES [dbo].[book_master_tbl] ([book_id])
GO
ALTER TABLE [dbo].[IssuedBookTBL] CHECK CONSTRAINT [FK_IssuedBookTBL_book_master_tbl]
GO
ALTER TABLE [dbo].[IssuedBookTBL]  WITH CHECK ADD  CONSTRAINT [FK_IssuedBookTBL_member_master_tbl] FOREIGN KEY([MemberId])
REFERENCES [dbo].[member_master_tbl] ([member_id])
GO
ALTER TABLE [dbo].[IssuedBookTBL] CHECK CONSTRAINT [FK_IssuedBookTBL_member_master_tbl]
GO
