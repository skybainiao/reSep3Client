namespace reSep3Client.Models
{
    public class ChatMessage
    {
        public long Id { get; set; }
        public string UserMessage { get; set; }
        public string BotMessage { get; set; }
        public DateTime Timestamp { get; set; }
        public long UserId { get; set; }
    }

}
