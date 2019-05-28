
CREATE PROCEDURE [dbo].[spGetExpenditureRuleOverview]
AS
BEGIN		
		select sum(t.Amount) ExpenditureTotal, er.ExpenditureDesc,er.ExpenditureLimit 
		into #TempTable
		from Expenditure e
			inner join Transactions t
			on e.TransactionId=t.TransactionId
			inner join ExpenditureRules er
			on e.ExpenditureRuleId=er.ExpenditureRuleId
			inner join ExpenditureTypes et
			on et.ExpenditureTypeId=er.ExpenditureTypeId
			group by  e.ExpenditureRuleId,er.ExpenditureDesc, et.ExpenditureTypeId,er.ExpenditureLimit

		select  ExpenditureTotal, ExpenditureDesc, ExpenditureLimit 
		from #TempTable
		union all 
		select  sum(ExpenditureTotal), 'Total' ExpenditureDesc, sum(ExpenditureLimit) 
		from #TempTable
		where ExpenditureDesc != 'Other'
END