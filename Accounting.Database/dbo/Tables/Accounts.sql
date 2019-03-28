CREATE TABLE [dbo].[Accounts] (
    [AccountId]        INT             IDENTITY (1, 1) NOT NULL,
    [AccountType]      NVARCHAR (50)   NULL,
    [CurrentBalance]   DECIMAL (15, 2) CONSTRAINT [DF_Accounts_Balance] DEFAULT ((0)) NULL,
    [AvailableBalance] DECIMAL (15, 2) NULL,
    [Status]           VARCHAR (256)   CONSTRAINT [DF_Accounts_Status] DEFAULT ('Active') NULL,
    CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED ([AccountId] ASC),
    CONSTRAINT [FK_AccountTypes_AccountTypes] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Accounts] ([AccountId])
);





