
create PROCEDURE [dbo].[spSaveAccount]
@accountType varchar(45)
AS
BEGIN
		insert into AccountTypes(AccountType)
		values (@accountType)
END