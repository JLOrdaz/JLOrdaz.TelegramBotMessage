using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JLOrdaz.TelegramBotMessage
{
    internal sealed class TelegramMessage : IDisposable
    {
        private const int DefaultTimeoutSeconds = 10;
        private static readonly char[] MarkdownV2Escapes = ['_', '*', '[', ']', '(', ')', '~', '`', '>', '#', '+', '-', '=', '|', '{', '}', '.', '!'];
        private readonly HttpClient http;
        private readonly Uri apiUrl;

        internal TelegramMessage(string tokenBot)
            : this(tokenBot, new HttpClient())
        {
        }

        internal TelegramMessage(string tokenBot, HttpClient httpClient)
        {
            if (string.IsNullOrWhiteSpace(tokenBot))
            {
                throw new ArgumentException("A Telegram bot token is required.", nameof(tokenBot));
            }

            apiUrl = new Uri($"https://api.telegram.org/bot{tokenBot}/sendMessage");
            http = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            http.Timeout = TimeSpan.FromSeconds(DefaultTimeoutSeconds);
        }

        internal async Task<string> SendMessage(string chatId, string message, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(chatId))
            {
                throw new ArgumentException("A chat id is required.", nameof(chatId));
            }

            string formattedMessage = EscapeMarkdownV2($"{message}{Environment.NewLine}{DateTime.Now:yyyy-MM-dd HH:mm:ss}");

            RequestMessage requestMessage = new RequestMessage()
            {
                ChatId = chatId,
                Text = formattedMessage,
                ParseMode = "MarkdownV2"
            };

            using StringContent content = new StringContent(JsonSerializer.Serialize(requestMessage), Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await http.PostAsync(apiUrl, content, cancellationToken).ConfigureAwait(false);

            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Telegram API returned {(int)response.StatusCode} ({response.ReasonPhrase}). Response: {responseBody}");
            }
            
            return responseBody;
        }

        public void Dispose()
        {
            http.Dispose();
        }

        private static string EscapeMarkdownV2(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder(value.Length * 2);

            foreach (char character in value)
            {
                if (Array.IndexOf(MarkdownV2Escapes, character) >= 0)
                {
                    builder.Append('\\');
                }

                builder.Append(character);
            }

            return builder.ToString();
        }
    }
}
