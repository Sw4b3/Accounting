
create PROCEDURE [dbo].[spGetExpenditureRules]
AS
BEGIN
		select *  from ExpenditureRules with (nolock);
END