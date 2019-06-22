
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
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

		union all 

		select 'Average Per Day (Current Month)' as StatisticName, sum(Amount)/@monthCount as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between @startDate and @endDate and AccountTypeId=1
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

		union all
			 
		select 'Total Spending (Week 1)' as StatisticName, sum(Amount) as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between @startDate
			and DATEADD(DAY, 6, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

		union all 

		

		select 'Total Spending (Week 2)' as StatisticName, sum(Amount) as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between  DATEADD(DAY, 7, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)) 
			and DATEADD(DAY, 13, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

		union all 

		select 'Total Spending (Week 3)' as StatisticName, sum(Amount) as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between  DATEADD(DAY, 13, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)) 
			and DATEADD(DAY, 20, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

		union all 

		select 'Total Spending (Week 4)' as StatisticName, sum(Amount) as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between  DATEADD(DAY, 21, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)) 
			and @endDate
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

		union all 

		select 'Average Per Day (Week 1)' as StatisticName, sum(Amount)/7 as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between @startDate
			and DATEADD(DAY, 6, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

		union all 

		select 'Average Per Day (Week 2)' as StatisticName, sum(Amount)/7 as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between  DATEADD(DAY, 7, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)) 
			and DATEADD(DAY, 13, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

		union all 

		select 'Average Per Day (Week 3)' as StatisticName, sum(Amount)/7 as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between  DATEADD(DAY, 13, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)) 
			and DATEADD(DAY, 20, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

		union all 

		select 'Average Per Day (Week 4)' as StatisticName, sum(Amount)/7 as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between  DATEADD(DAY, 21, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)) 
			and @endDate
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

		union all 

		select 'Average Per Spending (Overall)' as StatisticName, avg(Amount) as Stat
			from Transactions 
			where TransactionTypeId=2
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 
			
		union all 

		select 'Average Per Spending (Current Month)' as StatisticName, avg(Amount) as Stat
			from Transactions 
			where TransactionTypeId=2
			and TransactionTimestamp between @startDate and @endDate and AccountTypeId=1
			and Description not in ('WEEKLY', 'WEEK','FOOD', 'SAVINGS' ) 

END