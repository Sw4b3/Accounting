
CREATE PROCEDURE [dbo].[spSaveExpenditure]
@startDate datetime, @endDate datetime
AS
BEGIN
		insert into Expenditure(TransactionId)
			select  t.TransactionId 
			from Transactions t with (nolock)
				inner join TransactionTypes tt
				on t.TransactionTypeId=tt.TransactionTypeId
			where TransactionTimestamp BETWEEN @startDate AND  @endDate 
			and AccountTypeId=1
			and TransactionType='Withdraw'
			and NOT EXISTS(select e.TransactionId from Expenditure e where t.TransactionId=e.TransactionId)
END