--CREATE DATABASE Hospital
--USE Hospital
CREATE TABLE Doctor
(
	Id  int identity PRIMARY KEY,
	first_name NVARCHAR(100) NOT NULL,
	last_name NVARCHAR(100) NOT NULL,
	email NVARCHAR(100) NOT NULL,
	phone NVARCHAR(100) NOT NULL,
	IsDeleted bit default 0,
	creation DATE default getdate(),
	lastmodified DATE default getdate()
);
--ALTER PROCEDURE InsertDoctor
--	@FirstName NVARCHAR(100),
--	@LastName NVARCHAR(100),
--	@Email Nvarchar(100),
--	@Phone NVARCHAR(100),
--	@Creation DATE = NULL,
--	@LastModified DATE = NULL
--AS
--BEGIN
--	IF @Creation IS NULL
--        SET @Creation = GETDATE();
--    IF @LastModified IS NULL
--        SET @LastModified = GETDATE();
--	INSERT INTO Doctor (first_name, last_name, email, phone, IsDeleted, creation, lastmodified)
--	VALUES(@FirstName, @LastName, @Email, @Phone, @Creation, @LastModified);
--END;
EXEC InsertDoctor
	@FirstName = 'Seljan',
	@LastName = 'Karimli',
	@Email = 'selcankk-ab108@code.edu.az',
	@Phone = '+393391069709';
Select * from Doctor