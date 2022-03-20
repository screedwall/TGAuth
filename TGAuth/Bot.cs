using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Data.SqlClient;

namespace TGAuth
{
    public class Bot
    {
        static TelegramBotClient botClient = new TelegramBotClient("5234116391:AAGovcDR_hblMn-fPbVTk_u0rbnJorqztfM");
        public Bot()
        {
            Init();
        }
        async void Init() {

            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };
            botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            var me = await botClient.GetMeAsync();
        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message)
                return;

            if (update.Message!.Type != MessageType.Text)
                return;

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;

            SqlConnection db_conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=tgauth;Integrated Security=True");
            SqlCommand queryUser = new SqlCommand(String.Format("SELECT * FROM users WHERE chat_id='{0}'", chatId), db_conn);
            queryUser.Connection.Open();
            SqlDataReader reader = queryUser.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            queryUser.Connection.Close();

            if (count == 0) {
                //SqlCommand queryUpdateRegistration = new SqlCommand(String.Format("UPDATE users " +
                //                                                                  "SET username='{0}', password='{1}', chat_id={2}, registered={3} " +
                //                                                                  "WHERE id={4}", username, password, chatId, 1, id), db_conn);
                //queryUpdateRegistration.Connection.Open();
                //queryUpdateRegistration.ExecuteNonQuery();
                //queryUpdateRegistration.Connection.Close();

                await SendMessage(botClient, chatId, String.Format("Привет! Держи telegram id для регистрации: {0}", chatId));
            }
        }

        public static async Task SendMessage(ITelegramBotClient botClient, long chatId, string? messageText)
        {
            Telegram.Bot.Types.Message sentMessage = await botClient.SendTextMessageAsync(
                            chatId: chatId,
                            text: messageText);
        }

        public async void SendMsg(long chatId, string msg) {
            await SendMessage(botClient, chatId, msg);
        }

        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            return Task.CompletedTask;
        }
    }
}
