
Create PROCEDURE [dbo].[spGetExpenses]
AS
BEGIN
		select *  from ExpenseTypes with (nolock);
END