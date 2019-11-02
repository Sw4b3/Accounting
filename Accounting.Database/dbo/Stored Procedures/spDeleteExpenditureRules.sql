
create PROCEDURE [dbo].[spDeleteExpenditureRules]
  @expenditureRuleId int, @isArchived bit,  @archivedDate datetime
AS
BEGIN
		update ExpenditureRules set IsArchived = @isArchived, ArchivedDate = @archivedDate
		where ExpenditureRuleId=@expenditureRuleId;
END