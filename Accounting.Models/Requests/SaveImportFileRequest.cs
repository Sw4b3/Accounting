namespace Accounting.Models.Requests
{
    public class SaveImportFileRequest
    {
        public string Filename { get; set; }
        public int RowCount { get; set; }
        public int AccountTypeId { get; set; }
    }
}
