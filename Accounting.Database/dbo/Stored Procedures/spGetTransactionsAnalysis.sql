
CREATE PROCEDURE [dbo].[spGetTransactionsAnalysis]
AS
BEGIN
		select Description, sum(Amount) as Amount
		from Transactions 
		where ExpenseId=3 
		group by Description  

END