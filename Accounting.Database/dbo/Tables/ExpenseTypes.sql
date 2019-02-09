CREATE TABLE [dbo].[ExpenseTypes] (
    [ExpenseId]   INT         NOT NULL,
    [ExpenseType] NCHAR (100) NULL,
    CONSTRAINT [PK_ExpenseTypes] PRIMARY KEY CLUSTERED ([ExpenseId] ASC)
);

