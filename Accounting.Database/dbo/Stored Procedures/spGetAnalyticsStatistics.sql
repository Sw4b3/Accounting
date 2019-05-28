
CREATE PROCEDURE [dbo].[spGetAnalyticsStatistics]
@startDate datetime, @endDate datetime
AS
BEGIN
		select 'Average Per Day (Overall)' as StatisticName, avg(Amount) as Stat
			from (select sum(Amount) as Amount
			from Transactions 
			where TransactionTypeId=2
			group by TransactionTimestamp) as Ag

		union all 

		select 'Average Per Day (Current Month)' as StatisticName, avg(Amount) as Stat
			from (select sum(Amount) as Amount
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between @startDate and @endDate and AccountTypeId=1
			group by TransactionTimestamp) as Ag

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