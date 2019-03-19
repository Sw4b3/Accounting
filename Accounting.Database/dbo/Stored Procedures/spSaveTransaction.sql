
CREATE PROCEDURE [dbo].[spSaveTransaction]
@amount decimal(10,2),@accountTypeId int,@expenseId int,@transactionTypeId int, @description varchar(100)
AS
BEGIN
		IF @transactionTypeId = 1
			UPDATE Accounts SET Balance = Balance + @amount WHERE AccountId = @accountTypeId;
		ELSE
			UPDATE Accounts SET Balance = Balance - @amount WHERE AccountId = @accountTypeId;

		insert into Transactions(Description,Amount, AccountTypeId,ExpenseId, TransactionTypeId,TransactionTimestamp)
		values (@description,@amount, @accountTypeId ,@expenseId,@transactionTypeId, CONVERT (date, CURRENT_TIMESTAMP))
END