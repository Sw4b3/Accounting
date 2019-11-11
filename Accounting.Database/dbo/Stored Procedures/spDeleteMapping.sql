
create PROCEDURE [dbo].[spDeleteMapping]
@mappingId int
AS
BEGIN		
		delete DescriptionMappings
		where MappingId=@mappingId
END