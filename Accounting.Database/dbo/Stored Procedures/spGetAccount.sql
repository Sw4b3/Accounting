
CREATE PROCEDURE [dbo].[spGetAccount]
@AccountNo varchar(255)
AS
BEGIN
		select *  from Accounts with (nolock) where AccountNo=@AccountNo;
END