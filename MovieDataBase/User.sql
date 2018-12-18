CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] CHAR(10) NULL, 
    [SecondName] CHAR(10) NULL, 
    [Email] CHAR(15) NULL, 
    [Password] CHAR(10) NULL
)
