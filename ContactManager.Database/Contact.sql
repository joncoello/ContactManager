CREATE TABLE [dbo].[Contact]
(
	[ContactId] INT NOT NULL, 
    [FirstName] NVARCHAR(255) NULL, 
    [LastName] NVARCHAR(255) NOT NULL,

	CONSTRAINT PK_Contact PRIMARY KEY NONCLUSTERED (ContactID),
	INDEX IX_Contact_LastName (LastName)
)
