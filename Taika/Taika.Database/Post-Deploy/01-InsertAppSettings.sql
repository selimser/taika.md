

DECLARE @DefaultAppSettings TABLE
(
    [Key] VARCHAR(30),
    [Value] VARCHAR(100)
)

INSERT INTO @DefaultAppSettings([Key], [Value])
VALUES
    ('Theme', 'default')

BEGIN TRY
    BEGIN TRANSACTION
        INSERT INTO [dbo].[ApplicationSettings]
        (
            [Key],
            [Value],
            [CreatedOn]
        )
        SELECT 
            [Key],
            [Value],
            GETUTCDATE()
        FROM @DefaultAppSettings
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage VARCHAR(300) 
        = CONCAT('Error inserting default application settings', ERROR_MESSAGE())

    PRINT 'ERROR!!!'
    RAISERROR(@ErrorMessage, 5, 100)
END CATCH