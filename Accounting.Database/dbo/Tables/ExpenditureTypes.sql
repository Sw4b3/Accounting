CREATE TABLE [dbo].[ExpenditureTypes] (
    [ExpenditureTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [ExpenditureDesc]   VARCHAR (250) NULL,
    [ExpenditureLimit]  VARCHAR (250) NULL,
    CONSTRAINT [PK_ExpenditureTypes] PRIMARY KEY CLUSTERED ([ExpenditureTypeId] ASC)
);

