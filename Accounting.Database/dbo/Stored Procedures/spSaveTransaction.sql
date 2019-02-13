
CREATE PROCEDURE [dbo].[spSaveTransaction]
@amount decimal,@accountTypeId int,@expenseId int,@transactionTypeId int, @description varchar(100)
AS
BEGIN
		insert into Transactions(Description,Amount, AccountTypeId,ExpenseId, TransactionTypeId,TransactionTimestamp)
		values (@description,@amount, @accountTypeId ,@expenseId,@transactionTypeId, CURRENT_TIMESTAMP)
END