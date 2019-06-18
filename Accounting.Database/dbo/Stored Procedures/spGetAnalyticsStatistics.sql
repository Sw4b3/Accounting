
CREATE PROCEDURE [dbo].[spGetAnalyticsStatistics]
@startDate datetime, @endDate datetime
AS
BEGIN
		declare  @startOfYear datetime, @monthCount int,  @yearCount int

		set @startOfYear=(SELECT   DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0))
		set @monthCount = (select( DATEDIFF(DAY, @startDate, CURRENT_TIMESTAMP)))
		set @yearCount = (select( DATEDIFF(DAY,  @startOfYear, CURRENT_TIMESTAMP)))

		select 'Average Per Day (Overall)' as StatisticName, sum(Amount)/@yearCount as Stat
			from Transactions 
			where TransactionTypeId=2

		union all 

		select 'Average Per Day (Current Month)' as StatisticName, sum(Amount)/@monthCount as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between @startDate and @endDate and AccountTypeId=1
			

		union all 

		select 'Average Per Spending (Overall)' as StatisticName, avg(Amount) as Stat
			from Transactions 
			where TransactionTypeId=2
			

		union all 

		select 'Average Per Spending (Current Month)' as StatisticName, avg(Amount) as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between @startDate and @endDate and AccountTypeId=1
	

END