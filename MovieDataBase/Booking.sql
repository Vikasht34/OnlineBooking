CREATE TABLE [dbo].[Booking]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [MovieId] INT NOT NULL, 
    [CinemaId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Seats] INT NOT NULL, 
    [MovieTime] TIME NOT NULL,
	CONSTRAINT [FK_Booking_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie]([Id]),
    CONSTRAINT [FK_Booking_Cinema] FOREIGN KEY ([CinemaId]) REFERENCES  [dbo].[Cinema]([Id]),
	CONSTRAINT [FK_Booking_User] FOREIGN KEY ([UserId]) REFERENCES  [dbo].[User]([Id])
)
