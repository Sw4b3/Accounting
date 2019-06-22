CREATE TABLE [dbo].[ProcessedImportFiles] (
    [FileId]        UNIQUEIDENTIFIER CONSTRAINT [DF_ProcessedImportFile_FileId] DEFAULT (newsequentialid()) NOT NULL,
    [Filename]      VARCHAR (255)    NULL,
    [RowCount]      INT              NULL,
    [ImportDate]    DATETIME         NULL,
    [StatusId]      INT              NULL,
    [AccountTypeId] INT              NULL,
    CONSTRAINT [PK_ProcessedImportFiles] PRIMARY KEY CLUSTERED ([FileId] ASC),
    CONSTRAINT [FK_ProcessedImportFiles_Accounts] FOREIGN KEY ([AccountTypeId]) REFERENCES [dbo].[Accounts] ([AccountId]),
    CONSTRAINT [FK_ProcessedImportFiles_Statues] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Statues] ([StatusId])
);







