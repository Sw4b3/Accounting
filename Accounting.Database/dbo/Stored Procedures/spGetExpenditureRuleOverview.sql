
CREATE PROCEDURE [dbo].[spGetExpenditureRuleOverview]
AS
BEGIN		
		select sum(t.Amount) ExpenditureTotal, er.ExpenditureDesc,er.ExpenditureLimit 
		from Expenditure e
			inner join Transactions t
			on e.TransactionId=t.TransactionId
			inner join ExpenditureRules er
			on e.ExpenditureRuleId=er.ExpenditureRuleId
			inner join ExpenditureTypes et
			on et.ExpenditureTypeId=er.ExpenditureTypeId
			group by  e.ExpenditureRuleId,er.ExpenditureDesc, et.ExpenditureTypeId,er.ExpenditureLimit
END