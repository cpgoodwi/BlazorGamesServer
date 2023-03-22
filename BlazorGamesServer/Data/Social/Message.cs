namespace BlazorGamesServer.Data.Social
{
    public class Message
    {
        public User Sender { get; set; }
        public string Content { get; set; }

        public Message(User sender, string content)
        {
            Sender = sender;
            Content = content;
        }

        public override string ToString()
        {
            return $"{Sender.Name} ({Sender.Type}): {Content}";
        }
    }
}
