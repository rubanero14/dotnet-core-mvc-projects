namespace Menu.Models
{
    public class Document
    {
        // This section for Document
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // This section for connecting Document to an User
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
