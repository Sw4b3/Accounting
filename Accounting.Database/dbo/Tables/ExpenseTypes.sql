CREATE TABLE [dbo].[ExpenseTypes] (
    [ExpenseId]   INT            NOT NULL,
    [ExpenseType] NVARCHAR (100) NULL,
    CONSTRAINT [PK_ExpenseTypes] PRIMARY KEY CLUSTERED ([ExpenseId] ASC)
);



