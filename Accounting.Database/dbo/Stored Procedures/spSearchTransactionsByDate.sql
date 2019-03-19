
CREATE PROCEDURE [dbo].[spSearchTransactionsByDate]
@accountTypeId int, @startDate datetime, @endDate datetime
AS
BEGIN
		select *
		from Transactions with (nolock)
			INNER JOIN Accounts with (nolock) 
			ON Transactions.AccountTypeId=Accounts.AccountId	
			INNER JOIN TransactionTypes with (nolock) 
			ON Transactions.TransactionTypeId=TransactionTypes.TransactionTypeId
		where TransactionTimestamp BETWEEN @startDate AND  @endDate AND AccountTypeId=@accountTypeId
		order by TransactionTimestamp;
END