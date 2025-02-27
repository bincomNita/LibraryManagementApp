namespace LibraryManagementApp.Model
{
    public class Books
    {
        public string Id { get; set; }=Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int CopiesAvailable { get; set; }
        public int BorrowCount { get; set; }
    }
}
