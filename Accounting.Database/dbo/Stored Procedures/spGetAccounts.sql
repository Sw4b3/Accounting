
CREATE PROCEDURE [dbo].[spGetAccounts]
AS
BEGIN
		select *  from Accounts with (nolock);
END