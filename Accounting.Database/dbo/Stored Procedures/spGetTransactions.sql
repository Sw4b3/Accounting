
CREATE PROCEDURE [dbo].[spGetTransactions]
AS
BEGIN
		select *
		from Transactions with (nolock)
			INNER JOIN AccountTypes with (nolock) 
			ON Transactions.AccountTypeId=AccountTypes.AccountId	
			INNER JOIN TransactionTypes with (nolock) 
			ON Transactions.TransactionTypeId=TransactionTypes.TransactionTypeId
		order by TransactionTimestamp;
END