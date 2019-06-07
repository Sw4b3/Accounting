
CREATE PROCEDURE [dbo].[spGetAnalyticsOverview]
@startDate datetime, @endDate datetime
AS
BEGIN
		select Description, sum(Amount) as Amount
		from TransactionsStaging 
		where TransactionTypeId=2  and TransactionTimestamp between @startDate and @endDate
		group by Description  

		union all

		select Description, sum(Amount) as Amount
		from Transactions 
		where TransactionTypeId=2  and TransactionTimestamp between @startDate and @endDate
		group by Description  
END