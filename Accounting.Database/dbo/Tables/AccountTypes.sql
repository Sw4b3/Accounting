﻿CREATE TABLE [dbo].[AccountTypes] (
    [AccountId]   INT        NOT NULL,
    [AccountType] NCHAR (45) NULL,
    CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED ([AccountId] ASC),
    CONSTRAINT [FK_AccountTypes_AccountTypes] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[AccountTypes] ([AccountId])
);
