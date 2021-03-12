USE GuildCar
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Car')
	DROP TABLE Car
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
	DROP TABLE Model
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
	DROP TABLE Make
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmission')
	DROP TABLE Transmission
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Interior')
	DROP TABLE Interior
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
	DROP TABLE Color
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='CarType')
	DROP TABLE CarType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyle')
	DROP TABLE BodyStyle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contact')
	DROP TABLE Contact
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Purchase')
	DROP TABLE Purchase
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseType')
	DROP TABLE PurchaseType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
	DROP TABLE States
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Special')
	DROP TABLE Special
GO

CREATE TABLE Make (
	MakeId int identity(1,1) not null primary key,
	MakeName nvarchar(50) not null,
	DateCreated datetime2 not null default(getdate()),
	UserId nvarchar(128) not null
)

CREATE TABLE Model (
	ModelId int identity(1,1) not null primary key,
	MakeId int null foreign key references Make(MakeId),
	ModelName nvarchar(50) not null,
	DateCreated datetime2 not null default(getdate()),
	UserId nvarchar(128) not null

)

CREATE TABLE PurchaseType (
	PurchaseTypeId int identity(1,1) not null primary key,
	PurchaseTypeName nvarchar(50) not null

)

CREATE TABLE Purchase (
	PurchaseId int identity(1,1) not null primary key,
	PurchaseTypeId int null foreign key references PurchaseType(PurchaseTypeId),
	PurchasePrice decimal(38) not null,
	PurchaseDate datetime2 not null default(getdate()),
	UserId nvarchar(128) null
)

CREATE TABLE Transmission (
	Id int identity(1,1) not null primary key,
	TransName nvarchar(50) null
)

CREATE TABLE CarType (
	Id int identity(1,1) not null primary key,
	CarTypeName nvarchar(50) null
)

CREATE TABLE Color (
	Id int identity(1,1) not null primary key,
	ColorName nvarchar(50) null
)

CREATE TABLE Interior (
	Id int identity(1,1) not null primary key,
	InteriorName nvarchar(50) null
)

CREATE TABLE BodyStyle (
	Id int identity(1,1) not null primary key,
	BodyStyleName nvarchar(50) null
)

CREATE TABLE Car (
	CarId int identity(1,1) not null primary key,
	MakeId int null foreign key references Make(MakeId),
	ModelId int null foreign key references Model(ModelId),
	InteriorId int null foreign key references Interior(Id),
	ColorId int null foreign key references Color(Id),
	TransId int null foreign key references Transmission(Id),
	BodyStyleId int null foreign key references BodyStyle(Id),
	PurchaseId int null foreign key references Purchase(PurchaseId),
	CarTypeId int null foreign key references CarType(Id),
	MfgYear nvarchar(50) not null,
	Mileage nvarchar(50) not null,
	VIN nvarchar(50) not null,
	MSRP decimal(10) not null,
	SalesPrice decimal(10) not null,
	CarDescription nvarchar(max) null,
	ImageFileName varchar(50),
	Feature bit not null
)

CREATE TABLE States (
	StatesId char(2) not null primary key,
	StatesName varchar(15) null

)

CREATE TABLE Contact (
	ContactId int identity(1,1) not null primary key,
	StatesId char(2) null foreign key references States(StatesId),
	PurchaseId int null foreign key references Purchase(PurchaseId),
	ContactName nvarchar(100) not null,
	Email nvarchar(100) not null,
	Phone nvarchar(50) not null,
	ContactMessage nvarchar(1000) null,
	Street1 nvarchar(100) null,
	Street2 nvarchar(100) null,
	City nvarchar(50) null,
	ZipCode nvarchar(50) null

)

CREATE TABLE Special (
	SpecialId int identity(1,1) not null primary key,
	Title nvarchar(50) null,
	SpecialDescription nvarchar(1000) null
)


