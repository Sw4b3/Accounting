
CREATE PROCEDURE [dbo].[spSaveTransaction]
@amount decimal(10,2),@balance decimal(10,2),@accountTypeId int,@transactionTypeId int, @description varchar(100), @transactionTimestamp datetime 
AS
BEGIN
	declare @currentBalance decimal(10,2),  @availableBalance decimal(10,2)
	set @currentBalance=(select CurrentBalance from Accounts where AccountId = @accountTypeId )
	set @availableBalance=(select AvailableBalance from Accounts where AccountId = @accountTypeId )

		IF @balance = 0.00
			begin
			IF @transactionTypeId = 1
				begin
				UPDATE Accounts SET AvailableBalance = @availableBalance + @amount WHERE AccountId = @accountTypeId;
				insert into Transactions(Description,Amount,Balance, AccountTypeId, TransactionTypeId,TransactionTimestamp,TransactionStatus)
				values (@description,@amount,@availableBalance+@amount, @accountTypeId ,@transactionTypeId, CONVERT (date, @transactionTimestamp),'Pending')
				end
			ELSE
				begin
				UPDATE Accounts SET AvailableBalance = @availableBalance - @amount WHERE AccountId = @accountTypeId;
				insert into Transactions(Description,Amount,Balance, AccountTypeId, TransactionTypeId,TransactionTimestamp,TransactionStatus)
				values (@description,@amount,@availableBalance-@amount, @accountTypeId ,@transactionTypeId, CONVERT (date, @transactionTimestamp),'Pending')
				end
			end
		ELSE
			begin
			UPDATE Accounts SET CurrentBalance = @balance WHERE AccountId = @accountTypeId;
			UPDATE Accounts SET AvailableBalance = @balance WHERE AccountId = @accountTypeId;

			insert into Transactions(Description,Amount,Balance, AccountTypeId, TransactionTypeId,TransactionTimestamp,TransactionStatus)
			values (@description,@amount,@balance, @accountTypeId ,@transactionTypeId, CONVERT (date, @transactionTimestamp),'')
			end
END