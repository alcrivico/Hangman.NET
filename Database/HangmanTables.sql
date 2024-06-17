IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type IN ('U'))
	DROP TABLE [dbo].[Category]

CREATE TABLE [Category] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryES] varchar(55) NOT NULL,
    [CategoryEN] varchar(55) NOT NULL
)

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[GameStatus]') AND type IN ('U'))
	DROP TABLE [dbo].[GameStatus]

CREATE TABLE [GameStatus] (
    -- Waiting, Playing, Won, Lost, Cancelled, Left
    -- Esperando, Jugando, Ganado, Perdido, Cancelado, Abandonado
    [Id] int IDENTITY(1,1) NOT NULL,
    [StatusEn] varchar(10) NULL,
    [StatusEs] varchar(10) NULL
)

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Language]') AND type IN ('U'))
	DROP TABLE [dbo].[Language]

CREATE TABLE [Language] (
    [Id] int  IDENTITY(1,1) NOT NULL,
    [LanguageName] varchar(55)  NULL
)

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Player]') AND type IN ('U'))
	DROP TABLE [dbo].[Player]

CREATE TABLE [Player] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(55) NOT NULL,
    [FirstLastName] varchar(55) NOT NULL,
    [SecondLastName] varchar(55) NULL,
    [BirthDate] date NOT NULL,
    [Email] varchar(55) NOT NULL,
    [Password] varchar(55) NOT NULL,
    [Telephone] varchar(10) NOT NULL
)

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Word]') AND type IN ('U'))
	DROP TABLE [dbo].[Word]

CREATE TABLE [Word] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WordES] varchar(55) NOT NULL,
    [WordEN] varchar(55) NOT NULL,
    [TipES] varchar(55) NOT NULL,
    [TipEN] varchar(55) NOT NULL,
    [HasNumber] bit NOT NULL,
    [CategoryId] int NOT NULL
)

IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Game]') AND type IN ('U'))
	DROP TABLE [dbo].[Game]

CREATE TABLE [Game] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreationDate] datetime NOT NULL,
    [GameCode] varchar(14) NOT NULL,
    [StatusId] int NOT NULL,
    [CreatorId] int NOT NULL,
    [ChallengerId] int NULL,
    [WordId] int NOT NULL,
    [LanguageId] int NOT NULL
)

ALTER TABLE [Category] ADD CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
ALTER TABLE [GameStatus] ADD CONSTRAINT [PK_GameStatus] PRIMARY KEY ([Id])
ALTER TABLE [Language] ADD CONSTRAINT [PK_Language] PRIMARY KEY ([Id])
ALTER TABLE [Player] ADD CONSTRAINT [PK_Player] PRIMARY KEY ([Id])
ALTER TABLE [Word] ADD CONSTRAINT [PK_Word] PRIMARY KEY ([Id])
ALTER TABLE [Game] ADD CONSTRAINT [PK_Game] PRIMARY KEY ([Id])

ALTER TABLE [Game] ADD CONSTRAINT [FK_Game_GameStatus] FOREIGN KEY ([StatusId]) REFERENCES [GameStatus] ([Id])
ALTER TABLE [Game] ADD CONSTRAINT [FK_Game_Player_Creator] FOREIGN KEY ([CreatorId]) REFERENCES [Player] ([Id])
ALTER TABLE [Game] ADD CONSTRAINT [FK_Game_Player_Challenger] FOREIGN KEY ([ChallengerId]) REFERENCES [Player] ([Id])
ALTER TABLE [Game] ADD CONSTRAINT [FK_Game_Word] FOREIGN KEY ([WordId]) REFERENCES [Word] ([Id])
ALTER TABLE [Game] ADD CONSTRAINT [FK_Game_Language] FOREIGN KEY ([LanguageId]) REFERENCES [Language] ([Id])
ALTER TABLE [Word] ADD CONSTRAINT [FK_Word_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
