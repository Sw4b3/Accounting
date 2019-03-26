
CREATE PROCEDURE [dbo].[spGetMappings]
AS
BEGIN
		select *  from DescriptionMappings with (nolock);
END