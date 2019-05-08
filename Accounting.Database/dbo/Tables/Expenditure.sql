CREATE TABLE [dbo].[Expenditure] (
    [ExpenditureId]     UNIQUEIDENTIFIER CONSTRAINT [DF_Expenditure_ExpenditureId] DEFAULT (newsequentialid()) NOT NULL,
    [TransactionId]     UNIQUEIDENTIFIER NOT NULL,
    [ExpenditureTypeId] INT              NULL,
    CONSTRAINT [PK_Expenditure] PRIMARY KEY CLUSTERED ([ExpenditureId] ASC),
    CONSTRAINT [FK_Expenditure_ExpenditureTypes] FOREIGN KEY ([ExpenditureTypeId]) REFERENCES [dbo].[ExpenditureTypes] ([ExpenditureTypeId]),
    CONSTRAINT [FK_Expenditure_Transactions] FOREIGN KEY ([TransactionId]) REFERENCES [dbo].[Transactions] ([TransactionId])
);

