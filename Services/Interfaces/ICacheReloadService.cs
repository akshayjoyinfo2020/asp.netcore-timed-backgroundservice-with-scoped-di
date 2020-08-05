using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cron.AspNetCore.BackgroundProcess.Services.Interfaces
{
    public interface ICacheReloadService
    {
        Task ExecuteReloadCache(int i);
    }
}
