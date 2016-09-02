CREATE PROCEDURE [dbo].[spGetContacts]
	@Offset int = 0,
	@PageSize int = 20
AS
	SELECT 
		ContactId,
		FirstName,
		LastName 
	FROM 
		Contact
	order by
		LastName, FirstName
	Offset @Offset Rows
	Fetch Next @PageSize Rows Only

