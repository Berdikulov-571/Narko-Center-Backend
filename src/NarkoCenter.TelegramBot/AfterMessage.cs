using Telegram.Bot;

namespace NarkoCenter.TelegramBot
{
    public class AfterMessage
    {
        public ITelegramBotClient botClient;

        public async Task Added(object data)
        {
            botClient = new TelegramBotClient("6530285040:AAFOZe4HLj89L-yHVkyJLKrtqO9H2PSpxx4");

            botClient.StartReceiving();

            await botClient.SendTextMessageAsync("2017110018", $"{data} qo'shildi");
        }

        public async Task Updated(object data)
        {
            botClient = new TelegramBotClient("6530285040:AAFOZe4HLj89L-yHVkyJLKrtqO9H2PSpxx4");

            botClient.StartReceiving();

            await botClient.SendTextMessageAsync("2017110018", $"{data} yangilandi");
        }

        public async Task Deleted(object data)
        {
            botClient = new TelegramBotClient("6530285040:AAFOZe4HLj89L-yHVkyJLKrtqO9H2PSpxx4");

            botClient.StartReceiving();

            await botClient.SendTextMessageAsync("2017110018", $"{data} o'chirildi");
        }
    }
}