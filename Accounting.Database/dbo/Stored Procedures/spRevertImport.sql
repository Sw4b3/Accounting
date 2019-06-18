
Create PROCEDURE [dbo].[spRevertImport]
AS
BEGIN
	declare @currentImportDate datetime = (select top 1 ImportDate from Transactions order by ImportDate desc);

	delete Transactions where ImportDate=@currentImportDate

END