
create PROCEDURE [dbo].[spUpdateExpenditure]
@expenditureTypeId int, @expenditureId uniqueidentifier 
AS
BEGIN
		update Expenditure set ExpenditureTypeId=@expenditureTypeId
		where ExpenditureId=@expenditureId;
END