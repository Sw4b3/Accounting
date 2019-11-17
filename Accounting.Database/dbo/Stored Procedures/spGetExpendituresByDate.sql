
CREATE PROCEDURE [dbo].[spGetExpendituresByDate]
@startDate datetime, @endDate datetime
AS
BEGIN
		select distinct ExpenditureId, e.TransactionId, e.ExpenditureRuleId, Description,Amount, TransactionTimestamp, ExpenditureDesc
		from Expenditure e with (nolock)
			INNER JOIN Transactions t with (nolock) 
			ON t.TransactionId=e.TransactionId	
			LEFT JOIN ExpenditureRules er with (nolock) 
			ON er.ExpenditureRuleId=e.ExpenditureRuleId	
		where t.TransactionTimestamp BETWEEN @startDate AND  @endDate
END