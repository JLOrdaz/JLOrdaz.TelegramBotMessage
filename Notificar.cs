using System;
using System.Threading.Tasks;

namespace JLOrdaz.TelegramBotMessage
{
    public class Notificar
    {
        private readonly TelegramMessage notificar;
        private readonly string chatid;

        public Notificar(string tokenTelegramBot, string chatId)
        {
            notificar = new TelegramMessage(tokenTelegramBot);
            chatid = chatId;
        }

        public async Task<string> InfoMensaje(string message) => await notificar.SendMessage(chatid, $"ℹ {message}");
        public async Task<string> WarningMensaje(string message) => await notificar.SendMessage(chatid, $"⚠ {message}");
        public async Task<string> ErrorMensaje(string message) => await notificar.SendMessage(chatid, $"❗ {message}");

    }


}