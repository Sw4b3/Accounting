
CREATE PROCEDURE [dbo].[spGetAnalyticsByDay]
@startDate datetime, @endDate datetime
AS
BEGIN
		select TransactionTimestamp, sum(Amount) as Amount
		from Transactions 
		where ExpenseId=3 and TransactionTimestamp between @startDate and @endDate and AccountTypeId=1
		group by TransactionTimestamp  

END