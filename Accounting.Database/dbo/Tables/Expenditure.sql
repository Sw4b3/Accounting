CREATE TABLE [dbo].[Expenditure] (
    [ExpenditureId]     UNIQUEIDENTIFIER CONSTRAINT [DF_Expenditure_ExpenditureId] DEFAULT (newsequentialid()) NOT NULL,
    [TransactionId]     UNIQUEIDENTIFIER NOT NULL,
    [ExpenditureRuleId] INT              NULL,
    CONSTRAINT [PK_Expenditure] PRIMARY KEY CLUSTERED ([ExpenditureId] ASC),
    CONSTRAINT [FK_Expenditure_ExpenditureRules] FOREIGN KEY ([ExpenditureRuleId]) REFERENCES [dbo].[ExpenditureRules] ([ExpenditureRuleId]),
    CONSTRAINT [FK_Expenditure_Transactions] FOREIGN KEY ([TransactionId]) REFERENCES [dbo].[Transactions] ([TransactionId])
);



