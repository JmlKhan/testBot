using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using testbot.Model;

namespace testbot.Services
{
    public class ConfigureWebHook : IHostedService
    {
        private readonly ILogger<ConfigureWebHook> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly BotConfiguration _botConfig;

        public ConfigureWebHook(ILogger<ConfigureWebHook> logger,
           IServiceProvider serviceProvider,  
           IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _botConfig = configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            
            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

            var webhookAddress = $@"{_botConfig.HostAddress}/bot/{_botConfig.Token}";

            _logger.LogInformation("Setting webhook");

            await botClient.SendTextMessageAsync(
                chatId: 1678231744,
                text: "Bot ishga tushmoqda"
                );

            await botClient.SetWebhookAsync(
                url: webhookAddress,
                allowedUpdates: Array.Empty<UpdateType>(),
                cancellationToken: cancellationToken);
                
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

            _logger.LogInformation("Webhook removing");

            await botClient.SendTextMessageAsync(
                chatId: 1678231744,
                text: "Bot uxlamoqda"
                );
        }
    }
}
