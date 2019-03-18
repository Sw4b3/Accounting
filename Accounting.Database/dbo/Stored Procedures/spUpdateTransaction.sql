
CREATE PROCEDURE [dbo].[spUpdateTransaction]
@transactionId uniqueidentifier, @amount decimal(10,2), @description varchar(100), @date datetime
AS
BEGIN
		update Transactions set Description=@description, Amount=@amount, TransactionTimestamp=@date
		where TransactionId=@transactionId;
END