CREATE TABLE [dbo].[ProcessedImportFiles] (
    [FileId]     UNIQUEIDENTIFIER CONSTRAINT [DF_ProcessedImportFile_FileId] DEFAULT (newsequentialid()) NULL,
    [Filename]   VARCHAR (255)    NULL,
    [RowCount]   INT              NULL,
    [ImportDate] DATETIME         NULL
);

