
CREATE PROCEDURE [dbo].[spGetExpenditureRuleOverview]
@startDate datetime, @endDate datetime
AS
BEGIN		
		select 
			case when 	sum(t.Amount)   is null 
				then 0.00
				else sum(t.Amount) 
				end ExpenditureTotal,
			er.ExpenditureDesc,
			er.ExpenditureLimit, 
			er.ShouldDisplay, 
			er.ExpenditureTypeId
		into #TempTable
		from ExpenditureRules er
			left join Expenditure e
			on e.ExpenditureRuleId=er.ExpenditureRuleId
			left join Transactions t
			on e.TransactionId=t.TransactionId
			and TransactionTimestamp BETWEEN @startDate AND @endDate
			--inner join ExpenditureTypes et
			--on et.ExpenditureTypeId=er.ExpenditureTypeId
		where er.ExpenditureDesc != 'None'
		group by  e.ExpenditureRuleId,er.ExpenditureDesc ,er.ExpenditureLimit, er.ShouldDisplay, er.ExpenditureTypeId
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