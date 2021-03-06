USE [ProjectDemo]
CREATE DATABASE [ProjectDemo]
ALTER DATABASE [ProjectDemo] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectDemo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectDemo] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectDemo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProjectDemo] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ProjectDemo]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 15/9/2020 8:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](150) NOT NULL,
	[email] [nvarchar](150) NOT NULL,
	[password] [nvarchar](150) NOT NULL,
	[address] [nvarchar](250) NOT NULL,
	[date_of_birth] [datetime] NOT NULL,
	[gender] [bit] NOT NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Advertisement]    Script Date: 15/9/2020 8:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisement](
	[advertisement_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
 CONSTRAINT [PK_Advertisement] PRIMARY KEY CLUSTERED 
(
	[advertisement_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FoodType]    Script Date: 15/9/2020 8:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodType](
	[type_id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FoodType] PRIMARY KEY CLUSTERED 
(
	[type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 15/9/2020 8:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quality] [int] NOT NULL,
	[order_date] [datetime] NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 15/9/2020 8:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[recipient_name] [nvarchar](150) NOT NULL,
	[recipient_address] [nvarchar](550) NOT NULL,
	[recipient_phone] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quality] [int] NOT NULL,
	[order_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 15/9/2020 8:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nvarchar](max) NOT NULL,
	[abstract] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[image] [nvarchar](50) NOT NULL,
	[price] [float] NOT NULL,
	[type_id] [int] NOT NULL,
	[store_id] [int] NOT NULL,
	[time_open] [nvarchar](50) NOT NULL,
	[time_close] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Table_1_1] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Store]    Script Date: 15/9/2020 8:31:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[store_id] [int] IDENTITY(1,1) NOT NULL,
	[store_name] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Store_1] PRIMARY KEY CLUSTERED 
(
	[store_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 
INSERT [dbo].[Account] ([account_id], [full_name], [email], [password], [address], [date_of_birth], [gender]) VALUES (1, N'thanh', N'wasnever.wasnever@gmail.com', N'123456', N'Ha nOi', CAST(N'2021-04-03 00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Advertisement] ON 

INSERT [dbo].[Advertisement] ([advertisement_id], [product_id]) VALUES (1, 4)
INSERT [dbo].[Advertisement] ([advertisement_id], [product_id]) VALUES (2, 6)
INSERT [dbo].[Advertisement] ([advertisement_id], [product_id]) VALUES (3, 8)
SET IDENTITY_INSERT [dbo].[Advertisement] OFF
SET IDENTITY_INSERT [dbo].[FoodType] ON 

INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (1, N'Food')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (2, N'Drinks')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (3, N'Vegetarian food')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (4, N'Cake')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (5, N'Dessert')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (6, N'Homemade')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (7, N'Pavement')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (8, N'Pizza / burger')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (9, N'Chicken dishes')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (10, N'Pot')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (11, N'Sushi')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (12, N'Noodle soup')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (13, N'Lunch box')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (14, N'Other')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (15, N'Beer')
INSERT [dbo].[FoodType] ([type_id], [type_name]) VALUES (16, N'Wine')
SET IDENTITY_INSERT [dbo].[FoodType] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 


SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (4, N'Hamberger', N'Bánh hamburger là một loại thức ăn bao gồm bánh mì kẹp có thịt xay hay thịt băm viên ở giữa. Miếng thịt có thể đã được nướng, chiên, hay hun khói và thường được ăn với một số gia vị bên trong cùng với 2 miếng bánh mì hình tròn.', N'Bánh hamburger là một loại thức ăn bao gồm bánh mì kẹp có thịt xay hay thịt băm viên ở giữa. Miếng thịt có thể đã được nướng, chiên, hay hun khói và thường được ăn với một số gia vị bên trong cùng với 2 miếng bánh mì hình tròn.', N'hamberger.jpg', 12, 1, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (6, N'Sausage', N'Xúc xích là một loại thực phẩm chế biến từ thịt bằng phương pháp dồi kết hợp với các loại nguyên liệu khác như muối, gia vị, phụ gia.... Theo Từ điển tiếng Việt thì xúc xích là món ăn làm bằng ruột lợn nhồi thịt, rồi hun khói và luộc nhỏ lửa và còn có sự kết hợp của muối, gia vị, phụ gia.', N'Xúc xích là một loại thực phẩm chế biến từ thịt bằng phương pháp dồi kết hợp với các loại nguyên liệu khác như muối, gia vị, phụ gia.... Theo Từ điển tiếng Việt thì xúc xích là món ăn làm bằng ruột lợn nhồi thịt, rồi hun khói và luộc nhỏ lửa và còn có sự kết hợp của muối, gia vị, phụ gia.', N'sausage.jpg', 13, 1, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (8, N'Milk', N'Sữa là một chất lỏng màu trắng đục được tạo ra bởi giống cái của động vật có vú. Khả năng tạo ra sữa là một trong những đặc điểm phân định động vật có vú. Sữa được tạo ra làm nguồn dinh dưỡng ban đầu cho các con sơ sinh trước khi chúng có thể tiêu hóa các loại thực phẩm khác.', N'Sữa là một chất lỏng màu trắng đục được tạo ra bởi giống cái của động vật có vú. Khả năng tạo ra sữa là một trong những đặc điểm phân định động vật có vú. Sữa được tạo ra làm nguồn dinh dưỡng ban đầu cho các con sơ sinh trước khi chúng có thể tiêu hóa các loại thực phẩm khác.', N'milk.jpg', 14, 2, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (13, N'Chan ga nuong', N'Món ăn dân dã', N'Món ăn dành cho  những tín đồ nhậu', N'changanuong.jpg', 15, 2, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (16, N'Chân vịt rút sương xào xả ớt', N'Tuyệt đỉnh nhậu Hải Dương', N'Ăn là mê', N'chanvitrutxuong.jpg', 16, 2, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (17, N'Sườn nướng', N'Đặc sản miền quê', N'Ăn phải mê', N'suonnuong.jpg', 17, 1, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (18, N'Hàu nướng mỡ hành', N'Đặc Sản Đồ Sơn', N'Béo ngậy thơm ngon', N'haunuong.jpg', 17, 1, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (20, N'Cá kho làng Vũ Đại', N'Đặc sản làng Vũ Đại', N'Tốn cơm cực kì', N'calangvudai.jpg', 17, 1, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (21, N'Chả nem', N'Món bạn Vương rất thích ăn', N'Sự lựa chọn hàng đầu', N'chanem.jpg', 16, 1, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (22, N'Thịt Kho Tàu', N'Thịt ngon mlem mlen', N'Cũng Tốn cơm cực kì', N'thitkhotau.jpg', 18, 2, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (23, N'Cơm tấm', N'Hương vị đông quê', N'ngon ngon ngon', N'comtam.jpg', 2, 2, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (24, N'Chè sầu', N'ngọt ngọt ngọt', N'Ăn 1 miếng mát 1 tiếng ', N'chesau.jpg', 2, 2, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (25, N'Bánh mì chảo', N'Bữa sáng thú vị', N'Ăn theo phong cách tây âu', N'banhmichao.jpg', 1, 2, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (26, N'Xôi Chim', N'Món khai vị ngon', N'Ngọt bùi béo ngậy', N'xoichim.jpg', 2, 2, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (28, N'Ốc Bươu sào', N'Món khai vị', N'Ngon thơm ', N'ocsao.jpg', 1, 2, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (29, N'Beer', N'Bia nói một cách tổng thể, là một loại đồ uống chứa cồn được sản xuất bằng quá trình lên men đường lơ lửng trong môi trường lỏng và nó không được chưng cất sau khi lên men', N'Bia nói một cách tổng thể, là một loại đồ uống chứa cồn được sản xuất bằng quá trình lên men đường lơ lửng trong môi trường lỏng và nó không được chưng cất sau khi lên men', N'beer.jpg', 155, 15, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (30, N'Beer Kirin', N'Bia nói một cách tổng thể, là một loại đồ uống chứa cồn được sản xuất bằng quá trình lên men đường lơ lửng trong môi trường lỏng và nó không được chưng cất sau khi lên men', N'Bia nói một cách tổng thể, là một loại đồ uống chứa cồn được sản xuất bằng quá trình lên men đường lơ lửng trong môi trường lỏng và nó không được chưng cất sau khi lên men', N'beerKirin.jpg', 122, 15, 1, N'0:00', N'23:00')
INSERT [dbo].[Product] ([product_id], [product_name], [abstract], [description], [image], [price], [type_id], [store_id], [time_open], [time_close]) VALUES (31, N'Sake', N'Rượu Sake Kubota Senju là loại rượu gạo truyền thống lâu đời của xứ sở hoa anh đào, có hương thơm ngạt ngào của gạo Sakamai cùng vị ngọt dịu nhẹ lô', N'Rượu Sake Kubota Senju là loại rượu gạo truyền thống lâu đời của xứ sở hoa anh đào, có hương thơm ngạt ngào của gạo Sakamai cùng vị ngọt dịu nhẹ lô', N'sake.jpg', 33, 16, 1, N'0:00', N'23:00')
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Store] ON 

INSERT [dbo].[Store] ([store_id], [store_name], [address]) VALUES (1, N'Group 7', N'FPT University - Ha Noi')
SET IDENTITY_INSERT [dbo].[Store] OFF
USE [master]
GO
ALTER DATABASE [ProjectDemo] SET  READ_WRITE 
GO
