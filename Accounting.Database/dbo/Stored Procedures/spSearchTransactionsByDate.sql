
CREATE PROCEDURE [dbo].[spSearchTransactionsByDate]
@accountTypeId int, @startDate datetime, @endDate datetime
AS
BEGIN
		select *,AccountTypes.AccountType,TransactionTypes.TransactionType  
		from Transactions with (nolock)
			INNER JOIN AccountTypes with (nolock) 
			ON Transactions.AccountTypeId=AccountTypes.AccountId	
			INNER JOIN TransactionTypes with (nolock) 
			ON Transactions.TransactionTypeId=TransactionTypes.TransactionTypeId
		where TransactionTimestamp BETWEEN @startDate AND  @endDate AND AccountTypeId=@accountTypeId
		order by TransactionTimestamp;
END