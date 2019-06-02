CREATE TABLE [dbo].[ExpenditureRules] (
    [ExpenditureRuleId] INT             IDENTITY (1, 1) NOT NULL,
    [ExpenditureDesc]   VARCHAR (250)   NULL,
    [ExpenditureLimit]  DECIMAL (15, 2) NULL,
    [ExpenditureTypeId] INT             NULL,
    [ShouldDisplay]     BIT             CONSTRAINT [DF_ExpenditureRules_ShouldDisplay] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_ExpenditureRules] PRIMARY KEY CLUSTERED ([ExpenditureRuleId] ASC),
    CONSTRAINT [FK_ExpenditureRules_ExpenditureTypes] FOREIGN KEY ([ExpenditureTypeId]) REFERENCES [dbo].[ExpenditureTypes] ([ExpenditureTypeId])
);



