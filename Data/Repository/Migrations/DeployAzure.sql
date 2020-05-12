IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Movies] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(100) NOT NULL,
    [Description] nvarchar(1000) NOT NULL,
    [ReleaseDate] datetime2 NOT NULL,
    [SaveDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200511204810_InitialConfiguration', N'3.1.3');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'Description');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Movies] DROP COLUMN [Description];

GO

ALTER TABLE [Movies] ADD [Genre] nvarchar(100) NOT NULL DEFAULT N'';

GO

ALTER TABLE [Movies] ADD [Length] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Movies] ADD [Synopsis] nvarchar(1000) NOT NULL DEFAULT N'';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200512010031_AddFields_Length_Genre', N'3.1.3');

GO

