USE master;
GO

if exists (select * from sysdatabases where name='HotelReservation')
begin
 DECLARE @kill varchar(8000) = ''; 
 SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';' 
 FROM sys.dm_exec_sessions
 WHERE database_id = db_id('HotelReservation')
 EXEC(@kill)
 
 DROP DATABASE HotelReservation
end
GO

CREATE DATABASE HotelReservation
GO
USE HotelReservation

CREATE TABLE Customer( --1
CustomerID INT IDENTITY (1,1) PRIMARY KEY,
[Name] nvarchar(30)  NOT NULL,
[Address] nvarchar(30) NOT NULL,
Phone varchar(15) NOT NULL,
Email nvarchar(30)

)
GO

CREATE TABLE Amenity(--1
AmenityID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
Amenity VARCHAR(30) NOT NULL 
)
GO



CREATE TABLE Room(--1
RoomID INT IDENTITY (1,1) PRIMARY KEY,
RoomNumber INT NOT NULL,
FloorNumber INT NOT NULL
)
GO

CREATE TABLE PromoCode(--1
PromoCodeID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
DateRange DATETIME NOT NULL,
PercentageDiscount DECIMAL NOT NULL,
FlatRateDiscount INT NOT NULL,
PromoCodeType VARCHAR(30) NOT NULL
)
GO

CREATE TABLE AddOn(--1
AddOnID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
AddOnType VARCHAR(30) NOT NULL,
Rate INT NOT NULL
)
GO

CREATE TABLE BedType(--1
BedID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
MaxOccupant INT NOT NULL,
TypeOfBed VARCHAR(30) NOT NULL 
)
GO

CREATE TABLE RoomBedType( --2
RoomID INT NOT NULL,
BedID INT NOT NULL,
	CONSTRAINT PK_RoomBedType
	PRIMARY KEY (RoomID, BedID),

CONSTRAINT FK_Room_RoomBedType
FOREIGN KEY (RoomID)
REFERENCES Room (RoomID),

CONSTRAINT FK_BedType_RoomBedType
FOREIGN KEY (BedID)
REFERENCES BedType (BedID),
)
GO

CREATE TABLE Bill( --2
BillID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
PromoCodeID INT FOREIGN KEY REFERENCES PromoCode (PromoCodeID) NOT NULL,
Tax FLOAT NOT NULL,
Total INT NOT NULL
)
GO


CREATE TABLE RoomAmenity(--2
RoomID INT NOT NULL,
AmenityID INT NOT NULL,
	CONSTRAINT PK_RoomAmenity
	PRIMARY KEY (RoomID, AmenityID),

CONSTRAINT FK_Room_RoomAmenity
FOREIGN KEY(RoomID)
REFERENCES Room (RoomID),

CONSTRAINT FK_Amenity_RoomAmenity
FOREIGN KEY (AmenityID)
REFERENCES Amenity (AmenityID),

)
GO


CREATE TABLE Reservation( --3
ReservationID INT IDENTITY (1,1) PRIMARY KEY,
Datein DATETIME NOT NULL,
Dateout DATETIME NOT NULL,
ReasonForVisit varchar(30) NOT NULL,
CustomerID INT FOREIGN KEY REFERENCES Customer(CustomerID) NOT NULL,
BillID INT FOREIGN KEY REFERENCES Bill (BillID)
)
GO


CREATE TABLE BillAddOn( --3
BillID INT NOT NULL,
AddOnID INT NOT NULL,
	CONSTRAINT PK_BillAddOn
	PRIMARY KEY (BillID, AddOnID),

CONSTRAINT FK_Bill_BillAddOn
FOREIGN KEY (BillID)
REFERENCES Bill (BillID),

CONSTRAINT FK_AddOn_BillAddOn
FOREIGN KEY (AddOnID)
REFERENCES AddOn (AddOnID),
)
GO

CREATE TABLE ReservationRoom(--4
ReservationID INT NOT NULL,
RoomID INT NOT NULL,
CONSTRAINT PK_ReservationRoom
PRIMARY KEY (ReservationID, RoomID),

CONSTRAINT FK_Room_ReservationRoom
FOREIGN KEY (RoomID)
REFERENCES Room (RoomID),

CONSTRAINT FK_Reservation_ReservationRoom
FOREIGN KEY (ReservationID)
REFERENCES Reservation(ReservationID),
)
GO



CREATE TABLE Guest(--4
GuestID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
CustomerID INT NOT NULL,
GuestAge INT NOT NULL,
GuestName VARCHAR(30) NOT NULL,
ReservationID INT NOT NULL
)
GO

ALTER TABLE Guest
ADD CONSTRAINT FK_CustomerID
FOREIGN KEY (CustomerID) REFERENCES Customer (CustomerID);


ALTER TABLE Guest
ADD CONSTRAINT FK_ReservationID
FOREIGN KEY (ReservationID) REFERENCES Reservation (ReservationID);