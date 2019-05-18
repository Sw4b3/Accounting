
CREATE PROCEDURE [dbo].[spSaveExpenditureRule]
@expenditureDesc varchar(250), @expenditureLimit decimal(15,2), @expenditureTypeId int
AS
BEGIN
		insert into ExpenditureRules(ExpenditureDesc, ExpenditureLimit, ExpenditureTypeId)
		values (@expenditureDesc, @expenditureLimit, @expenditureTypeId)
END