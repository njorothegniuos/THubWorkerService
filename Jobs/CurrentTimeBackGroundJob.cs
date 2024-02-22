using Quartz;

namespace THubWorkerService.Jobs
{
    [DisallowConcurrentExecution]
    public class CurrentTimeBackGroundJob : IJob
    {
        public CurrentTimeBackGroundJob()
        {
        }
        public async Task Execute(IJobExecutionContext context)
        {
            Serilog.Log.Information($"The current time is:{DateTime.UtcNow}");

            await Task.CompletedTask;
        }
    }
}
