CREATE TABLE [dbo].[Transactions] (
    [Description]          NCHAR (100)      NULL,
    [Amount]               DECIMAL (15, 2)  NULL,
    [TransactionTimestamp] DATETIME         NOT NULL,
    [TransactionTypeId]    INT              NULL,
    [AccountTypetId]       INT              NULL,
    [ExpenseId]            INT              NOT NULL,
    [TransactionId]        UNIQUEIDENTIFIER CONSTRAINT [DF_Transactions_TransactionId] DEFAULT (newsequentialid()) NULL,
    CONSTRAINT [FK_Transactions_AccountTypes] FOREIGN KEY ([AccountTypetId]) REFERENCES [dbo].[AccountTypes] ([AccountId]),
    CONSTRAINT [FK_Transactions_ExpenseTypes] FOREIGN KEY ([ExpenseId]) REFERENCES [dbo].[ExpenseTypes] ([ExpenseId]),
    CONSTRAINT [FK_Transactions_TransactionTypes] FOREIGN KEY ([TransactionTypeId]) REFERENCES [dbo].[TransactionTypes] ([TransactionTypeId])
);





