CREATE PROCEDURE [dbo].[AddOrUpdateSetting]
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
			[Value] = @Value,
			[CreatedOn] = @CreatedOn
			WHERE [Key] = @Key

			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION

			SET @ErrorMessage = CONCAT('Error updating an existing setting key: ', ERROR_MESSAGE())
			RAISERROR (@ErrorMessage, 16, 1)
		END CATCH
	END
	ELSE
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION

			INSERT INTO [dbo].[ApplicationSettings]
			(
				[Key],
				[Value],
				[CreatedOn] 
			)
			VALUES
			(
				@Key,
				@value,
				@CreatedOn
			)
		
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION

			SET @ErrorMessage = CONCAT('Error inserting new setting key: ', ERROR_MESSAGE())
			RAISERROR (@ErrorMessage, 16, 1)
		END CATCH
	END
END
