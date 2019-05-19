
CREATE PROCEDURE [dbo].[spUpdateExpenditure]
@expenditureRuleId int, @expenditureId uniqueidentifier 
AS
BEGIN
		update Expenditure set ExpenditureRuleId=@expenditureRuleId
		where ExpenditureId=@expenditureId;
END