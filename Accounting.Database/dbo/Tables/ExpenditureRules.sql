CREATE TABLE [dbo].[ExpenditureRules] (
    [ExpenditureRuleId] INT             IDENTITY (1, 1) NOT NULL,
    [ExpenditureDesc]   VARCHAR (250)   NOT NULL,
    [ExpenditureLimit]  DECIMAL (15, 2) NULL,
    [ExpenditureTypeId] INT             NULL,
    [DateCreated]       DATETIME        CONSTRAINT [DF_ExpenditureRules_DateCreated] DEFAULT (getdate()) NOT NULL,
    [ShouldDisplay]     BIT             CONSTRAINT [DF_ExpenditureRules_ShouldDisplay] DEFAULT ((1)) NOT NULL,
    [IsArchived]        BIT             CONSTRAINT [DF_ExpenditureRules_IsArchived] DEFAULT ((0)) NOT NULL,
    [ArchivedDate]      DATETIME        NULL,
    CONSTRAINT [PK_ExpenditureRules] PRIMARY KEY CLUSTERED ([ExpenditureRuleId] ASC),
    CONSTRAINT [FK_ExpenditureRules_ExpenditureTypes] FOREIGN KEY ([ExpenditureTypeId]) REFERENCES [dbo].[ExpenditureTypes] ([ExpenditureTypeId])
);





