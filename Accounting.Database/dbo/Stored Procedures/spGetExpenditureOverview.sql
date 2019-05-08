
CREATE PROCEDURE [dbo].[spGetExpenditureOverview]
AS
BEGIN
		select SUM(t.Amount) ExpenditureTotal, ExpenditureLimit,ExpenditureDesc
		from Expenditure e
			inner join Transactions t
			on e.TransactionId=t.TransactionId
			inner join ExpenditureTypes et
			on e.ExpenditureTypeId= et.ExpenditureTypeId
		group by ExpenditureDesc, ExpenditureLimit 
		order by ExpenditureDesc
END