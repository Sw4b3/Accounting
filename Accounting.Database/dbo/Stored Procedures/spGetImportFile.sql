
CREATE PROCEDURE [dbo].[spGetImportFile]
AS
BEGIN
		select *  
		from ProcessedImportFiles pif with (nolock)
			inner join Statues s
			on pif.StatusId=s.StatusId
END