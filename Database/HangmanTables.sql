IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Hangman.Data')
BEGIN
    CREATE DATABASE [Hangman.Data];
END
GO

USE [Hangman.Data];
GO

IF OBJECT_ID('Game', 'U') IS NOT NULL DROP TABLE [Game];
IF OBJECT_ID('Word', 'U') IS NOT NULL DROP TABLE [Word];
IF OBJECT_ID('Player', 'U') IS NOT NULL DROP TABLE [Player];
IF OBJECT_ID('Language', 'U') IS NOT NULL DROP TABLE [Language];
IF OBJECT_ID('GameStatus', 'U') IS NOT NULL DROP TABLE [GameStatus];
IF OBJECT_ID('Category', 'U') IS NOT NULL DROP TABLE [Category];
GO

CREATE TABLE [Category] (
    [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [CategoryES] varchar(55) NOT NULL,
    [CategoryEN] varchar(55) NOT NULL
);
GO

CREATE TABLE [GameStatus] (
    [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [StatusEn] varchar(10) NULL,
    [StatusEs] varchar(10) NULL
);
GO

CREATE TABLE [Language] (
    [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [LanguageName] varchar(55) NULL
);
GO

CREATE TABLE [Player] (
    [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FirstName] varchar(55) NOT NULL,
    [FirstLastName] varchar(55) NOT NULL,
    [SecondLastName] varchar(55) NULL,
    [BirthDate] date NOT NULL,
    [Email] varchar(55) NOT NULL,
    [Password] varchar(55) NOT NULL,
    [Telephone] varchar(10) NOT NULL
);
GO

CREATE TABLE [Word] (
    [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [WordES] varchar(55) NOT NULL,
    [WordEN] varchar(55) NOT NULL,
    [TipES] varchar(55) NOT NULL,
    [TipEN] varchar(55) NOT NULL,
    [HasNumber] bit NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT FK_Word_Category FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
);
GO

CREATE TABLE [Game] (
    [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [CreationDate] datetime NOT NULL,
    [GameCode] varchar(14) NOT NULL,
    [StatusId] int NOT NULL,
    [CreatorId] int NOT NULL,
    [ChallengerId] int NULL,
    [WordId] int NOT NULL,
    [LanguageId] int NOT NULL,
    CONSTRAINT FK_Game_GameStatus FOREIGN KEY ([StatusId]) REFERENCES [GameStatus] ([Id]),
    CONSTRAINT FK_Game_Player_Creator FOREIGN KEY ([CreatorId]) REFERENCES [Player] ([Id]),
    CONSTRAINT FK_Game_Player_Challenger FOREIGN KEY ([ChallengerId]) REFERENCES [Player] ([Id]),
    CONSTRAINT FK_Game_Word FOREIGN KEY ([WordId]) REFERENCES [Word] ([Id]),
    CONSTRAINT FK_Game_Language FOREIGN KEY ([LanguageId]) REFERENCES [Language] ([Id])
);
GO

CREATE PROCEDURE AddGame
    @CreatorID INT,
    @WordId INT,
    @LanguageId INT
AS
BEGIN
    DECLARE @Email NVARCHAR(100);
    DECLARE @GameCode NVARCHAR(20);
    DECLARE @CreationDate DATETIME;
    DECLARE @StatusID INT;

    -- Obtener la fecha y hora actuales del sistema
    SET @CreationDate = GETDATE();

    -- Obtener el ID del status "Waiting"
    SELECT @StatusID = ID
    FROM GameStatus
    WHERE StatusEn = 'Waiting';

    -- Obtener el correo del creador
    SELECT @Email = Email
    FROM Player
    WHERE Player.Id = @CreatorID;

    -- Generar el GameCode con las dos primeras letras en mayúscula
    SET @GameCode = UPPER(LEFT(@Email, 2)) + 
                    RIGHT('0' + CAST(DAY(@CreationDate) AS NVARCHAR), 2) + 
                    RIGHT('0' + CAST(MONTH(@CreationDate) AS NVARCHAR), 2) + 
                    RIGHT(CAST(YEAR(@CreationDate) AS NVARCHAR), 2) + 
                    RIGHT('0' + CAST(DATEPART(HOUR, @CreationDate) AS NVARCHAR), 2) + 
                    RIGHT('0' + CAST(DATEPART(MINUTE, @CreationDate) AS NVARCHAR), 2) + 
                    RIGHT('0' + CAST(DATEPART(SECOND, @CreationDate) AS NVARCHAR), 2);

    -- Insertar el nuevo registro en la tabla Game
    INSERT INTO [Game] ([CreationDate], [GameCode], [StatusID], [CreatorID], [WordId], [LanguageId])
    VALUES (@CreationDate, @GameCode, @StatusID, @CreatorID, @WordId, @LanguageId);
END;