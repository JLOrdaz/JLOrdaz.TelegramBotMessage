using System;
using System.Threading.Tasks;

namespace JLOrdaz.TelegramBotMessage
{
    public class Notificar
    {
        private readonly TelegramMessage notificar;
        private readonly string chatid;

        /// <summary>
        /// Initializes a new instance of the <see cref="Notificar"/> class.
        /// </summary>
        /// <param name="tokenTelegramBot">The token for the Telegram bot.</param>
        /// <param name="chatId">The chat ID to send messages to.</param>
        public Notificar(string tokenTelegramBot, string chatId)
        {
            notificar = new TelegramMessage(tokenTelegramBot);
            chatid = chatId;
        }

        /// <summary>
        /// Sends an informational message to the specified chat.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the Telegram API.</returns>
        public async Task<string> InfoMensaje(string message) => await notificar.SendMessage(chatid, $"ℹ {message}");

        /// <summary>
        /// Sends a warning message to the specified chat.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the Telegram API.</returns>
        public async Task<string> WarningMensaje(string message) => await notificar.SendMessage(chatid, $"⚠ {message}");

        /// <summary>
        /// Sends an error message to the specified chat.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the Telegram API.</returns>
        public async Task<string> ErrorMensaje(string message) => await notificar.SendMessage(chatid, $"❗ {message}");
    }


}