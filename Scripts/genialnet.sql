IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Fornecedores] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Cnpj] nvarchar(max) NOT NULL,
    [Endereco] nvarchar(max) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Fornecedores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] nvarchar(400) NOT NULL,
    [Marca] nvarchar(100) NOT NULL,
    [Medida] int NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ProdutoFornecedor] (
    [ProdutoId] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [Id] uniqueidentifier NOT NULL,
    [ValorDeCompra] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ProdutoFornecedor] PRIMARY KEY ([ProdutoId], [FornecedorId]),
    CONSTRAINT [FK_ProdutoFornecedor_Fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedores] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProdutoFornecedor_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ProdutoFornecedor_FornecedorId] ON [ProdutoFornecedor] ([FornecedorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240824193207_Init', N'8.0.8');
GO

COMMIT;
GO

