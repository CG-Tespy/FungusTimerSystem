using System;
using Fungus;

namespace CGT.Fungus.TimerSys
{
    [EventHandlerInfo("Timer", "Timer Resetted", "Execute this block when any of the appropriate timers reset")]
    public class OnTimerResetted : TimerEventHandler
    {
        protected override Action<Timer> TimerEvent
        {
            get { return Timer.OnAnyTimerReset; }
            set { Timer.OnAnyTimerReset = value; }
        }
    }
}
