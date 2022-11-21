CREATE PROCEDURE [dbo].[GetSetting]
(
	@Key VARCHAR(30)
)
AS
BEGIN
	SELECT
		[Key],
		[Value],
		[CreatedOn]
	FROM dbo.ApplicationSettings WITH (READCOMMITTED)
	WHERE
		[Key] = @Key
END