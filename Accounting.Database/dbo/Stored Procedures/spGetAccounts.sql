
create PROCEDURE [dbo].[spGetAccounts]
AS
BEGIN
		select *  from AccountTypes with (nolock);
END