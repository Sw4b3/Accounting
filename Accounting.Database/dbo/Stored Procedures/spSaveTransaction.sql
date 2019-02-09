
CREATE PROCEDURE [dbo].[spSaveTransaction]
@amount decimal,@accountType int,@expenseId int,@transactionType int, @description varchar(100)
AS
BEGIN
		insert into Transactions(Description,Amount, AccountTypetId,ExpenseId, TransactionTypeId,TransactionTimestamp)
		values (@description,@amount, @accountType ,@expenseId,@transactionType, CURRENT_TIMESTAMP)
END