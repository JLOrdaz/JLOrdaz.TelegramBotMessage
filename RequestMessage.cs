using System.Text.Json.Serialization;

namespace JLOrdaz.TelegramBotMessage
{
    internal sealed class RequestMessage
    {
        [JsonPropertyName("chat_id")]
        public string ChatId { get; set; } = string.Empty;

        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        [JsonPropertyName("parse_mode")]
        public string? ParseMode { get; set; }
    }
}
