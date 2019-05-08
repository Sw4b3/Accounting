
CREATE PROCEDURE [dbo].[spUpdateExpenditureTypes]
@expenditureDesc varchar(250), @expenditureLimit decimal(15,2), @expenditureTypeId int
AS
BEGIN
		update ExpenditureTypes set ExpenditureLimit=@expenditureLimit, ExpenditureDesc=@expenditureDesc
		where ExpenditureTypeId=@expenditureTypeId;
END