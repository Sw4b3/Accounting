
CREATE PROCEDURE [dbo].[spSaveAccount]
@accountType varchar(50), @accountNo varchar(50)
AS
BEGIN
		insert into Accounts(AccountType, AccountNo)
		values (@accountType, @accountNo)
END