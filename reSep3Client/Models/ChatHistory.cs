namespace reSep3Client.Models
{
    public class ChatHistory
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }

    }
}
