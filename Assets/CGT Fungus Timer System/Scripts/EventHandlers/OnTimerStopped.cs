using System;
using Fungus;

namespace CGT.Fungus.TimerSys
{
    [EventHandlerInfo("Timer", "Timer Stopped", "Execute this block when the specified timer has stopped.")]
    public class OnTimerStopped : TimerEventHandler
    {
        protected override Action<Timer> TimerEvent
        {
            get { return Timer.OnAnyTimerStop; }
            set { Timer.OnAnyTimerStop = value; }
        }
    }
}