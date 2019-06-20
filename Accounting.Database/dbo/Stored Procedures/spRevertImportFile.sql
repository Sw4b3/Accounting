
CREATE PROCEDURE [dbo].[spRevertImportFile]
AS
BEGIN
	declare @currentImportDate datetime, @currentBalance decimal(10,2), @previousPending decimal(10,2)
	
	set @currentImportDate  = (select top 1 ImportDate from ProcessedImportFiles order by ImportDate desc)
	set @previousPending=(select CurrentBalance-AvailableBalance from Accounts where AccountId = 1 )

	delete Transactions where ImportDate=@currentImportDate
	delete ProcessedImportFiles where ImportDate=@currentImportDate

	set @currentBalance  = (select top 1 Balance from Transactions where AccountTypeId=1 order by TransactionId desc)
	
	UPDATE Accounts SET CurrentBalance = @currentBalance WHERE AccountId = 1
	UPDATE Accounts SET AvailableBalance = CurrentBalance-@previousPending WHERE AccountId = 1;

END