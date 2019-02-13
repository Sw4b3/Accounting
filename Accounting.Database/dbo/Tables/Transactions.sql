CREATE TABLE [dbo].[Transactions] (
    [Description]          NVARCHAR (100)   NULL,
    [Amount]               DECIMAL (15, 2)  NULL,
    [TransactionTimestamp] DATETIME         NOT NULL,
    [TransactionTypeId]    INT              NULL,
    [AccountTypeId]        INT              NULL,
    [ExpenseId]            INT              NOT NULL,
    [TransactionId]        UNIQUEIDENTIFIER CONSTRAINT [DF_Transactions_TransactionId] DEFAULT (newsequentialid()) NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([TransactionId] ASC),
    CONSTRAINT [FK_Transactions_AccountTypes] FOREIGN KEY ([AccountTypeId]) REFERENCES [dbo].[AccountTypes] ([AccountId]),
    CONSTRAINT [FK_Transactions_ExpenseTypes] FOREIGN KEY ([ExpenseId]) REFERENCES [dbo].[ExpenseTypes] ([ExpenseId]),
    CONSTRAINT [FK_Transactions_TransactionTypes] FOREIGN KEY ([TransactionTypeId]) REFERENCES [dbo].[TransactionTypes] ([TransactionTypeId])
);









