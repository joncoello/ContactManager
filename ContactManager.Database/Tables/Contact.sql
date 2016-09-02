CREATE TABLE [dbo].[Contact]
(
	[ContactId] INT NOT NULL IDENTITY(1,1), 
    [FirstName] NVARCHAR(255) NULL, 
    [LastName] NVARCHAR(255) NOT NULL,

	CONSTRAINT PK_Contact PRIMARY KEY NONCLUSTERED (ContactId),
	INDEX IX_Contact_LastName (LastName)
)
