
Create PROCEDURE [dbo].[spSaveMapping]
@expectedString varchar(255), @processedString varchar(255)
AS
BEGIN
		insert into DescriptionMappings(ExpectedString, ProcessedString)
		values (@expectedString, @processedString)
END