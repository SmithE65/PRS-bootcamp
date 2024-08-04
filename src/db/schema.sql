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

CREATE TABLE [Status] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(30) NOT NULL,
    [Password] nvarchar(30) NOT NULL,
    [FirstName] nvarchar(30) NOT NULL,
    [LastName] nvarchar(30) NOT NULL,
    [Phone] nvarchar(12) NOT NULL,
    [Email] nvarchar(255) NOT NULL,
    [IsReviewer] bit NOT NULL,
    [IsAdmin] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Vendors] (
    [Id] int NOT NULL IDENTITY,
    [Code] nvarchar(10) NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    [Address] nvarchar(255) NOT NULL,
    [City] nvarchar(255) NOT NULL,
    [State] nvarchar(2) NOT NULL,
    [Zip] nvarchar(5) NOT NULL,
    [Phone] nvarchar(12) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [IsPreapproved] bit NOT NULL,
    CONSTRAINT [PK_Vendors] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Messages] (
    [Id] int NOT NULL IDENTITY,
    [SenderId] int NULL,
    [SenderNavigationId] int NULL,
    [ReceiverId] int NULL,
    [ReceiverNavigationId] int NULL,
    [Text] nvarchar(max) NOT NULL,
    [TimeStamp] datetime2 NOT NULL,
    [IsRead] bit NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Messages_Users_ReceiverNavigationId] FOREIGN KEY ([ReceiverNavigationId]) REFERENCES [Users] ([Id]),
    CONSTRAINT [FK_Messages_Users_SenderNavigationId] FOREIGN KEY ([SenderNavigationId]) REFERENCES [Users] ([Id])
);
GO

CREATE TABLE [PurchaseRequests] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Description] nvarchar(100) NOT NULL,
    [Justification] nvarchar(255) NOT NULL,
    [DateNeeded] datetime2 NOT NULL,
    [DeliveryMode] nvarchar(25) NOT NULL,
    [StatusId] int NOT NULL,
    [Total] DECIMAL(19,4) NOT NULL,
    [SubmittedDate] datetime2 NOT NULL,
    [ReasonForRejection] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_PurchaseRequests] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PurchaseRequests_Status_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PurchaseRequests_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [VendorId] int NOT NULL,
    [VendorPartNumber] nvarchar(50) NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Price] DECIMAL(19,4) NOT NULL,
    [Unit] nvarchar(50) NOT NULL,
    [Photopath] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Vendors_VendorId] FOREIGN KEY ([VendorId]) REFERENCES [Vendors] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PurchaseRequestLineItems] (
    [Id] int NOT NULL IDENTITY,
    [PurchaseRequestId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL,
    [IsFulfilled] bit NOT NULL,
    CONSTRAINT [PK_PurchaseRequestLineItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PurchaseRequestLineItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PurchaseRequestLineItems_PurchaseRequests_PurchaseRequestId] FOREIGN KEY ([PurchaseRequestId]) REFERENCES [PurchaseRequests] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Messages_ReceiverNavigationId] ON [Messages] ([ReceiverNavigationId]);
GO

CREATE INDEX [IX_Messages_SenderNavigationId] ON [Messages] ([SenderNavigationId]);
GO

CREATE UNIQUE INDEX [IX_Products_VendorId_VendorPartNumber] ON [Products] ([VendorId], [VendorPartNumber]);
GO

CREATE INDEX [IX_PurchaseRequestLineItems_ProductId] ON [PurchaseRequestLineItems] ([ProductId]);
GO

CREATE INDEX [IX_PurchaseRequestLineItems_PurchaseRequestId] ON [PurchaseRequestLineItems] ([PurchaseRequestId]);
GO

CREATE INDEX [IX_PurchaseRequests_StatusId] ON [PurchaseRequests] ([StatusId]);
GO

CREATE INDEX [IX_PurchaseRequests_UserId] ON [PurchaseRequests] ([UserId]);
GO

CREATE UNIQUE INDEX [IX_Users_UserName] ON [Users] ([UserName]);
GO

CREATE UNIQUE INDEX [IX_Vendors_Name] ON [Vendors] ([Name]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211106184756_Initial', N'6.0.0');
GO

COMMIT;
GO

