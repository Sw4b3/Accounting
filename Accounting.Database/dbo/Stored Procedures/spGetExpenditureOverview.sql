﻿
CREATE PROCEDURE [dbo].[spGetExpenditureOverview]
@startDate datetime, @endDate datetime
AS
BEGIN
		
		select isNull(sum(Table2.ExpenditureTotal), 0) ExpenditureTotal, Table1.ExpenditureLimit, Table1.ExpenditureTypeId, table1.ExpenditureDesc

		from		(select sum(ExpenditureLimit) ExpenditureLimit, er.ExpenditureTypeId, et.ExpenditureDesc
				from ExpenditureRules er
					inner join ExpenditureTypes et
					on er.ExpenditureTypeId=et.ExpenditureTypeId
				group by er.ExpenditureTypeId, et.ExpenditureDesc) as Table1
			left join			
				(select sum(t.Amount) ExpenditureTotal,e.ExpenditureRuleId, et.ExpenditureDesc, et.ExpenditureTypeId
				from Expenditure e
					inner join Transactions t
					on e.TransactionId=t.TransactionId
					inner join ExpenditureRules er
					on e.ExpenditureRuleId=er.ExpenditureRuleId
					inner join ExpenditureTypes et
					on et.ExpenditureTypeId=er.ExpenditureTypeId
				where TransactionTimestamp BETWEEN @startDate AND  @endDate
				group by  e.ExpenditureRuleId,et.ExpenditureDesc, et.ExpenditureTypeId) as Table2

					on Table1.ExpenditureTypeId=Table2.ExpenditureTypeId
	
	group by Table1.ExpenditureTypeId, ExpenditureLimit, table1.ExpenditureDesc
END