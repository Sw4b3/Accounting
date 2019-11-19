
CREATE function [dbo].[GetLastTransactionOfMonth] (@DateValue as DATETIME,@AccountTypeId as Int)
RETURNS decimal(15,2)
AS
BEGIN
		declare @amount decimal(15,2)
		
		set @amount=(select top(1) Balance from Transactions
		where TransactionTimestamp between DATEADD(MONTH, DATEDIFF(MONTH, -1, @DateValue)-2, -1) and DATEADD(MONTH, DATEDIFF(MONTH, -1, @DateValue)-1, -1) and AccountTypeId=@AccountTypeId
		order by TransactionId desc)

		return @amount;
END