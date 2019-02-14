
CREATE PROCEDURE [dbo].[spUpdateTransaction]
@transactionId uniqueidentifier, @amount decimal, @description varchar(100)
AS
BEGIN
		update Transactions set Description=@description, Amount=@amount
		where TransactionId=@transactionId;
END