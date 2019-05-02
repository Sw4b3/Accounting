
CREATE PROCEDURE [dbo].[spSearchTransactionsByDate]
@accountTypeId int, @startDate datetime, @endDate datetime
AS
BEGIN

		select Description,Amount, TransactionTimestamp,t.TransactionTypeId,
		AccountTypeId, 'Pending' as Balance,TransactionStagingId as TransactionId, AccountType, TransactionType
		from TransactionsStaging as t with (nolock)
			INNER JOIN Accounts with (nolock) 
			ON t.AccountTypeId=Accounts.AccountId	
			INNER JOIN TransactionTypes with (nolock) 
			ON t.TransactionTypeId=TransactionTypes.TransactionTypeId
			where TransactionTimestamp BETWEEN @startDate AND  @endDate AND AccountTypeId=@accountTypeId
	

		union all 

		select  Description,Amount, TransactionTimestamp,t.TransactionTypeId,
		AccountTypeId,cast(Balance as varchar)  as Balance,TransactionId, AccountType, TransactionType
		from Transactions as t with (nolock)
			INNER JOIN Accounts with (nolock) 
			ON t.AccountTypeId=Accounts.AccountId	
			INNER JOIN TransactionTypes with (nolock) 
			ON t.TransactionTypeId=TransactionTypes.TransactionTypeId
		where TransactionTimestamp BETWEEN @startDate AND  @endDate AND AccountTypeId=@accountTypeId;
END