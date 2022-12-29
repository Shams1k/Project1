


CREATE TABLE [User]
(
	[Id] int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(MAX) NOT NULL,
	[Login] NVARCHAR(MAX) NOT NULL,
	[Password] NVARCHAR(MAX) NOT NULL,
	[CreationDate] DateTime NOT NULL
)

CREATE TABLE [Game]
(
	[Id] int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[Score] int NOT NULL DEFAULT 0,
	[GameDate] DateTime,
	[UserId] int
)

ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Games_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO