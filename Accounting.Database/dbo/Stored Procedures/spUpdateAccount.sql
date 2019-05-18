
CREATE PROCEDURE [dbo].[spUpdateAccount]
@availableBalance decimal(15,2), @accountId int 
AS
BEGIN
		update Accounts set AvailableBalance=@availableBalance
		where AccountId=@accountId;
END