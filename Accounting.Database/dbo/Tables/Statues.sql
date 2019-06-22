CREATE TABLE [dbo].[Statues] (
    [StatusId] INT           IDENTITY (1, 1) NOT NULL,
    [Status]   VARCHAR (255) NULL,
    CONSTRAINT [PK_Statues] PRIMARY KEY CLUSTERED ([StatusId] ASC)
);

