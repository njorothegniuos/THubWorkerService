using Quartz;
using THubWorkerService.Jobs.Job_Configuration;

namespace THubWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();
            builder.Services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();

            });

            builder.Services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });

            builder.Services.ConfigureOptions<CurrentTimeBackGroundJobSetUp>();
            var host = builder.Build();
            host.Run();
        }
    }
}