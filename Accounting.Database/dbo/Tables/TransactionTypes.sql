CREATE TABLE [dbo].[TransactionTypes] (
    [TransactionTypeId] INT        NOT NULL,
    [TransactionType]   NCHAR (45) NULL,
    CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED ([TransactionTypeId] ASC)
);

