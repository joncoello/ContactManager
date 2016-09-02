CREATE PROCEDURE [dbo].[spInsertContact]
	@FirstName varchar(255),
	@LastName varchar(255)
AS

	declare @ContactID int

	insert into Contact(FirstName, LastName)
	values(@FirstName, @LastName)

	set @ContactID = SCOPE_IDENTITY()

	select * from Contact where ContactId = @ContactID


