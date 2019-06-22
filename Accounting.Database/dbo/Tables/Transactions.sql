CREATE TABLE [dbo].[Transactions] (
    [Description]          NVARCHAR (100)   NULL,
    [Amount]               DECIMAL (15, 2)  NULL,
    [TransactionTimestamp] DATETIME         NOT NULL,
    [TransactionTypeId]    INT              NULL,
    [AccountTypeId]        INT              NULL,
    [Balance]              DECIMAL (18, 2)  NULL,
    [TransactionId]        UNIQUEIDENTIFIER CONSTRAINT [DF_Transactions_TransactionId] DEFAULT (newsequentialid()) NOT NULL,
    [FileId]               UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([TransactionId] ASC),
    CONSTRAINT [FK_Transactions_AccountTypes] FOREIGN KEY ([AccountTypeId]) REFERENCES [dbo].[Accounts] ([AccountId]),
    CONSTRAINT [FK_Transactions_ProcessedImportFiles] FOREIGN KEY ([FileId]) REFERENCES [dbo].[ProcessedImportFiles] ([FileId]),
    CONSTRAINT [FK_Transactions_TransactionTypes] FOREIGN KEY ([TransactionTypeId]) REFERENCES [dbo].[TransactionTypes] ([TransactionTypeId])
);























