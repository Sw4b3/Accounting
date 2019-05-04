
CREATE PROCEDURE [dbo].[spSaveTransaction]
@amount decimal(10,2),@balance decimal(10,2),@accountTypeId int,@transactionTypeId int, @description varchar(100), @transactionTimestamp datetime 
AS
BEGIN
	declare @currentBalance decimal(10,2),  @availableBalance decimal(10,2), @previousPending decimal(10,2)
	set @currentBalance=(select CurrentBalance from Accounts where AccountId = @accountTypeId )
	set @availableBalance=(select AvailableBalance from Accounts where AccountId = @accountTypeId )
	set @previousPending=(select CurrentBalance-AvailableBalance from Accounts where AccountId = @accountTypeId )

		if @availableBalance != 0.00
			begin
			UPDATE Accounts SET CurrentBalance = @balance WHERE AccountId = @accountTypeId;
			UPDATE Accounts SET AvailableBalance = @balance-@previousPending WHERE AccountId = @accountTypeId;
			end
		else
			begin
			UPDATE Accounts SET CurrentBalance = @balance WHERE AccountId = @accountTypeId;
			UPDATE Accounts SET AvailableBalance = @balance WHERE AccountId = @accountTypeId;
			end

		insert into Transactions(Description,Amount,Balance, AccountTypeId, TransactionTypeId,TransactionTimestamp)
		values (@description,@amount,@balance, @accountTypeId ,@transactionTypeId, CONVERT (date, @transactionTimestamp))
		
END