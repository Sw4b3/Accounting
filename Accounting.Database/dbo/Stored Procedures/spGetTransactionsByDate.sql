
CREATE PROCEDURE [dbo].[spGetTransactionsByDate]
@startDate datetime, @endDate datetime
AS
BEGIN
		select *,AccountTypes.AccountType,TransactionTypes.TransactionType  from Transactions with (nolock)
			INNER JOIN AccountTypes with (nolock) 
			ON Transactions.AccountTypetId=AccountTypes.AccountId	
			INNER JOIN TransactionTypes with (nolock) 
			ON Transactions.TransactionTypeId=TransactionTypes.TransactionTypeId
			WHERE TransactionTimestamp BETWEEN @startDate AND  @endDate;
END