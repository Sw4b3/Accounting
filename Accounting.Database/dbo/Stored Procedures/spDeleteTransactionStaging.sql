
CREATE PROCEDURE [dbo].[spDeleteTransactionStaging]
@transactionId uniqueidentifier
AS
BEGIN
		declare @transactionTypeId int,
		@oldAmount decimal(10,2)

		set @transactionTypeId=(select TransactionTypeId from Transactions where TransactionId=@transactionId)
		--set @status=(select TransactionStatus from Transactions where TransactionId=@transactionId)
		set @oldAmount=(select Amount from Transactions where TransactionId=@transactionId)

		--IF @status = 'Pending'
		--	Begin
		--		IF @transactionTypeId = 1
		--			begin
		--			UPDATE Accounts SET AvailableBalance = AvailableBalance - @oldAmount WHERE AccountId = 1;
		--			end
		--		ELSE
		--			begin
		--			UPDATE Accounts SET AvailableBalance = AvailableBalance + @oldAmount WHERE AccountId = 1;
		--			end
		--	end
		--ELSE
			begin
				IF @transactionTypeId = 1
					begin
					UPDATE Accounts SET CurrentBalance = CurrentBalance - @oldAmount WHERE AccountId = 1;
					UPDATE Accounts SET AvailableBalance = AvailableBalance - @oldAmount WHERE AccountId = 1;
					end
				ELSE
					begin
					UPDATE Accounts SET CurrentBalance = CurrentBalance + @oldAmount WHERE AccountId = 1;
					UPDATE Accounts SET AvailableBalance = AvailableBalance - @oldAmount WHERE AccountId = 1;
					end
			end
		delete TransactionsStaging
		where TransactionStagingId=@transactionId
END