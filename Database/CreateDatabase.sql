USE [master]
GO

CREATE DATABASE [UniDays]
GO

USE [UniDays]
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[LastUpdatedDate] [datetime2](7) NOT NULL,
	CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
	(
		[UserId] ASC
	)
)
GO

CREATE PROCEDURE [GetUserByEmail]
(
	@Email NVARCHAR(500)
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		[UserId],
		[Email],
		[Password],
		[CreatedDate],
		[LastUpdatedDate]
	FROM
		[User]
	WHERE
		[Email] = @Email

END
GO

CREATE PROCEDURE [InsertUser]
(
	@Email NVARCHAR(500),
	@Password NVARCHAR(MAX)
)
AS
BEGIN
 -- Check for duplicate record, throw error if dupe

	SET NOCOUNT ON;

	INSERT INTO [User] (
		[Email],
		[Password],
		[CreatedDate],
		[LastUpdatedDate]
	)
	VALUES (
		@Email,
		@Password,
		GETDATE(),
		GETDATE()
	)

END
GO

CREATE PROCEDURE [UpdateUserPassword]
(
	@UserId INT,
	@Password NVARCHAR(MAX)
)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [User] 
	SET [Password] = @Password
	WHERE [UserId] = @UserId

END
GO