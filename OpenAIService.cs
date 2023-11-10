namespace CodeAssistant.Web.Services
{
    public class OpenAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openAiKey;

        public OpenAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _openAiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? throw new InvalidOperationException("API Key not found in environment variables.");
        }

        public async Task<string> GetResponseAsync(string prompt, AppDbContext context)
        {
            string question = $"Refactor this code: {prompt}. IMPORTANT NOTE: You should ONLY return the refactored code, NOTHING ELSE";
            var data = new
            {
                model = "gpt-3.5-turbo",
                messages = new[] { new { role = "system", content = question } },
                temperature = 0.0,
            };

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _openAiKey);

            var response = await _httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", data);

            if (response.IsSuccessStatusCode)
            {
                var openAiResponse = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                string chatResponse = openAiResponse?.Choices[0]?.Message?.Content;

                var conversation = new Conversation
                {
                    UserQuestion = prompt,
                    ChatbotResponse = chatResponse
                };

                context.Conversations.Add(conversation);
                await context.SaveChangesAsync();

                return chatResponse;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return $"Error: {response.StatusCode} - {errorContent}";
            }
        }
    }

    public class OpenAIResponse
    {
        public Choice[] Choices { get; set; }
    }

    public class Choice
    {
        public Message Message { get; set; }
    }

    public class Message
    {
        public string Content { get; set; }
    }
}