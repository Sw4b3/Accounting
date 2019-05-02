
CREATE PROCEDURE [dbo].[spSaveTransactionStaging]
@amount decimal(10,2),@balance decimal(10,2),@accountTypeId int,@transactionTypeId int, @description varchar(100), @transactionTimestamp datetime 
AS
BEGIN
	declare @currentBalance decimal(10,2),  @availableBalance decimal(10,2), @previousPending decimal(10,2)
	set @currentBalance=(select CurrentBalance from Accounts where AccountId = @accountTypeId )
	set @availableBalance=(select AvailableBalance from Accounts where AccountId = @accountTypeId )
	set @previousPending=(select CurrentBalance-AvailableBalance from Accounts where AccountId = @accountTypeId )

			IF @transactionTypeId = 1
				begin
				UPDATE Accounts SET AvailableBalance = @availableBalance + @amount WHERE AccountId = @accountTypeId;
				insert into TransactionsStaging(Description,Amount, AccountTypeId, TransactionTypeId,TransactionTimestamp)
				values (@description,@amount, @accountTypeId ,@transactionTypeId, CONVERT (date, @transactionTimestamp))
				end
			ELSE
				begin
				UPDATE Accounts SET AvailableBalance = @availableBalance - @amount WHERE AccountId = @accountTypeId;
				insert into TransactionsStaging(Description,Amount, AccountTypeId, TransactionTypeId,TransactionTimestamp)
				values (@description,@amount, @accountTypeId ,@transactionTypeId, CONVERT (date, @transactionTimestamp))
				end
					
END