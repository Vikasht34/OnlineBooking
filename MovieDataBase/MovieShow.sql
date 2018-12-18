CREATE TABLE [dbo].[MovieShow]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [MovieId] INT NOT NULL, 
    [CinemaId] INT NOT NULL, 
    [ShowTime] TIME NOT NULL, 
    [CinemaName] CHAR(50) NULL, 
    CONSTRAINT [FK_MovieShow_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie]([Id]),
    CONSTRAINT [FK_MovieShow_Cinema] FOREIGN KEY ([CinemaId]) REFERENCES  [dbo].[Cinema]([Id])

)
