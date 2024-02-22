using Microsoft.Extensions.Options;
using Quartz;

namespace THubWorkerService.Jobs.Job_Configuration
{
    public class CurrentTimeBackGroundJobSetUp : IConfigureOptions<QuartzOptions>
    {
        IConfiguration _configuration;
        public CurrentTimeBackGroundJobSetUp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(QuartzOptions options)
        {
            int _time = Convert.ToInt32(_configuration["Job_Interval"]);
            var jobKey = JobKey.Create(nameof(CurrentTimeBackGroundJob));

            options.AddJob<CurrentTimeBackGroundJob>(jobBuilder => jobBuilder.WithIdentity(jobKey))
            .AddTrigger(trigger =>
            trigger
            .ForJob(jobKey)
            .WithSimpleSchedule(schedule =>
            schedule.WithIntervalInSeconds(_time).RepeatForever()));
        }
    }
}
