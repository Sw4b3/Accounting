
create PROCEDURE [dbo].[spDeleteImportFile]
@fileId uniqueIdentifier  
AS
BEGIN	
	declare @currentStatus varchar(255) = (select s.Status from ProcessedImportFiles pfs inner join Statues s on pfs.StatusId = s.StatusId where FileId=@fileId)

	if @currentStatus = 'Rollback'
		begin
				delete ProcessedImportFiles
				where  FileId= @fileId 
		end
END