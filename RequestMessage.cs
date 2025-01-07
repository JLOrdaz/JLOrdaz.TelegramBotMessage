using System;
using System.Collections.Generic;
using System.Text;

namespace JLOrdaz.TelegramBotMessage
{
    internal class RequestMessage
    {
        public string? chat_id { get; set; }
        public string? text { get; set; }
        public string? parse_mode { get; set; }
    }
}
