
CREATE PROCEDURE [dbo].[spGetExpenditureRules]
AS
BEGIN
		select *  from ExpenditureRules with (nolock)
		order by ExpenditureTypeId
END