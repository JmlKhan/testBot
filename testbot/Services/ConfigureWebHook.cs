using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using testbot.Model;

namespace testbot.Services
{
    public class ConfigureWebHook : IHostedService
    {
        private readonly ILogger<ConfigureWebHook> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly object _botConfig;

        public ConfigureWebHook(ILogger<ConfigureWebHook> logger,
           IServiceProvider serviceProvider,  
           IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _botConfig = configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
