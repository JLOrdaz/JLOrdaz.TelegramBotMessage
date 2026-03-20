using System;
using System.Threading;
using System.Threading.Tasks;

namespace JLOrdaz.TelegramBotMessage
{
    public sealed class TelegramNotifier : IDisposable
    {
        private readonly TelegramMessage telegramMessage;
        private readonly string chatId;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramNotifier"/> class.
        /// </summary>
        /// <param name="botToken">The token for the Telegram bot.</param>
        /// <param name="chatId">The chat ID to send messages to.</param>
        public TelegramNotifier(string botToken, string chatId)
        {
            if (string.IsNullOrWhiteSpace(chatId))
            {
                throw new ArgumentException("A chat id is required.", nameof(chatId));
            }

            telegramMessage = new TelegramMessage(botToken);
            this.chatId = chatId;
        }

        /// <summary>
        /// Sends a message to the specified chat.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the Telegram API.</returns>
        public Task<string> SendMessageAsync(string message, CancellationToken cancellationToken = default)
            => telegramMessage.SendMessage(chatId, message, cancellationToken);

        /// <summary>
        /// Sends an informational message to the specified chat.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the Telegram API.</returns>
        public Task<string> SendInfoMessageAsync(string message, CancellationToken cancellationToken = default)
            => SendMessageAsync($"ℹ {message}", cancellationToken);

        /// <summary>
        /// Sends a warning message to the specified chat.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the Telegram API.</returns>
        public Task<string> SendWarningMessageAsync(string message, CancellationToken cancellationToken = default)
            => SendMessageAsync($"⚠ {message}", cancellationToken);

        /// <summary>
        /// Sends an error message to the specified chat.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response from the Telegram API.</returns>
        public Task<string> SendErrorMessageAsync(string message, CancellationToken cancellationToken = default)
            => SendMessageAsync($"❗ {message}", cancellationToken);

        public void Dispose() => telegramMessage.Dispose();
    }


}