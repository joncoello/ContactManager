CREATE PROCEDURE [dbo].[spGetContacts]
	
AS
	SELECT 
		ContactId,
		FirstName,
		LastName 
	FROM 
		Contact
	order by
		LastName, FirstName
	Offset 0 Rows
	Fetch Next 10 Rows Only

