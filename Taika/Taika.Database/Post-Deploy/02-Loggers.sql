PRINT 'Inserting default logger definitions'
DECLARE @DefaultLoggers TABLE
(
    [Id] INT,
    [Name] VARCHAR(50)
)

INSERT INTO @DefaultLoggers([Id], [Name])
VALUES
    (0, 'StoredProcedure'),
    (1, 'TaikaApp')

BEGIN TRY
    PRINT 'Inserting missing default loggers'
    BEGIN TRANSACTION
        INSERT INTO [dbo].[Loggers] ([Id], [Name])
        SELECT 
	        DEL.[Id], 
	        DEL.[Name]
        FROM [dbo].[Loggers] AS LGS WITH (READCOMMITTED)
        RIGHT JOIN @DefaultLoggers AS DEL
        ON LGS.[Id] = DEL.[Id]
        WHERE LGS.[Id] IS NULL

		SET @RecordCount = @@ROWCOUNT

		PRINT 'Default loggers creation completed!'
    
		IF (@RecordCount <= 0)
		BEGIN
			PRINT 'No new logger definitions were inserted.'
		END
		ELSE
		BEGIN
			PRINT CONCAT(@RecordCount, ' new logger definitions were created.')
		END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION

    SET @ErrorMessage = CONCAT('Error inserting default loggers', ERROR_MESSAGE())

    PRINT 'ERROR!!!'
    RAISERROR(@ErrorMessage, 5, 100)
END CATCH
PRINT 'Inserting default logger definitions completed!'