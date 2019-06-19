
CREATE PROCEDURE [dbo].[spRevertImport]
AS
BEGIN
	declare @currentImportDate datetime = (select top 1 ImportDate from ProcessedImportFile order by ImportDate desc);

	delete Transactions where ImportDate=@currentImportDate
	delete ProcessedImportFile where ImportDate=@currentImportDate

END