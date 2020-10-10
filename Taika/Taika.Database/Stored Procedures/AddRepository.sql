CREATE PROCEDURE [dbo].[AddRepository]
(
	@Id UNIQUEIDENTIFIER,
	@Name VARCHAR(50),
	@Url VARCHAR(250),
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

			INSERT INTO dbo.Repositories 
			(
				[Id],
				[Name],
				[Url],
				[CreatedOn]
			)
			VALUES
			(
				@Id,
				@Name,
				@Url,
				@CreatedOn
			)

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		DECLARE @ErrorMessage VARCHAR(250) = CONCAT('Error inserting new repository: ', ERROR_MESSAGE())
		RAISERROR (@ErrorMessage, 16, 1)
	END CATCH
END