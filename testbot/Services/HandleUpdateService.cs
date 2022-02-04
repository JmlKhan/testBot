using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace testbot.Services
{
    public class HandleUpdateService
    {
        private readonly ILogger<HandleUpdateService> _logger;
        private readonly ITelegramBotClient _botClient;

        public HandleUpdateService(ILogger<HandleUpdateService> logger, ITelegramBotClient botCLient)
        {
            _logger = logger;
            _botClient = botCLient;
        }
    }
}
