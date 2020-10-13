PRINT 'Inserting default severity levels'
DECLARE @DefaultSeverity TABLE
(
    [Id] INT,
    [Name] VARCHAR(50)
)

INSERT INTO @DefaultSeverity([Id], [Name])
VALUES
    (0, 'Debug'),
    (1, 'Info'),
    (2, 'Warn'),
    (3, 'Error'),
    (4, 'Fatal')

BEGIN TRY
    PRINT 'Inserting missing default log severity collection'
    BEGIN TRANSACTION
        INSERT INTO [dbo].[LogSeverity] ([Id], [Name])
        SELECT 
	        DES.[Id], 
	        DES.[Name]
        FROM [dbo].[LogSeverity] AS LGS WITH (READCOMMITTED)
        RIGHT JOIN @DefaultSeverity AS DES
        ON LGS.[Id] = DES.[Id]
        WHERE LGS.[Id] IS NULL

		SET @RecordCount = @@ROWCOUNT

		PRINT 'Default default log severity entry creation completed!'
    
		IF (@RecordCount <= 0)
		BEGIN
			PRINT 'No new log severity entries were inserted.'
		END
		ELSE
		BEGIN
			PRINT CONCAT(@RecordCount, ' new log severity entries were created.')
		END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION

    SET @ErrorMessage = CONCAT('Error inserting default loggers', ERROR_MESSAGE())

    PRINT 'ERROR!!!'
    RAISERROR(@ErrorMessage, 5, 100)
END CATCH
PRINT 'Inserting missing default log severity collection completed!'