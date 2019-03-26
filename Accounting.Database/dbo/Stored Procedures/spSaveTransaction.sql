
CREATE PROCEDURE [dbo].[spSaveTransaction]
@amount decimal(10,2),@balance decimal(10,2),@accountTypeId int,@transactionTypeId int, @description varchar(100), @transactionTimestamp datetime 
AS
BEGIN
	declare @currentBalance decimal(10,2)
	set @currentBalance=(select CurrentBalance from Accounts where AccountId = @accountTypeId )

		IF @balance = 0.00
			begin
			IF @transactionTypeId = 1
				UPDATE Accounts SET CurrentBalance = @currentBalance + @amount WHERE AccountId = @accountTypeId;
			ELSE
				begin
				UPDATE Accounts SET CurrentBalance = @currentBalance - @amount WHERE AccountId = @accountTypeId;
			insert into Transactions(Description,Amount,Balance, AccountTypeId, TransactionTypeId,TransactionTimestamp)
			values (@description,@amount,@currentBalance-@amount, @accountTypeId ,@transactionTypeId, CONVERT (date, @transactionTimestamp))
				end
			end
		ELSE
			begin
			UPDATE Accounts SET CurrentBalance = @balance WHERE AccountId = @accountTypeId;
			insert into Transactions(Description,Amount,Balance, AccountTypeId, TransactionTypeId,TransactionTimestamp)
			values (@description,@amount,@balance, @accountTypeId ,@transactionTypeId, CONVERT (date, @transactionTimestamp))
			end
END