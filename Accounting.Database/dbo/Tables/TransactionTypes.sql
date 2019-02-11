CREATE TABLE [dbo].[TransactionTypes] (
    [TransactionTypeId] INT           NOT NULL,
    [TransactionType]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED ([TransactionTypeId] ASC)
);



