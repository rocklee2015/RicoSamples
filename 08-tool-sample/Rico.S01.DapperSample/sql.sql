CREATE TABLE [dbo].[CICUser]
(
    [UserId]                [int] IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [Username]              [nvarchar](256) NOT NULL,
    [PasswordHash]          [nvarchar](500) NULL,
    [Email]                 [nvarchar](256) NULL,
    [PhoneNumber]           [nvarchar](30) NULL,
    [IsFirstTimeLogin]      [bit] DEFAULT(1) NOT NULL,
    [AccessFailedCount]     [int] DEFAULT(0) NOT NULL,
    [CreationDate]          [datetime] DEFAULT(GETDATE()) NOT NULL,
    [IsActive]              [bit] DEFAULT(1) NOT NULL
)

CREATE TABLE [dbo].[CICRole]
(
    [RoleId]       [int] IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    [RoleName]     [nvarchar](256) NOT NULL,
)

CREATE TABLE [dbo].[CICUserRole]
(
     [Id]   [int] IDENTITY(1, 1) PRIMARY KEY NOT NULL,
     [UserId]  [int] FOREIGN KEY REFERENCES [dbo].[CICUser] ([UserId]) NOT NULL,
     [RoleId]  [int] FOREIGN KEY REFERENCES [dbo].[CICRole] ([RoleId]) NOT NULL
)