﻿
CREATE PROCEDURE [dbo].[spUpdateTransaction]
@transactionId uniqueidentifier, @amount decimal(10,2), @description varchar(100), @date datetime
AS
BEGIN
		declare @transactionTypeId int,
		@oldAmount decimal(10,2)

		set @transactionTypeId=(select TransactionTypeId from Transactions where TransactionId=@transactionId)
		set @oldAmount=(select Amount from Transactions where TransactionId=@transactionId)

		IF @transactionTypeId = 1
			begin
			UPDATE Accounts SET Balance = Balance - @oldAmount WHERE AccountId = 1;
			UPDATE Accounts SET Balance = Balance + @amount WHERE AccountId = 1;
			end
		ELSE
			begin
			UPDATE Accounts SET Balance = Balance + @oldAmount WHERE AccountId = 1;
			UPDATE Accounts SET Balance = Balance - @amount WHERE AccountId = 1;
			end

		update Transactions set Description=@description, Amount=@amount, TransactionTimestamp=@date
		where TransactionId=@transactionId;
END