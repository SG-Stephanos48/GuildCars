IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Car;
	DELETE FROM Model;
	DELETE FROM Make;
	DELETE FROM Contact;
	DELETE FROM States;
	DELETE FROM Purchase;
	DELETE FROM PurchaseType;
	DELETE FROM AspNetUsers WHERE id = '00000000-0000-0000-0000-000000000000';
	DELETE FROM AspNetRoles;
	DELETE FROM Special;

	
	SET IDENTITY_INSERT Make ON;
	INSERT INTO Make (MakeId, MakeName, DateCreated, UserId)
	VALUES (1, 'Ford', '', '00000000-0000-0000-0000-000000000000'),
	(2, 'Toyota', '', '00000000-0000-0000-0000-000000000000'),
	(3, 'Dodge', '', '00000000-0000-0000-0000-000000000000'),
    (4, 'Tesla', '', '00000000-0000-0000-0000-000000000000'),
	(5, 'Jeep', '', '00000000-0000-0000-0000-000000000000');
	SET IDENTITY_INSERT Make OFF;

	SET IDENTITY_INSERT Model ON;
	INSERT INTO Model (ModelId, MakeId, ModelName, DateCreated, UserId)
	VALUES (1, 1, 'Explorer', '', '00000000-0000-0000-0000-000000000000'),
	(2, 2, 'Highlander', '', '00000000-0000-0000-0000-000000000000'),
	(3, 3, 'Sprinter', '', '00000000-0000-0000-0000-000000000000'),
	(4, 4, 'Model S', '', '00000000-0000-0000-0000-000000000000'),
	(5, 5, 'Wrangler', '', '00000000-0000-0000-0000-000000000000');
	SET IDENTITY_INSERT Model OFF;

	SET IDENTITY_INSERT PurchaseType ON;
	INSERT INTO PurchaseType (PurchaseTypeId, PurchaseTypeName)
	VALUES (1, 'Bank Finance'),
	(2, 'Cash'),
	(3, 'Dealer Finance');
	SET IDENTITY_INSERT PurchaseType OFF;

	SET IDENTITY_INSERT Purchase ON;
	INSERT INTO Purchase (PurchaseId, PurchaseTypeId, PurchasePrice, PurchaseDate, UserId)
	VALUES (1, 1, 24000, '2021-01-01 00:00:00.0000000', 'fe110d49-6edb-4012-a0cb-b5813a1c9c91'),
	(2, 2, 32500, '2021-02-01 00:00:00.0000000', 'b7ac5228-aba7-4002-83bf-b3a4031fa32d'),
	(3, 3, 75900, '2021-03-01 00:00:00.0000000', 'b7ac5228-aba7-4002-83bf-b3a4031fa32d'),
	(4, 3, 75900, '2021-03-01 00:00:00.0000000', 'fe110d49-6edb-4012-a0cb-b5813a1c9c91'),
	(5, 3, 75900, '2021-03-01 00:00:00.0000000', 'b7ac5228-aba7-4002-83bf-b3a4031fa32d');
	SET IDENTITY_INSERT Purchase OFF;

	SET IDENTITY_INSERT Car ON;
	INSERT INTO Car (CarId, MakeId, ModelId, CarType, BodyStyle, MfgYear, Transmission, Color, Interior, Mileage, VIN, MSRP, SalesPrice, CarDescription, ImageFileName, PurchaseId, Feature)
	VALUES (1, 1, 1, 'New', 'SUV', '2021', 'Automatic', 'Red', 'Tan', '150', 'F2020600000343', 23950, 21000, 'New car w/ great personality', 'car.jpg', 1, 1),
	(2, 2, 2, 'New', 'Car', '2021', 'Standard', 'Grey', 'Black', '76', 'VW20210000T2010', 27500, 24000, 'New car that speaks German', 'car.jpg', 2, 0),
	(3, 3, 3, 'Used', 'Van', '2018', 'Automatic', 'White', 'Black', '14500', 'DS20210000T2018', 32500, 27500, 'Lightly used Sprinter Van', 'car.jpg', 3, 1),
	(4, 4, 4, 'New', 'Truck', '2021', 'Automatic', 'White', 'Black', '19', 'DS20210000T2032', 37500, 32500, 'Dream truck', 'car.jpg', 4, 0),
	(5, 5, 5, 'Used', 'Car', '1965', 'Automatic', 'Red', 'Black', '100', 'DS20210034323432', 92500, 75900, 'Incredible ', 'car.jpg', 5, 1);
	SET IDENTITY_INSERT Car OFF;

	INSERT INTO States (StatesId, StatesName)
	VALUES ('OH', 'Ohio'),
	('GA', 'Georgia'),
	('TX', 'Texas');
	   
	SET IDENTITY_INSERT Contact ON;
	INSERT INTO Contact (ContactId, StatesId, PurchaseId, ContactName, Email, Phone, ContactMessage, Street1, Street2, City, ZipCode)
	VALUES (1, 'GA', 1, 'Glenda Roswell', 'glendaisakaren@gmail.com', '214-678-0000', 'Looking for something in the mid to high $20K', '6103 Shiba Pkway', '', 'Guntersville', '31601'),
	(2, 'OH', 2, 'Jacob Ledbetter', 'jledbetter@gmail.com', '770-456-9000', 'Want a porsche', '455 DarthVader Way', '', 'Atlanta', '31567'),
	(3, 'TX', 3, 'Milton Skywalker', 'skywalker@hotmail.com', '469-956-9080', 'Need a van fast', '455 Skywalkder Dr', '', 'San Francisco', '12568');
	SET IDENTITY_INSERT Contact OFF;

	SET IDENTITY_INSERT Special ON;
	INSERT INTO Special (SpecialId, Title, SpecialDescription)
	VALUES (1, 'Dodge Sprinter', 'A Work Horse'),
	(2, 'Porsche Cayanne', 'A Ton of Fun'),
	(3, 'Chevy Corvette', 'New Sexy Design');
	SET IDENTITY_INSERT Special OFF;

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 0, 0, 0, 'test');

	INSERT INTO AspNetRoles(Id, Name)
	VALUES(1, 'Admin'), (2, 'Sales'), (3, 'Disabled');

	INSERT INTO AspNetUserRoles(UserId, RoleId)
	VALUES('00000000-0000-0000-0000-000000000000', 1), ('fe110d49-6edb-4012-a0cb-b5813a1c9c91', 1), ('9d1561ae-8a32-4c98-9208-9660fbe90345', 2), ('b7ac5228-aba7-4002-83bf-b3a4031fa32d', 3);

END