
CREATE PROCEDURE spSaveTransaction
@amount decimal,@accountType int,@transactionType int
AS
BEGIN
		insert into Transactions(Amount,AccountTypetId, TransactionTypeId,TransactionTimestamp)
		values (@amount, @accountType ,@transactionType, CURRENT_TIMESTAMP)
END