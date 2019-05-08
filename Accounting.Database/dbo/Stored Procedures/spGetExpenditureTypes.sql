
create PROCEDURE [dbo].[spGetExpenditureTypes]
AS
BEGIN
		select *  from ExpenditureTypes with (nolock);
END