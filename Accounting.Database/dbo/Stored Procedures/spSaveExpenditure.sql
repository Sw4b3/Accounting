
CREATE PROCEDURE [dbo].[spSaveExpenditure]
@startDate datetime, @endDate datetime
AS
BEGIN
		insert into Expenditure(TransactionId)
			select  t.TransactionId 
			from Transactions t with (nolock)
			where TransactionTimestamp BETWEEN @startDate AND  @endDate 
			and NOT EXISTS(select TransactionId from Expenditure)
END