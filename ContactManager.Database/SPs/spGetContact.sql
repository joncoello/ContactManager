CREATE PROCEDURE [dbo].[spGetContact]
	@ContactID int
AS
	SELECT 
		ContactId,
		FirstName,
		LastName 
	FROM 
		Contact
	WHERE
		ContactId = @ContactID
RETURN 0
