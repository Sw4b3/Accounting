CREATE TABLE [dbo].[TransactionsStaging] (
    [Description]          NVARCHAR (100)   NOT NULL,
    [Amount]               DECIMAL (15, 2)  NULL,
    [TransactionTimestamp] DATETIME         NOT NULL,
    [TransactionTypeId]    INT              NULL,
    [AccountTypeId]        INT              NULL,
    [TransactionStagingId] UNIQUEIDENTIFIER CONSTRAINT [DF_TransactionsStaging_TransactionStagingId] DEFAULT (newsequentialid()) NOT NULL,
    CONSTRAINT [PK_TransactionsStaging] PRIMARY KEY CLUSTERED ([TransactionStagingId] ASC),
    CONSTRAINT [FK_TransactionsStaging_Accounts] FOREIGN KEY ([AccountTypeId]) REFERENCES [dbo].[Accounts] ([AccountId]),
    CONSTRAINT [FK_TransactionsStaging_TransactionsStaging] FOREIGN KEY ([TransactionStagingId]) REFERENCES [dbo].[TransactionsStaging] ([TransactionStagingId])
);

