using Cron.AspNetCore.BackgroundProcess.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cron.AspNetCore.BackgroundProcess.Jobs
{
    public class JobRunner : IHostedService, IDisposable
    {

        private readonly IServiceScope _scope;

        private readonly ICacheReloadService _myAwesomeService;
        private readonly ILogger<JobRunner> _logger;

        private Timer _timer;

        private int _executedCount = 0;


        public JobRunner(IServiceScopeFactory scopeFactory, ILogger<JobRunner> logger)
        {
            this._scope = scopeFactory.CreateScope();

            this._myAwesomeService = this._scope.ServiceProvider.GetService<ICacheReloadService>();
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Insider StartAsync");
            this._timer = new Timer(async (state) => await this.RunJobAsync(state), null, TimeSpan.FromMinutes(0), TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
           
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Insider StopAsync");
            this._timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this._timer?.Dispose();
            this._scope?.Dispose();
        }

        private async Task RunJobAsync(object state)
        {
            await this._myAwesomeService.ExecuteReloadCache(this._executedCount < int.MaxValue ? this._executedCount++ : this._executedCount = 1);
        }
    }
}
