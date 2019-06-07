
CREATE PROCEDURE [dbo].[spGetExpenditureRuleOverview]
@startDate datetime, @endDate datetime
AS
BEGIN		
		select sum(t.Amount) ExpenditureTotal, er.ExpenditureDesc,er.ExpenditureLimit , er.ShouldDisplay, er.ExpenditureTypeId
		into #TempTable
		from Expenditure e
			inner join Transactions t
			on e.TransactionId=t.TransactionId
			inner join ExpenditureRules er
			on e.ExpenditureRuleId=er.ExpenditureRuleId
			inner join ExpenditureTypes et
			on et.ExpenditureTypeId=er.ExpenditureTypeId
		where TransactionTimestamp BETWEEN @startDate AND  @endDate AND er.ExpenditureDesc != 'None'
		group by  e.ExpenditureRuleId,er.ExpenditureDesc, et.ExpenditureTypeId,er.ExpenditureLimit, er.ShouldDisplay, er.ExpenditureTypeId
		order by er.ExpenditureTypeId

		select  ExpenditureTotal, ExpenditureDesc, ExpenditureLimit, ShouldDisplay, ExpenditureTypeId 
		from #TempTable
		union all 
		select  sum(ExpenditureTotal), 'Total' ExpenditureDesc, sum(ExpenditureLimit) , 0, 9
		from #TempTable
		where ExpenditureDesc != 'None'
		order by ExpenditureTypeId

		drop table #TempTable

END