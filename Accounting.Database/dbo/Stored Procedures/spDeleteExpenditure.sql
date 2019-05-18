
create PROCEDURE [dbo].[spDeleteExpenditure]
@expenditureId uniqueidentifier
AS
BEGIN		
		delete Expenditure
		where ExpenditureId=@expenditureId
END