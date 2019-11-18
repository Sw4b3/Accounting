
CREATE PROCEDURE [dbo].[spAutoResolveMappings]
@startDate datetime,
@endDate datetime
AS
BEGIN
	select e.* , t.Description
	into #temp
	from Expenditure e
	inner join Transactions t
		on e.TransactionId = t.TransactionId
		and t.TransactionTimestamp > @startDate 
		and TransactionTimestamp < @endDate
	where e.ExpenditureRuleId is null

	while (select count(*) from #temp)>0
		begin	
			declare @description varchar(255) = (select top 1 Description from #temp) 

			declare @ruleId int = (select e.ExpenditureRuleId 									
									from Expenditure e
									inner join Transactions t
										on e.TransactionId = t.TransactionId
										and t.TransactionTimestamp > @startDate 
										and TransactionTimestamp < @endDate
									where e.ExpenditureRuleId is not null
										and t.Description = @description)
			
			update Expenditure set ExpenditureRuleId = @ruleId
			from Expenditure e
			inner join Transactions t
				on e.TransactionId = t.TransactionId
				and t.TransactionTimestamp > @startDate 
				and TransactionTimestamp < @endDate
			where e.ExpenditureRuleId is null
				and t.Description = @description		
				
			delete #temp where Description = @description							 

		end

	drop table #temp

END