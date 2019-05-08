
create PROCEDURE [dbo].[spSaveExpenditureTypes]
@expenditureDesc varchar(250), @expenditureLimit decimal(15,2)
AS
BEGIN
		insert into ExpenditureTypes(ExpenditureDesc, ExpenditureLimit)
		values (@expenditureDesc, @expenditureLimit)
END