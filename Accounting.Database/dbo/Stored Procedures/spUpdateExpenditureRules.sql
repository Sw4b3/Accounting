
CREATE PROCEDURE [dbo].[spUpdateExpenditureRules]
@expenditureDesc varchar(250), @expenditureLimit decimal(15,2), @expenditureRuleId int
AS
BEGIN
		update ExpenditureRules set ExpenditureLimit=@expenditureLimit, ExpenditureDesc=@expenditureDesc
		where ExpenditureRuleId=@expenditureRuleId;
END