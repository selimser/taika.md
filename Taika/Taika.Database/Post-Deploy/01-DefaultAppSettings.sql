PRINT 'Inserting default application settings'
DECLARE @DefaultAppSettings TABLE
(
    [Key] VARCHAR(30),
    [Value] VARCHAR(100)
)

INSERT INTO @DefaultAppSettings([Key], [Value])
VALUES
    ('Theme', 'default'),
    ('Logo', 'Uploads/Logo.png'),
    ('FavIcon', 'wwwroot/favicon.ico')

BEGIN TRY
    PRINT 'Inserting missing default application settings'
    BEGIN TRANSACTION
        INSERT INTO [dbo].[ApplicationSettings] ([Key], [Value])
        SELECT 
	        DAS.[Key], 
	        DAS.[Value]
        FROM dbo.ApplicationSettings AS APS WITH (READCOMMITTED)
        RIGHT JOIN @DefaultAppSettings AS DAS
        ON APS.[Key] = DAS.[Key]
        WHERE APS.[Key] IS NULL

		SET @RecordCount = @@ROWCOUNT

		PRINT 'Default application settings creation completed!'
    
		IF @RecordCount <= 0
		BEGIN
			PRINT 'No new settings were inserted.'
		END
		ELSE
		BEGIN
			PRINT CONCAT(@RecordCount, ' new settings were created.')
		END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION

    SET @ErrorMessage = CONCAT('Error inserting default application settings', ERROR_MESSAGE())

    PRINT 'ERROR!!!'
    RAISERROR(@ErrorMessage, 5, 100)
END CATCH
PRINT 'Inserting missing default application settings completed!'