using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace TestBackgroundService
{
    public class ServiceAgent : BackgroundService
    {
        private readonly ILogger<ServiceAgent> _log;
        private Executer _executer;

        public ServiceAgent(ILogger<ServiceAgent> logger)
        {
            _executer = Executer.Instance;
            _log = logger;
            //Log.Information("Servie Init...");
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _log.LogInformation("Servie Started");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _log.LogInformation("Servie Stoped");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogInformation("Starting Executer.");

            _executer.Start(_log);

            _log.LogInformation("Stop Wait Handle Released.");

            stoppingToken.WaitHandle.WaitOne();
        }
    }
}
