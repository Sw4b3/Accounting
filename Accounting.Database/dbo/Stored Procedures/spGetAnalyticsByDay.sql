
CREATE PROCEDURE [dbo].[spGetAnalyticsByDay]
@startDate datetime, @endDate datetime
AS
BEGIN
		select TransactionTimestamp, sum(Amount) as Amount
		from TransactionsStaging
		where TransactionTypeId=2 and TransactionTimestamp between @startDate and @endDate and AccountTypeId=1
		and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 
		group by TransactionTimestamp  

		union all

		select TransactionTimestamp, sum(Amount) as Amount
		from Transactions 
		where TransactionTypeId=2 and TransactionTimestamp between @startDate and @endDate and AccountTypeId=1
		and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 
		group by TransactionTimestamp  

END