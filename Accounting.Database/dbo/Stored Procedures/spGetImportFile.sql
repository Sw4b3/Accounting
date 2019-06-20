
create PROCEDURE [dbo].[spGetImportFile]
AS
BEGIN
		select *  from ProcessedImportFiles with (nolock);
END