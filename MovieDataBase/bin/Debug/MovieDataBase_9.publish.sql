﻿/*
Deployment script for Movie

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Movie"
:setvar DefaultFilePrefix "Movie"
:setvar DefaultDataPath "C:\Users\ax583e\AppData\Local\Microsoft\VisualStudio\SSDT"
:setvar DefaultLogPath "C:\Users\ax583e\AppData\Local\Microsoft\VisualStudio\SSDT"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering [dbo].[MovieShow]...';


GO
ALTER TABLE [dbo].[MovieShow]
    ADD [CinemaName] CHAR (50) NULL;


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
print 'Mirgartion'

IF (EXISTS(SELECT * FROM [dbo].[MovieShow]))
BEGIN
    DELETE FROM [dbo].[MovieShow]
END

IF (EXISTS(SELECT * FROM [dbo].[Cinema]))
BEGIN
    DELETE FROM [dbo].[Cinema]
END

IF (EXISTS(SELECT * FROM [dbo].[Movie]))
BEGIN
    DELETE FROM [dbo].[Movie]
END






SET IDENTITY_INSERT Movie ON



INSERT INTO DBO.Movie ([Id],[MovieName],[MovieRating],[Description],[Photo]) VALUES (1,'Dabang',5,'Sallu Bhai Ki Movie','~/Pohoto/Dabang.png')
INSERT INTO DBO.Movie ([Id],[MovieName],[MovieRating],[Description],[Photo]) VALUES (2,'Dabang2',5,'Sallu Bhai Ki Movie','~/Pohoto/Dabang2.png')
--INSERT INTO DBO.Movie ([Id],[MovieName],[MovieRating],[Description],[Photo]) VALUES (3,'Lutera',5,'Ranveer Bhai Ki Movie','~/Pohoto/Lutera.png')
--INSERT INTO DBO.Movie ([Id],[MovieName],[MovieRating],[Description],[Photo]) VALUES (4,'Sajan',5,'Baba  Ki Movie','~/Pohoto/Sajan.png')
--INSERT INTO DBO.Movie ([Id],[MovieName],[MovieRating],[Description],[Photo]) VALUES (5,'Dilwale',5,'Ajay Bhai Ki Movie','~/Pohoto/Dilwale.png')
--INSERT INTO DBO.Movie ([Id],[MovieName],[MovieRating],[Description],[Photo]) VALUES (6,'DDLG',5,'Khan Bhai Ki Movie','~/Pohoto/DDLG.png')
--INSERT INTO DBO.Movie ([Id],[MovieName],[MovieRating],[Description],[Photo]) VALUES (7,'Krantiveer',5,'Nana Ki Movie','~/Pohoto/Krantiveer.png')
--INSERT INTO DBO.Movie ([Id],[MovieName],[MovieRating],[Description],[Photo]) VALUES (8,'EK hi Rasta',5,'Ajay Bhai Ki Movie','~/Pohoto/Ek.png')
--INSERT INTO DBO.Movie ([Id],[MovieName],[MovieRating],[Description],[Photo]) VALUES (9,'Janwar',5,'Akhi Ki Movie','~/Pohoto/Janwar.png')
SET IDENTITY_INSERT Movie OFF


SET IDENTITY_INSERT Cinema ON

Insert into Dbo.Cinema ([Id],[Name],[Address],[Seats]) Values(1,'PVR','R.R.Nagar','45')
Insert into Dbo.Cinema ([Id],[Name],[Address],[Seats]) Values(2,'Inox','R.R.Nagar','45')
Insert into Dbo.Cinema ([Id],[Name],[Address],[Seats]) Values(3,'BigCinema','R.R.Nagar','45')
Insert into Dbo.Cinema ([Id],[Name],[Address],[Seats]) Values(4,'MTV','R.R.Nagar','45')

SET IDENTITY_INSERT Cinema OFF


SET IDENTITY_INSERT MovieShow ON

Insert into dbo.MovieShow([Id],[CinemaId],[MovieId],[ShowTime]) Values(1,1,1,'10:30:00')
Insert into dbo.MovieShow([Id],[CinemaId],[MovieId],[ShowTime]) Values(2,1,1,'12:30:00')
Insert into dbo.MovieShow([Id],[CinemaId],[MovieId],[ShowTime]) Values(3,2,1,'12:30:00')
Insert into dbo.MovieShow([Id],[CinemaId],[MovieId],[ShowTime]) Values(4,2,1,'2:30:00')
Insert into dbo.MovieShow([Id],[CinemaId],[MovieId],[ShowTime]) Values(5,3,1,'10:30:00')
Insert into dbo.MovieShow([Id],[CinemaId],[MovieId],[ShowTime]) Values(6,3,1,'12:30:00')
Insert into dbo.MovieShow([Id],[CinemaId],[MovieId],[ShowTime]) Values(7,4,1,'10:30:00')
Insert into dbo.MovieShow([Id],[CinemaId],[MovieId],[ShowTime]) Values(8,4,1,'12:30:00')

Insert into dbo.MovieShow([Id],[CinemaId],[MovieId],[ShowTime]) Values(9,1,2,'11:30:00')
Insert into dbo.MovieShow([Id],[CinemaId],[MovieId],[ShowTime]) Values(10,1,2,'1:30:00')

SET IDENTITY_INSERT MovieShow OFF
GO

GO
PRINT N'Update complete.';


GO
