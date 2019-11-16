CREATE TABLE [dbo].[Accounts] (
    [AccountId]        INT             IDENTITY (1, 1) NOT NULL,
    [AccountType]      VARCHAR (50)    NULL,
    [CurrentBalance]   DECIMAL (15, 2) CONSTRAINT [DF_Accounts_Balance] DEFAULT ((0)) NULL,
    [AvailableBalance] DECIMAL (15, 2) NULL,
    [Status]           VARCHAR (256)   CONSTRAINT [DF_Accounts_Status] DEFAULT ('Active') NULL,
    [AccountNo]        VARCHAR (50)    NULL,
    CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED ([AccountId] ASC)
);











