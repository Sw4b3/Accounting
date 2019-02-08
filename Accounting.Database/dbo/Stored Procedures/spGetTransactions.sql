
CREATE PROCEDURE spGetTransactions
AS
BEGIN
		select *,AccountTypes.AccountType,TransactionTypes.TransactionType  from Transactions 
		INNER JOIN AccountTypes ON Transactions.AccountTypetId=AccountTypes.AccountId
		INNER JOIN TransactionTypes ON Transactions.TransactionTypeId=TransactionTypes.TransactionTypeId;
END