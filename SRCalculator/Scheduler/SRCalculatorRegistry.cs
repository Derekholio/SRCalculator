using FluentScheduler;
using SRCalculator.Scheduler.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
