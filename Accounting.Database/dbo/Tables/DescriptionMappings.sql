CREATE TABLE [dbo].[DescriptionMappings] (
    [MappingId]       INT           IDENTITY (1, 1) NOT NULL,
    [ExpectedString]  VARCHAR (256) NULL,
    [ProcessedString] VARCHAR (256) NULL,
    CONSTRAINT [PK_DescriptionMappings] PRIMARY KEY CLUSTERED ([MappingId] ASC)
);

