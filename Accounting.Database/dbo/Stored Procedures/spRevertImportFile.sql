
CREATE PROCEDURE [dbo].[spRevertImportFile]
AS
BEGIN
	declare @currentImportDate datetime = (select top 1 ImportDate from ProcessedImportFiles order by ImportDate desc);

	delete Transactions where ImportDate=@currentImportDate
	delete ProcessedImportFiles where ImportDate=@currentImportDate

END