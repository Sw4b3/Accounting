
CREATE PROCEDURE [dbo].[spSaveImportFile]
@filename varchar(255), @rowCount int, @accountTypeId int
AS
BEGIN
	IF NOT EXISTS (select * from ProcessedImportFiles where Filename = @filename)

		insert into ProcessedImportFiles(Filename, [RowCount], ImportDate, Status, AccountTypeId)
		values(@filename, @rowCount, CONVERT (date, CURRENT_TIMESTAMP), 'Completed', @accountTypeId) 

	ELSE

		update ProcessedImportFiles
		set Filename = @filename,
			[RowCount] = @rowCount,  
			ImportDate = CONVERT (date, CURRENT_TIMESTAMP), 
			Status  ='Completed'
		where Filename = @filename

		
END