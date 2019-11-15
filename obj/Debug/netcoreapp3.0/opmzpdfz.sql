﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Batalhas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    [InicioBatalha] datetime2 NOT NULL,
    [FimBatalha] datetime2 NOT NULL,
    CONSTRAINT [PK_Batalhas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Herois] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [BatalhaId] int NOT NULL,
    CONSTRAINT [PK_Herois] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Herois_Batalhas_BatalhaId] FOREIGN KEY ([BatalhaId]) REFERENCES [Batalhas] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Armas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [HeroiId] int NULL,
    [IdHeroi] int NOT NULL,
    CONSTRAINT [PK_Armas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Armas_Herois_HeroiId] FOREIGN KEY ([HeroiId]) REFERENCES [Herois] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Armas_HeroiId] ON [Armas] ([HeroiId]);

GO

CREATE INDEX [IX_Herois_BatalhaId] ON [Herois] ([BatalhaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191115005803_initial2', N'3.0.0');

GO

