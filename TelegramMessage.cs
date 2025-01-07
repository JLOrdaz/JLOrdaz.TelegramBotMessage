using System.Text;
using System.Text.Json;

namespace JLOrdaz.TelegramBotMessage
{
    internal class TelegramMessage
    {
        HttpClient http;
        Uri apiUrl;

        internal TelegramMessage(string tokenBot)
        {
            apiUrl = new Uri(uriString: $"https://api.telegram.org/bot{tokenBot}/sendMessage");
            http = new HttpClient();
            http.Timeout = new TimeSpan(0,0,10);
        }

        internal async Task<string> SendMessage(string chatId, string message)
        {
            message = message.Replace("_", "");

            RequestMessage requestMessage = new RequestMessage()
            {
                chat_id = chatId,
                text = message + System.Environment.NewLine + DateTime.Now.ToString(),
                parse_mode = "HTML"//"markdown"
            };
            StringContent content = new StringContent(JsonSerializer.Serialize(requestMessage),Encoding.UTF8,"application/json");
            var response = await http.PostAsync(apiUrl.AbsoluteUri, content);
            
            return await response.Content.ReadAsStringAsync();
        }
    }
}
