
CREATE PROCEDURE [dbo].[spGetExpenditureRuleOverview]
AS
BEGIN		
		select sum(t.Amount) ExpenditureTotal, er.ExpenditureDesc,er.ExpenditureLimit , er.ShouldDisplay
		into #TempTable
		from Expenditure e
			inner join Transactions t
			on e.TransactionId=t.TransactionId
			inner join ExpenditureRules er
			on e.ExpenditureRuleId=er.ExpenditureRuleId
			inner join ExpenditureTypes et
			on et.ExpenditureTypeId=er.ExpenditureTypeId
			group by  e.ExpenditureRuleId,er.ExpenditureDesc, et.ExpenditureTypeId,er.ExpenditureLimit, er.ShouldDisplay

		select  ExpenditureTotal, ExpenditureDesc, ExpenditureLimit, ShouldDisplay 
		from #TempTable
		union all 
		select  sum(ExpenditureTotal), 'Total' ExpenditureDesc, sum(ExpenditureLimit) , 0
		from #TempTable
		where ExpenditureDesc != 'Other'

		drop table #TempTable

END