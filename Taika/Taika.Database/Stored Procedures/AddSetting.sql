CREATE PROCEDURE [dbo].[AddSetting]
(
	@Key VARCHAR(30),
	@Value VARCHAR(100),
	@CreatedOn DATETIME2(7)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

			IF @CreatedOn IS NULL
			BEGIN
				SET @CreatedOn = GETUTCDATE()
			END

			INSERT INTO dbo.ApplicationSettings 
			(
				[Key], [Value], [CreatedOn]
			)
			VALUES
			(
				@Key,
				@Value,
				@CreatedOn
			)

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		DECLARE @ErrorMessage VARCHAR(250) = CONCAT('Error inserting new setting key: ', ERROR_MESSAGE())
		RAISERROR (@ErrorMessage, 16, 1)
	END CATCH
END