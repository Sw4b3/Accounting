
CREATE PROCEDURE [dbo].[spGetExpendituresByDate]
@startDate datetime, @endDate datetime
AS
BEGIN
		select ExpenditureId, e.TransactionId, ExpenditureRuleId, Description,Amount, TransactionTimestamp
		from Expenditure e with (nolock)
			INNER JOIN Transactions with (nolock) 
			ON Transactions.TransactionId=e.TransactionId	
		where TransactionTimestamp BETWEEN @startDate AND  @endDate
END