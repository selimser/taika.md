﻿CREATE TABLE [dbo].[Repositories]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[Url] VARCHAR(250) NOT NULL,
	[CreatedOn] DATETIME2 NOT NULL DEFAULT GETDATE()
)
