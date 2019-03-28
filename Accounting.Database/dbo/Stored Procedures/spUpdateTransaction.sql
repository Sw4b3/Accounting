
CREATE PROCEDURE [dbo].[spUpdateTransaction]
@transactionId uniqueidentifier, @amount decimal(10,2), @description varchar(100), @date datetime, @transactionStatus varchar(256)
AS
BEGIN
		declare @transactionTypeId int,
		@oldAmount decimal(10,2)

		set @transactionTypeId=(select TransactionTypeId from Transactions where TransactionId=@transactionId)
		set @oldAmount=(select Amount from Transactions where TransactionId=@transactionId)

		IF @transactionTypeId = 1
			begin
			UPDATE Accounts SET CurrentBalance = CurrentBalance - @oldAmount WHERE AccountId = 1;
			UPDATE Accounts SET CurrentBalance = CurrentBalance + @amount WHERE AccountId = 1;
			end
		ELSE
			begin
			UPDATE Accounts SET CurrentBalance = CurrentBalance + @oldAmount WHERE AccountId = 1;
			UPDATE Accounts SET CurrentBalance = CurrentBalance - @amount WHERE AccountId = 1;
			end

		update Transactions set Description=@description, Amount=@amount, TransactionTimestamp=@date, TransactionStatus=@transactionStatus
		where TransactionId=@transactionId;
END