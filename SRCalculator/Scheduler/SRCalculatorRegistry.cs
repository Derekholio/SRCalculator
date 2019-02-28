using FluentScheduler;
using SRCalculator.Scheduler.Jobs;

namespace SRCalculator.Scheduler
{
    public class SRCalculatorRegistry : Registry
    {
        public SRCalculatorRegistry()
        {
            Schedule<SRUpdater>().ToRunNow().AndEvery(12).Hours();
        }
    }
}
