
CREATE PROCEDURE [dbo].[spGetTransactionsAnalysisByDay]
AS
BEGIN
		select TransactionTimestamp, sum(Amount) as Amount
		from Transactions 
		where TransactionTypeId=2 and TransactionTimestamp between '2019-03-01' and '2019-03-31'  and AccountTypeId=1
		group by TransactionTimestamp  

END