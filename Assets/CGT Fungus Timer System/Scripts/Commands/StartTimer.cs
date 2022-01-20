﻿using Fungus;

namespace CGT.Fungus.TimerSys
{
    [CommandInfo("Timer", "Start Timer", "Starts the timer with the provided ID. Does nothing if the timer is already running.")]
    public class StartTimer : TimerCommand
    {
        public override void OnEnter()
        {
            base.OnEnter();
            TimerManager.StartTimerWithID(timer.Value);
            Continue();
        }
    }
}