
CREATE PROCEDURE [dbo].[spGetTransactionsByDate]
@startDate datetime, @endDate datetime
AS
BEGIN

		declare @previousAmount decimal(15,2)
		
		set @previousAmount=(select top(1) Balance from Transactions
		where TransactionTimestamp between DATEADD(MONTH, DATEDIFF(MONTH, -1, GETDATE())-2, -1) and DATEADD(MONTH, DATEDIFF(MONTH, -1, GETDATE())-1, -1) and AccountTypeId=1
		order by TransactionId desc)
	

		select Description,Amount, TransactionTimestamp,t.TransactionTypeId,
		AccountTypeId, 'Pending' as Balance,TransactionStagingId as TransactionId, AccountType, TransactionType, 1 sortby
		from TransactionsStaging as t with (nolock)
			INNER JOIN Accounts with (nolock) 
			ON t.AccountTypeId=Accounts.AccountId	
			INNER JOIN TransactionTypes with (nolock) 
			ON t.TransactionTypeId=TransactionTypes.TransactionTypeId
	

		union all 

		select top (1) 'Start of the Month' as Description, @previousAmount as Amount, 
		DATEADD(month, DATEDIFF(month, 0, CURRENT_TIMESTAMP), 0) as TransactionTimestamp, 1 as TransactionTypeId, 1 as AccountTypeId, cast(@previousAmount as varchar)   as Balance,
		null as TransactionId, '...', 'None' as TransactionType, 2 sortby
		from Transactions
		--where TransactionTimestamp=DATEADD(MONTH, DATEDIFF(MONTH, -1, GETDATE())-1, -1) and AccountTypeId=1

		union all 

		select Description,Amount, TransactionTimestamp,t.TransactionTypeId,
		AccountTypeId,cast(Balance as varchar)  as Balance,TransactionId, AccountType, TransactionType, 2 sortby
		from Transactions as t with (nolock)
			INNER JOIN Accounts with (nolock) 
			ON t.AccountTypeId=Accounts.AccountId	
			INNER JOIN TransactionTypes with (nolock) 
			ON t.TransactionTypeId=TransactionTypes.TransactionTypeId
		where TransactionTimestamp BETWEEN @startDate AND  @endDate
		order by sortby, TransactionTimestamp, TransactionId
END