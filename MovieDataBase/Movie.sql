CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [MovieName] CHAR(10) NOT NULL, 
    [MovieRating] INT NULL, 
    [Description] CHAR(50) NULL, 
    [Photo] CHAR(30) NULL
)
