
CREATE PROCEDURE [dbo].[spRevertImportFile]
AS
BEGIN
	declare @currentImportDate datetime, @currentBalance decimal(10,2),
	@credit decimal(10,2),@debit decimal(10,2)
	
	set @currentImportDate  = (select top 1 ImportDate from ProcessedImportFiles order by ImportDate desc)
	set @credit=(select sum(Amount) from TransactionsStaging where AccountTypeId = 1 and TransactionTypeId=1)
	set @debit=(select sum(Amount) from TransactionsStaging where AccountTypeId = 1 and TransactionTypeId=2)

	delete Transactions 
	where ImportDate=@currentImportDate

	update ProcessedImportFiles
	set Status  ='Reverted'
	where ImportDate=@currentImportDate

	--delete ProcessedImportFiles where ImportDate=@currentImportDate

	set @currentBalance  = (select top 1 Balance from Transactions where AccountTypeId=1 order by TransactionId desc)
	
	update Accounts SET CurrentBalance = @currentBalance where AccountId = 1

	if @credit is not null 
		update Accounts SET AvailableBalance = CurrentBalance-(@debit-@credit) where AccountId = 1;
	else
		update Accounts SET AvailableBalance = CurrentBalance-@debit where AccountId = 1;
END