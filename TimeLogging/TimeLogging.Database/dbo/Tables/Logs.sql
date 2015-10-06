CREATE TABLE [dbo].[Logs] (
    [Id]        INT         NOT NULL,
    [UserId]    NCHAR (10)  NOT NULL,
    [StartTime] DATETIME    NOT NULL,
    [EndTime]   DATETIME    NOT NULL,
    [Comment]   NCHAR (255) NOT NULL,
    [Billable]  BIT         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

