
CREATE PROCEDURE [dbo].[spUpdateExpenditureRules]
@expenditureDesc varchar(250), @expenditureLimit decimal(15,2), @expenditureRuleId int, @shouldDisplay bit
AS
BEGIN
		update ExpenditureRules set ExpenditureLimit=@expenditureLimit, ExpenditureDesc=@expenditureDesc, ShouldDisplay=@shouldDisplay
		where ExpenditureRuleId=@expenditureRuleId;
END