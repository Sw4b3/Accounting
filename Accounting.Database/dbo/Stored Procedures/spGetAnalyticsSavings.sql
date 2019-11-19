
CREATE PROCEDURE [dbo].[spGetAnalyticsSavings]
AS
BEGIN
		SELECT *
		FROM
		(select  DATEADD(MONTH, DATEDIFF(MONTH, 0, TransactionTimestamp), 0) as Date, dbo.GetLastTransactionOfMonth(DATEADD(MONTH, DATEDIFF(MONTH, 0, TransactionTimestamp), 0) , 3) as Amount
		from Transactions 
		where  AccountTypeId= 3 
		group by DATEADD(MONTH, DATEDIFF(MONTH, 0, TransactionTimestamp), 0)) as account
END