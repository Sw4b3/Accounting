
CREATE PROCEDURE [dbo].[spDeleteTransaction]
@transactionId uniqueidentifier
AS
BEGIN
		declare @transactionTypeId int,
		@oldAmount decimal(10,2)

		set @transactionTypeId=(select TransactionTypeId from Transactions where TransactionId=@transactionId)
		set @oldAmount=(select Amount from Transactions where TransactionId=@transactionId)

			IF @transactionTypeId = 1
			begin
			UPDATE Accounts SET CurrentBalance = CurrentBalance - @oldAmount WHERE AccountId = 1;
			end
		ELSE
			begin
			UPDATE Accounts SET CurrentBalance = CurrentBalance + @oldAmount WHERE AccountId = 1;
			end

		delete Transactions
		where TransactionId=@transactionId
END