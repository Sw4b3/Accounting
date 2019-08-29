
CREATE PROCEDURE [dbo].[spSaveImportFile]
@filename varchar(255), @rowCount int, @accountTypeId int
AS
BEGIN
	declare @status int = (select StatusId from Statues where Status='In Review'),
	@currentStatus varchar(255) =  (select StatusId from Statues where Status='Completed')

	IF NOT EXISTS (select * from ProcessedImportFiles where Filename = @filename)

		insert into ProcessedImportFiles(Filename, [RowCount], ImportDate, StatusId, AccountTypeId)
		values(@filename, @rowCount, CONVERT (date, CURRENT_TIMESTAMP), @status, @accountTypeId) 

	ELSE

		update ProcessedImportFiles
		set Filename = @filename,
			[RowCount] = @rowCount,  
			ImportDate = CONVERT (date, CURRENT_TIMESTAMP), 
			StatusId  = @status
		where Filename = @filename 
		and  StatusId != @currentStatus

END