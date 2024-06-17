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
