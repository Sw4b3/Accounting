
CREATE PROCEDURE [dbo].[spGetAnalyticsByDay]
@startDate datetime, @endDate datetime
AS
BEGIN
		;with dates(date) as
		(select dateadd(dd, 0, datediff(dd, 0, @startDate)) as date
		union all
		select dateadd(day, 1, date) as date
		from dates
		where date <=  getdate())

		select date as TransactionTimestamp, isNull(sum(Amount), 0) as Amount
		from Dates d
			left join Transactions t
			on d.date = t.TransactionTimestamp 
			 and AccountTypeId=1
			and TransactionTypeId=2 
		where  date between @startDate and @endDate
		group by d.date  
END