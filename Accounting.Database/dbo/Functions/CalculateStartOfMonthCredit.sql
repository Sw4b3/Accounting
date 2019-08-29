
CREATE function [dbo].[CalculateStartOfMonthCredit]
 (
 @DateValue AS DATETIME,
 @PreviousAmount decimal(15,2)
 )
RETURNS decimal(15,2)

AS
BEGIN
		declare @somAmount decimal(15,2)
		declare @amount decimal(15,2)
		
		set @amount=(select top(1) Balance from Transactions
		where TransactionTimestamp between DATEADD(MONTH, DATEDIFF(MONTH, -1, @DateValue)-2, -1) and DATEADD(MONTH, DATEDIFF(MONTH, -1, @DateValue)-1, -1) and AccountTypeId=1
		order by TransactionId desc)

		if @amount is not null
			set @somAmount= @amount+@PreviousAmount
		else
			set @somAmount= @PreviousAmount

		return @somAmount;
END