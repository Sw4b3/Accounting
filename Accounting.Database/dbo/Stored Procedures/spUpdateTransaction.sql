
CREATE PROCEDURE [dbo].[spUpdateTransaction]
@transactionId uniqueidentifier, @amount decimal(10,2), @description varchar(100), @date datetime
AS
BEGIN
		declare @transactionTypeId int,
		@oldAmount decimal(10,2)

		set @transactionTypeId=(select TransactionTypeId from TransactionsStaging where TransactionStagingId=@transactionId)
		set @oldAmount=(select Amount from TransactionsStaging where TransactionStagingId=@transactionId)

		IF @transactionTypeId = 1
			begin
			UPDATE Accounts SET AvailableBalance = AvailableBalance - @oldAmount WHERE AccountId = 1;
			UPDATE Accounts SET AvailableBalance = AvailableBalance + @amount WHERE AccountId = 1;
			end
		ELSE
			begin
			UPDATE Accounts SET AvailableBalance = AvailableBalance + @oldAmount WHERE AccountId = 1;
			UPDATE Accounts SET AvailableBalance = AvailableBalance - @amount WHERE AccountId = 1;
			end

		update TransactionsStaging set Description=@description, Amount=@amount, TransactionTimestamp=@date
		where TransactionStagingId=@transactionId;
END