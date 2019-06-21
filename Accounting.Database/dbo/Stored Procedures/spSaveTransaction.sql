
CREATE PROCEDURE [dbo].[spSaveTransaction]
@amount decimal(10,2),@balance decimal(10,2),@accountTypeId int,@transactionTypeId int, @description varchar(100), @transactionTimestamp datetime 
AS
BEGIN
	declare @currentBalance decimal(10,2),  @availableBalance decimal(10,2),@credit decimal(10,2),@debit decimal(10,2)
	set @currentBalance=(select CurrentBalance from Accounts where AccountId = @accountTypeId )
	set @availableBalance=(select AvailableBalance from Accounts where AccountId = @accountTypeId )
	set @credit=(select sum(Amount) from TransactionsStaging where AccountTypeId = 1 and TransactionTypeId=1)
	set @debit=(select sum(Amount) from TransactionsStaging where AccountTypeId = 1 and TransactionTypeId=2)

		if @availableBalance != 0.00
			begin
			UPDATE Accounts SET CurrentBalance = @balance WHERE AccountId = @accountTypeId;
			if @credit is not null 
				UPDATE Accounts SET AvailableBalance = CurrentBalance-(@debit-@credit) where AccountId = 1;
			else
				UPDATE Accounts SET AvailableBalance = CurrentBalance-@debit where AccountId = 1;
			end
		else
			begin
			UPDATE Accounts SET CurrentBalance = @balance WHERE AccountId = @accountTypeId;
			UPDATE Accounts SET AvailableBalance = @balance WHERE AccountId = @accountTypeId;
			end

		insert into Transactions(Description,Amount,Balance, AccountTypeId, TransactionTypeId,TransactionTimestamp, ImportDate)
		values (@description,@amount,@balance, @accountTypeId ,@transactionTypeId, CONVERT (date, @transactionTimestamp), CONVERT (date, CURRENT_TIMESTAMP))
		
END