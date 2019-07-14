
CREATE PROCEDURE [dbo].[spCompleteImportFile]
@fileId uniqueidentifier 
AS
BEGIN
		declare @status int = (select StatusId from Statues where Status='Completed'),
		@currentStatus varchar(255) = (select s.Status from ProcessedImportFiles pfs inner join Statues s on pfs.StatusId = s.StatusId where FileId=@fileId)

		if @currentStatus != 'Rollback'
			update ProcessedImportFiles set StatusId=@status
			where FileId=@fileId;
END