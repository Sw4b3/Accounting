
CREATE PROCEDURE [dbo].[spGetAccount]
@AccountNo  bigint
AS
BEGIN
		select *  from Accounts with (nolock) where AccountNo=@AccountNo;
END