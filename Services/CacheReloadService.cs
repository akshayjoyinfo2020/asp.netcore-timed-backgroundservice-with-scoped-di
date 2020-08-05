using Cron.AspNetCore.BackgroundProcess.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cron.AspNetCore.BackgroundProcess.Services
{
    public class CacheReloadService : ICacheReloadService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CacheReloadService> _logger;
        public CacheReloadService(IConfiguration configuration, ILogger<CacheReloadService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public async Task ExecuteReloadCache(int i)
        {
            Debug.WriteLine($"Executing ({i}) on {DateTime.Now.ToString("dd-mm-yyyy hh:mm:ss")}");

            _logger.LogWarning("******************* STARTING Execution**********************");
            _logger.LogWarning($" Redis Cache {_configuration["RedisConn"].ToString()}");
            _logger.LogWarning($"Executing ({i}) on {DateTime.Now.ToString("dd-mm-yyyy hh:mm:ss")}");
            _logger.LogWarning("******************* DONE Execution**********************");

        }
    }
}
