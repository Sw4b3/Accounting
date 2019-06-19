
Create PROCEDURE [dbo].[spSaveImportFile]
@filename varchar(255), @rowCount int
AS
BEGIN
		insert into ProcessedImportFile(Filename, [RowCount], ImportDate)
		Values(@filename, @rowCount, CONVERT (date, CURRENT_TIMESTAMP)) 
END