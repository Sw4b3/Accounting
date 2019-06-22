
CREATE PROCEDURE [dbo].[spSaveTransaction]
@amount decimal(10,2),@balance decimal(10,2),@accountTypeId int,@transactionTypeId int, @description varchar(100), @transactionTimestamp datetime 
AS
BEGIN
	declare @currentBalance decimal(10,2),  @availableBalance decimal(10,2),@credit decimal(10,2),@debit decimal(10,2), @fileId uniqueidentifier
	set @currentBalance=(select CurrentBalance from Accounts where AccountId = @accountTypeId )
	set @availableBalance=(select AvailableBalance from Accounts where AccountId = @accountTypeId )
	set @credit=(select sum(Amount) from TransactionsStaging where AccountTypeId = @accountTypeId and TransactionTypeId=1)
	set @debit=(select sum(Amount) from TransactionsStaging where AccountTypeId = @accountTypeId and TransactionTypeId=2)
	set @fileId=(select top 1 FileId from ProcessedImportFiles order by ImportDate desc)

		if @availableBalance != 0.00
			begin
			UPDATE Accounts SET CurrentBalance = @balance WHERE AccountId = @accountTypeId;
			if @credit is not null 
				UPDATE Accounts SET AvailableBalance = CurrentBalance-(@debit-@credit) where AccountId = @accountTypeId;
			else
				UPDATE Accounts SET AvailableBalance = CurrentBalance-@debit where AccountId = @accountTypeId;
			end
		else
			begin
			UPDATE Accounts SET CurrentBalance = @balance WHERE AccountId = @accountTypeId;
			UPDATE Accounts SET AvailableBalance = @balance WHERE AccountId = @accountTypeId;
			end

		insert into Transactions(Description,Amount,Balance, AccountTypeId, TransactionTypeId,TransactionTimestamp, FileId)
		values (@description,@amount,@balance, @accountTypeId ,@transactionTypeId, CONVERT (date, @transactionTimestamp), @fileId)
		
END