CREATE TABLE [dbo].[ProcessedImportFiles] (
    [FileId]        UNIQUEIDENTIFIER CONSTRAINT [DF_ProcessedImportFile_FileId] DEFAULT (newsequentialid()) NULL,
    [Filename]      VARCHAR (255)    NULL,
    [RowCount]      INT              NULL,
    [ImportDate]    DATETIME         NULL,
    [Status]        VARCHAR (255)    NULL,
    [AccountTypeId] INT              NULL,
    CONSTRAINT [FK_ProcessedImportFiles_Accounts] FOREIGN KEY ([AccountTypeId]) REFERENCES [dbo].[Accounts] ([AccountId])
);



