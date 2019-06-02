
CREATE PROCEDURE [dbo].[spDeleteTransactionStaging]
@transactionId uniqueidentifier
AS
BEGIN
		declare @transactionTypeId int,
		@oldAmount decimal(10,2),
		@accountType int 

		set @transactionTypeId=(select TransactionTypeId from TransactionsStaging where TransactionStagingId=@transactionId)
		set @oldAmount=(select Amount from TransactionsStaging where TransactionStagingId=@transactionId)
		set @accountType=(select AccountTypeId from TransactionsStaging where TransactionStagingId=@transactionId)

			Begin
				IF @transactionTypeId = 1 and @accountType=1
					begin
					UPDATE Accounts SET AvailableBalance = AvailableBalance - @oldAmount WHERE AccountId = 1;
					end
				ELSE
					begin
					UPDATE Accounts SET AvailableBalance = AvailableBalance + @oldAmount WHERE AccountId = 1;
					end
			end
		
		delete TransactionsStaging
		where TransactionStagingId=@transactionId
END