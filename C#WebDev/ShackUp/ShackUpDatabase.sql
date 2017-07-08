USE master 
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name= 'ShackUp')
DROP DATABASE ShackUp
GO

CREATE DATABASE ShackUp
GO

USE ShackUp
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name='States')
DROP TABLE States
GO

CREATE TABLE States(
StateId char(2) not null primary key,
StateName varchar(15) not null
)

IF EXISTS (SELECT * FROM sys.tables WHERE name='BathroomTypes')
DROP TABLE BathroomTypes
GO

CREATE TABLE BathroomTypes(
BathroomTypeId int identity(1,1) not null primary key,
BathroomTypeName varchar(15) not null
)

IF EXISTS (SELECT * FROM sys.tables WHERE name='Listings')
DROP TABLE Listings
GO

CREATE TABLE Listings(
ListingId int identity (1,1) not null primary key,
UserId nvarchar(128) not null,
StateId char(2) not null foreign key references States (StateId),
BathroomTypeId int not null foreign key references BathroomTypes(BathroomTypeId),
Nickname nvarchar(50) not null,
City nvarchar(50) not null,
Rate decimal(7,2) not null,
SquareFootage decimal(7,2) not null,
HasElectric bit not null,
HasHeat bit not null,
CreatedDate Datetime2 not null default (getdate()) 

)

IF EXISTS (SELECT * FROM sys.tables WHERE name='Favorites')
DROP TABLE Favorites
GO

CREATE TABLE Favorites(
ListingId int not null,
UserId nvarchar(128) not null,
primary key (ListingId, UserId)

)

IF EXISTS (SELECT * FROM sys.tables WHERE name='Contacts')
DROP TABLE Contacts
GO

CREATE TABLE Contacts(
ListingId int not null foreign key references Listings (ListingId),
UserId nvarchar(128) not null,
primary key (ListingId, UserId)

)

