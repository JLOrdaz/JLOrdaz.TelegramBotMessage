using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JLOrdaz.TelegramBotMessage
{
    public class TelegramMessage
    {

        HttpClient http;
        Uri apiUrl;

        public TelegramMessage(string tokenBot)
        {
            apiUrl = new Uri(uriString: $"https://api.telegram.org/bot{tokenBot}/sendMessage");
            http = new HttpClient();
            http.Timeout = new TimeSpan(0,0,10);
        }

        public async Task<string> SendMessage(string chatId, string message)
        {

            RequestMessage requestMessage = new RequestMessage()
            {
                chat_id = chatId,
                text = message + System.Environment.NewLine + DateTime.Now.ToString(),
                parse_mode = "markdown"
            };
            StringContent content = new StringContent(JsonSerializer.Serialize(requestMessage),Encoding.UTF8,"application/json");
            var response = await http.PostAsync(apiUrl.AbsoluteUri, content);
            
            return await response.Content.ReadAsStringAsync();
        }
    }

    class RequestMessage
    {
        public string chat_id { get; set; }
        public string text { get; set; }
        public string parse_mode { get; set; }

    }
}
