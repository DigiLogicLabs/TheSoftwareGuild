CREATE DATABASE HotelReservation3
/****** Object:  Table [dbo].[AddOn]    Script Date: 6/30/2017 1:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddOn](
	[AddOnID] [int] IDENTITY(1,1) NOT NULL,
	[AddOnType] [varchar](30) NOT NULL,
	[Rate] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AddOnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Amenity]    Script Date: 6/30/2017 1:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenity](
	[AmenityID] [int] IDENTITY(1,1) NOT NULL,
	[Amenity] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AmenityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BedType]    Script Date: 6/30/2017 1:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BedType](
	[BedID] [int] IDENTITY(1,1) NOT NULL,
	[MaxOccupant] [int] NOT NULL,
	[TypeOfBed] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 6/30/2017 1:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[PromoCodeID] [int] NOT NULL,
	[Tax] [float] NOT NULL,
	[Total] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillAddOn]    Script Date: 6/30/2017 1:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillAddOn](
	[BillID] [int] NOT NULL,
	[AddOnID] [int] NOT NULL,
 CONSTRAINT [PK_BillAddOn] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC,
	[AddOnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/30/2017 1:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](30) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Email] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Guest]    Script Date: 6/30/2017 1:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[GuestID] [int] IDENTITY(1,1) NOT NULL,
	[GuestAge] [int] NOT NULL,
	[GuestName] [varchar](30) NOT NULL,
	[ReservationID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GuestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PromoCode]    Script Date: 6/30/2017 1:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PromoCode](
	[PromoCodeID] [int] IDENTITY(1,1) NOT NULL,
	[DateRange] [datetime] NOT NULL,
	[PercentageDiscount] [decimal](18, 0) NOT NULL,
	[FlatRateDiscount] [int] NOT NULL,
	[PromoCodeType] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PromoCodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 6/30/2017 1:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[Datein] [datetime] NOT NULL,
	[Dateout] [datetime] NOT NULL,
	[ReasonForVisit] [varchar](30) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[BillID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReservationRoom]    Script Date: 6/30/2017 1:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationRoom](
	[ReservationID] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
 CONSTRAINT [PK_ReservationRoom] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC,
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 6/30/2017 1:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [int] NOT NULL,
	[FloorNumber] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomAmenity]    Script Date: 6/30/2017 1:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomAmenity](
	[RoomID] [int] NOT NULL,
	[AmenityID] [int] NOT NULL,
 CONSTRAINT [PK_RoomAmenity] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC,
	[AmenityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomBedType]    Script Date: 6/30/2017 1:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomBedType](
	[RoomID] [int] NOT NULL,
	[BedID] [int] NOT NULL,
 CONSTRAINT [PK_RoomBedType] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC,
	[BedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([PromoCodeID])
REFERENCES [dbo].[PromoCode] ([PromoCodeID])
GO
ALTER TABLE [dbo].[BillAddOn]  WITH CHECK ADD  CONSTRAINT [FK_AddOn_BillAddOn] FOREIGN KEY([AddOnID])
REFERENCES [dbo].[AddOn] ([AddOnID])
GO
ALTER TABLE [dbo].[BillAddOn] CHECK CONSTRAINT [FK_AddOn_BillAddOn]
GO
ALTER TABLE [dbo].[BillAddOn]  WITH CHECK ADD  CONSTRAINT [FK_Bill_BillAddOn] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([BillID])
GO
ALTER TABLE [dbo].[BillAddOn] CHECK CONSTRAINT [FK_Bill_BillAddOn]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_ReservationID] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_ReservationID]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Bill] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([BillID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Bill]
GO
ALTER TABLE [dbo].[ReservationRoom]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_ReservationRoom] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
GO
ALTER TABLE [dbo].[ReservationRoom] CHECK CONSTRAINT [FK_Reservation_ReservationRoom]
GO
ALTER TABLE [dbo].[ReservationRoom]  WITH CHECK ADD  CONSTRAINT [FK_Room_ReservationRoom] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[ReservationRoom] CHECK CONSTRAINT [FK_Room_ReservationRoom]
GO
ALTER TABLE [dbo].[RoomAmenity]  WITH CHECK ADD  CONSTRAINT [FK_Amenity_RoomAmenity] FOREIGN KEY([AmenityID])
REFERENCES [dbo].[Amenity] ([AmenityID])
GO
ALTER TABLE [dbo].[RoomAmenity] CHECK CONSTRAINT [FK_Amenity_RoomAmenity]
GO
ALTER TABLE [dbo].[RoomAmenity]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomAmenity] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[RoomAmenity] CHECK CONSTRAINT [FK_Room_RoomAmenity]
GO
ALTER TABLE [dbo].[RoomBedType]  WITH CHECK ADD  CONSTRAINT [FK_BedType_RoomBedType] FOREIGN KEY([BedID])
REFERENCES [dbo].[BedType] ([BedID])
GO
ALTER TABLE [dbo].[RoomBedType] CHECK CONSTRAINT [FK_BedType_RoomBedType]
GO
ALTER TABLE [dbo].[RoomBedType]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomBedType] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[RoomBedType] CHECK CONSTRAINT [FK_Room_RoomBedType]
GO
