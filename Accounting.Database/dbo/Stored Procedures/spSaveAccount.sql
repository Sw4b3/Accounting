
CREATE PROCEDURE [dbo].[spSaveAccount]
@accountType varchar(45)
AS
BEGIN
		insert into Accounts(AccountType)
		values (@accountType)
END