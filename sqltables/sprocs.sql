IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarSelectAll')
		DROP PROCEDURE CarSelectAll
GO

CREATE PROCEDURE CarSelectAll AS 
BEGIN
	SELECT c.CarId, m.MakeName, ma.ModelName, c.CarType, c.BodyStyle, c.MfgYear, c.Transmission, c.Color, c.Interior, c.Mileage, c.VIN, c.MSRP, c.SalesPrice, c.CarDescription, c.ImageFileName, p.PurchaseDate, c.Feature
	FROM Car c
		JOIN Make m ON c.MakeId = m.MakeId
		JOIN Model ma ON c.ModelId = ma.ModelId
		JOIN Purchase p ON c.PurchaseId = p.PurchaseId

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarSelect')
		DROP PROCEDURE CarSelect
GO

CREATE PROCEDURE CarSelect (
	@carId int
)AS 
BEGIN
	SELECT c.CarId, m.MakeName, ma.ModelName, c.CarType, c.BodyStyle, c.MfgYear, c.Transmission, c.Color, c.Interior, c.Mileage, c.VIN, c.MSRP, c.SalesPrice, c.CarDescription, c.ImageFileName, p.PurchaseDate, c.Feature
	FROM Car c
		JOIN Make m ON c.MakeId = m.MakeId
		JOIN Model ma ON c.ModelId = ma.ModelId
		FULL JOIN Purchase p ON c.PurchaseId = p.PurchaseId
	WHERE c.CarId = @carId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarInsert')
		DROP PROCEDURE CarInsert
GO

CREATE PROCEDURE CarInsert (
	@CarId int output,
	@MakeId int,
	@ModelId int,
	@PurchaseId int,
	@CarType nvarchar(50),
	@BodyStyle nvarchar(50),
	@MfgYear nvarchar(50),
	@Transmission nvarchar(50),
	@Color nvarchar(50),
	@Interior nvarchar(50),
	@Mileage nvarchar(50),
	@VIN nvarchar(50),
	@MSRP nvarchar(50),
	@SalesPrice decimal(10,0),
	@CarDescription nvarchar(1000),
	@ImageFileName nvarchar(50),
	@Feature bit

) AS
BEGIN
	INSERT INTO Car (MakeId, ModelId, CarType, BodyStyle, MfgYear, Transmission, Color, Interior, Mileage, VIN, MSRP, SalesPrice, CarDescription, ImageFileName, PurchaseId, Feature)
	VALUES (@MakeId, @ModelId, @CarType, @BodyStyle, @MfgYear, @Transmission, @Color, @Interior, @Mileage, @VIN, @MSRP, @SalesPrice, @CarDescription, @ImageFileName, @PurchaseId, @Feature);
	
	SET @CarId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarUpdate')
		DROP PROCEDURE CarUpdate
GO

CREATE PROCEDURE CarUpdate (
	@CarId int output,
	@MakeId int,
	@ModelId int,
	@PurchaseId int,
	@CarType nvarchar(50),
	@BodyStyle nvarchar(50),
	@MfgYear nvarchar(50),
	@Transmission nvarchar(50),
	@Color nvarchar(50),
	@Interior nvarchar(50),
	@Mileage nvarchar(50),
	@VIN nvarchar(50),
	@MSRP nvarchar(50),
	@SalesPrice decimal(10,0),
	@CarDescription nvarchar(1000),
	@ImageFileName nvarchar(50),
	@Feature bit

) AS
BEGIN
	UPDATE Car SET 
		MakeId = @MakeId, 
		ModelId = @ModelId, 
		CarType = @CarType, 
		BodyStyle = @BodyStyle, 
		MfgYear = @MfgYear, 
		Transmission = @Transmission, 
		Color = @Color, 
		Interior = @Interior, 
		Mileage = @Mileage, 
		VIN = @VIN, 
		MSRP = @MSRP, 
		SalesPrice = @SalesPrice, 
		CarDescription = @CarDescription, 
		ImageFileName = @ImageFileName, 
		PurchaseId = @PurchaseId, 
		Feature = @Feature

	WHERE CarId = @CarId

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarDelete')
		DROP PROCEDURE CarDelete
GO

CREATE PROCEDURE CarDelete (
	@CarId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Car WHERE CarId = @CarId;

	COMMIT TRANSACTION

END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarSelectRecent')
		DROP PROCEDURE CarSelectRecent
GO

CREATE PROCEDURE CarSelectRecent AS 
BEGIN
	SELECT TOP 5 c.CarId, m.MakeName, ma.ModelName, c.CarType, c.BodyStyle, c.MfgYear, c.Transmission, c.Color, c.Interior, c.Mileage, c.VIN, c.MSRP, c.SalesPrice, c.CarDescription, c.ImageFileName, p.PurchaseDate, c.Feature
	FROM Car c
		JOIN Make m ON c.MakeId = m.MakeId
		JOIN Model ma ON c.ModelId = ma.ModelId
		JOIN Purchase p ON c.PurchaseId = p.PurchaseId
	ORDER BY c.CarId DESC
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'StatesSelectAll')
		DROP PROCEDURE StatesSelectAll
GO

CREATE PROCEDURE StatesSelectAll AS
BEGIN
	SELECT StatesId, StatesName
	FROM States
	ORDER BY StatesId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeSelectAll')
		DROP PROCEDURE MakeSelectAll
GO

CREATE PROCEDURE MakeSelectAll AS
BEGIN
	SELECT MakeId, MakeName, DateCreated, UserId
	FROM Make
	ORDER BY MakeId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelSelectAll')
		DROP PROCEDURE ModelSelectAll
GO

CREATE PROCEDURE ModelSelectAll AS
BEGIN
	SELECT a.ModelId, a.MakeId, a.ModelName, a.DateCreated, a.UserId, m.MakeName
	FROM Model a
	JOIN Make m ON a.MakeId = m.MakeId
	ORDER BY ModelId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypesSelectAll')
		DROP PROCEDURE PurchaseTypesSelectAll
GO

CREATE PROCEDURE PurchaseTypesSelectAll AS
BEGIN
	SELECT PurchaseTypeId, PurchaseTypeName
	FROM PurchaseType
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialSelectAll')
		DROP PROCEDURE SpecialSelectAll
GO

CREATE PROCEDURE SpecialSelectAll AS 
BEGIN
	SELECT SpecialId, Title, SpecialDescription
	FROM Special
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactInsert')
		DROP PROCEDURE ContactInsert
GO

CREATE PROCEDURE ContactInsert (
	@ContactId int output,
	@ContactName nvarchar(100),
	@Email nvarchar(100),
	@Phone nvarchar(50),
	@ContactMessage nvarchar(1000)

) AS
BEGIN
	INSERT INTO Contact (ContactName, Email, Phone, ContactMessage)
	VALUES (@ContactName, @Email, @Phone, @ContactMessage);
	
	SET @ContactId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactInsert1')
		DROP PROCEDURE ContactInsert1
GO

CREATE PROCEDURE ContactInsert1 (
	@ContactId int output,
	@StatesId char(2),
	@PurchaseId int,
	@ContactName nvarchar(100),
	@Email nvarchar(100),
	@Phone nvarchar(50),
	@Street1 nvarchar(100),
	@Street2 nvarchar(100),
	@City nvarchar(50),
	@ZipCode nvarchar(50)

) AS
BEGIN
	INSERT INTO Contact (StatesId, PurchaseId, ContactName, Email, Phone, Street1, Street2, City, ZipCode)
	VALUES (@StatesId, @PurchaseId, @ContactName, @Email, @Phone, @Street1, @Street2, @City, @ZipCode);
	
	SET @ContactId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialInsert')
		DROP PROCEDURE SpecialInsert
GO

CREATE PROCEDURE SpecialInsert (
	@SpecialId int output,
	@Title nvarchar(50),
	@SpecialDescription nvarchar(1000)

) AS
BEGIN
	INSERT INTO Special (Title, SpecialDescription)
	VALUES (@Title, @SpecialDescription);
	
	SET @SpecialId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeInsert')
		DROP PROCEDURE MakeInsert
GO

CREATE PROCEDURE MakeInsert (
	@MakeId int output,
	@MakeName nvarchar(50),
	@DateCreated datetime2,
	@UserId nvarchar(128)

) AS
BEGIN
	INSERT INTO Make (MakeName, DateCreated, UserId)
	VALUES (@MakeName, @DateCreated, @UserId);
	
	SET @MakeId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelInsert')
		DROP PROCEDURE ModelInsert
GO

CREATE PROCEDURE ModelInsert (
	@ModelId int output,
	@MakeId int,
	@ModelName nvarchar(50),
	@DateCreated datetime2,
	@UserId nvarchar(128)

) AS
BEGIN
	INSERT INTO Model (MakeId, ModelName, DateCreated, UserId)
	VALUES (@MakeId, @ModelName, @DateCreated, @UserId);
	
	SET @ModelId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UserInsert')
		DROP PROCEDURE UserInsert
GO

CREATE PROCEDURE UserInsert (
	@Id nvarchar(128) output,
	@Email nvarchar(256),
	@PasswordHash nvarchar(max),
	@LastName nvarchar(max),
	@FirstName nvarchar(max)

) AS
BEGIN
	INSERT INTO AspNetUsers(FirstName, LastName, Email, PasswordHash)
	VALUES (@FirstName, @LastName, @Email, @PasswordHash);
	
	SET @Id = SCOPE_IDENTITY();

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UserRoleInsert')
		DROP PROCEDURE UserRoleInsert
GO

CREATE PROCEDURE UserRoleInsert (
	@UserId nvarchar(128) output,
	@RoleId nvarchar(128)

) AS
BEGIN
	INSERT INTO AspNetUserRoles(RoleId)
	VALUES (@RoleId);
	
	SET @UserId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetNewCarReport')
		DROP PROCEDURE GetNewCarReport
GO

CREATE PROCEDURE GetNewCarReport AS 
BEGIN
	SELECT COUNT(c.CarId) AS COUNT, m.MakeName, ma.ModelName, MfgYear, SUM(MSRP) AS STOCKVALUE
	FROM Car c
		JOIN Make m ON c.MakeId = m.MakeId
		JOIN Model ma ON c.ModelId = ma.ModelId
	WHERE c.CarType = 'New'
	GROUP BY MfgYear, MakeName, ModelName

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetUsedCarReport')
		DROP PROCEDURE GetUsedCarReport
GO

CREATE PROCEDURE GetUsedCarReport AS 
BEGIN
	SELECT COUNT(c.CarId) AS COUNT, m.MakeName, ma.ModelName, MfgYear, SUM(MSRP) AS STOCKVALUE
	FROM Car c
		JOIN Make m ON c.MakeId = m.MakeId
		JOIN Model ma ON c.ModelId = ma.ModelId
	WHERE c.CarType = 'Used'
	GROUP BY MfgYear, MakeName, ModelName

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetRoles')
		DROP PROCEDURE GetRoles
GO

CREATE PROCEDURE GetRoles AS 
BEGIN
	SELECT Id, Name
	FROM AspNetRoles

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetUserRoles')
		DROP PROCEDURE GetUserRoles
GO

CREATE PROCEDURE GetUserRoles AS 
BEGIN
	SELECT UserId, RoleId
	FROM AspNetUserRoles

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetUsers')
		DROP PROCEDURE GetUsers
GO

CREATE PROCEDURE GetUsers AS 
BEGIN
	SELECT a.Id, a.Email, a.LastName, a.FirstName, r.Name
	FROM AspNetUsers a
		JOIN AspNetUserRoles ur ON a.Id = ur.UserId
		JOIN AspNetRoles r ON ur.RoleId = r.Id
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EditUser')
		DROP PROCEDURE EditUser
GO

CREATE PROCEDURE EditUser (
	@Id nvarchar(128) output,
	@Email nvarchar(256),
	@PasswordHash nvarchar(max),
	@LastName nvarchar(max),
	@FirstName nvarchar(max)

) AS
BEGIN
	UPDATE AspNetUsers SET 
		Email = @Email, 
		PasswordHash = @PasswordHash, 
		LastName = @LastName, 
		FirstName = @FirstName

	WHERE Id = @Id

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EditUserRole')
		DROP PROCEDURE EditUserRole
GO

CREATE PROCEDURE EditUserRole (
	@UserId nvarchar(128) output,
	@RoleId nvarchar(128) output

) AS
BEGIN
	UPDATE AspNetUserRoles SET 
		RoleId = @RoleId 

	WHERE UserId = @UserId

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseInsert')
		DROP PROCEDURE PurchaseInsert
GO

CREATE PROCEDURE PurchaseInsert (
	@PurchaseId int output,
	@PurchaseTypeId int,
	@PurchasePrice decimal,
	@PurchaseDate datetime2(7),
	@UserId nvarchar(128)

) AS
BEGIN
	INSERT INTO Purchase (PurchaseTypeId, PurchasePrice, PurchaseDate, UserId)
	VALUES (@PurchaseTypeId, @PurchasePrice, @PurchaseDate, @UserId);
	
	SET @PurchaseId = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarUpdatePurchaseStatus')
		DROP PROCEDURE CarUpdatePurchaseStatus
GO

CREATE PROCEDURE CarUpdatePurchaseStatus (
	@CarId int output,
	@PurchaseId int

) AS
BEGIN
	UPDATE Car SET 
		PurchaseId = @PurchaseId

	WHERE CarId = @CarId

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetPurchaseIds')
		DROP PROCEDURE GetPurchaseIds
GO

CREATE PROCEDURE GetPurchaseIds AS
BEGIN
	SELECT PurchaseId
	FROM Purchase

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetBodyStyles')
		DROP PROCEDURE GetBodyStyles
GO

CREATE PROCEDURE GetBodyStyles AS
BEGIN
	SELECT Id, BodyStyleName
	FROM BodyStyle

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetCarTypes')
		DROP PROCEDURE GetCarTypes
GO

CREATE PROCEDURE GetCarTypes AS
BEGIN
	SELECT Id, CarTypeName
	FROM CarType

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetColors')
		DROP PROCEDURE GetColors
GO

CREATE PROCEDURE GetColors AS
BEGIN
	SELECT Id, ColorName
	FROM Color

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetInteriors')
		DROP PROCEDURE GetInteriors
GO

CREATE PROCEDURE GetInteriors AS
BEGIN
	SELECT Id, InteriorName
	FROM Interior

END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetTransmissions')
		DROP PROCEDURE GetTransmissions
GO

CREATE PROCEDURE GetTransmissions AS
BEGIN
	SELECT Id, TransName
	FROM Transmission

END

GO