
CREATE PROCEDURE [dbo].[spGetAnalyticsByMonth]
AS
BEGIN
		SELECT *
		INTO #tempCredit
		FROM
		(select  DATEADD(MONTH, DATEDIFF(MONTH, 0, TransactionTimestamp), 0) as date,  dbo.CalculateStartOfMonthCredit(DATEADD(MONTH, DATEDIFF(MONTH, 0, TransactionTimestamp), 0) , sum(Amount)) as Credit
		from Transactions 
		where TransactionTypeId=1 and AccountTypeId=1
		group by DATEADD(MONTH, DATEDIFF(MONTH, 0, TransactionTimestamp), 0)) as account

		SELECT *
		INTO #tempDebit
		FROM
		(select  DATEADD(MONTH, DATEDIFF(MONTH, 0, TransactionTimestamp), 0) as date,sum(Amount) as Debit
		from Transactions 
		where TransactionTypeId=2 and AccountTypeId=1
		group by DATEADD(MONTH, DATEDIFF(MONTH, 0, TransactionTimestamp), 0)) as account

		select #tempCredit.date, Credit,Debit, Credit-Debit as Balance from #tempDebit
		inner join #tempCredit
		on #tempCredit.date=#tempDebit.date
		order by date

		drop table  #tempCredit 
		drop table  #tempDebit 

END