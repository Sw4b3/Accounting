CREATE TABLE [dbo].[Transactions] (
    [TransactionId]        INT             IDENTITY (1, 1) NOT NULL,
    [Amount]               DECIMAL (15, 2) NULL,
    [TransactionTimestamp] DATETIME        NOT NULL,
    [TransactionTypeId]    INT             NULL,
    [AccountTypetId]       INT             NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([TransactionId] ASC),
    CONSTRAINT [FK_Transactions_AccountTypes] FOREIGN KEY ([AccountTypetId]) REFERENCES [dbo].[AccountTypes] ([AccountId]),
    CONSTRAINT [FK_Transactions_TransactionTypes] FOREIGN KEY ([TransactionTypeId]) REFERENCES [dbo].[TransactionTypes] ([TransactionTypeId])
);

