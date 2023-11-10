public class Conversation
{
    public int Id { get; set; }
    public string TheQuestion { get; set; } //The Question Asked by the User
    public string ChatBotAnswer { get; set; } //The Anwer from the chat bot
    public DateTime TimeTaken { get; set; } = DateTime.UtcNow;
}
