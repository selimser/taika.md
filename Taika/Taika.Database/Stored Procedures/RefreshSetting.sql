CREATE PROCEDURE [dbo].[RefreshSetting]
(
	@Key VARCHAR(30),
	@Value VARCHAR(100),
	@CreatedOn DATETIME2(7)
)
AS
BEGIN
	DECLARE @ErrorMessage VARCHAR(250)

	IF EXISTS (SELECT 1 FROM [dbo].[ApplicationSettings] WHERE [Key] = @Key)
	BEGIN
		BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [dbo].[ApplicationSettings] SET 
			[CreatedOn] = @CreatedOn
			WHERE [Key] = @Key

			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION

			SET @ErrorMessage = CONCAT('Error refreshing the setting key: ', ERROR_MESSAGE())
			RAISERROR (@ErrorMessage, 16, 1)
		END CATCH
	END
	ELSE
	BEGIN
		EXEC [dbo].[AddOrUpdateSetting] 
			@Key = @Key, 
			@Value = @Value, 
			@CreatedOn = @CreatedOn
	END
END
