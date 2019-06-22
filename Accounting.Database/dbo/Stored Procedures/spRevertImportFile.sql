
CREATE PROCEDURE [dbo].[spRevertImportFile]
@fileId uniqueIdentifier  
AS
BEGIN	
	declare @currentImportDate datetime = (select top 1 ImportDate from ProcessedImportFiles order by ImportDate desc),
	@credit decimal(10,2)=(select sum(Amount) from TransactionsStaging where AccountTypeId = 1 and TransactionTypeId=1),
	@debit decimal(10,2)=(select sum(Amount) from TransactionsStaging where AccountTypeId = 1 and TransactionTypeId=2),
	@status int = (select StatusId from Statues where Status='Reverted'),
	@currentStatus varchar(255) = (select s.Status from ProcessedImportFiles pfs inner join Statues s on pfs.StatusId = s.StatusId where FileId=@fileId)

	if @currentStatus != 'Completed'
		begin
				delete Transactions 
				where FileId=@fileId

				update ProcessedImportFiles
				set StatusId=@status
				where FileId=@fileId

				declare @currentBalance decimal(10,2) = (select top 1 Balance from Transactions where AccountTypeId=1 order by TransactionId desc)

				update Accounts SET CurrentBalance = @currentBalance where AccountId = 1

				if @debit is not null
					begin	
						if @credit is not null 
							update Accounts SET AvailableBalance = CurrentBalance-(@debit-@credit) where AccountId = 1;
						else
							update Accounts SET AvailableBalance = CurrentBalance-@debit where AccountId = 1;
					end
		end
END