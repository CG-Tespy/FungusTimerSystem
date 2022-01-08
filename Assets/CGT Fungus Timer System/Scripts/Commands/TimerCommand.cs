using UnityEngine;
using TimeSpan = System.TimeSpan;

namespace Fungus.TimeSys
{
    public abstract class TimerCommand : Command
    {
        [SerializeField]
        protected IntegerData timerID = new IntegerData(0);

        protected virtual void Awake()
        {
            TimerManager.EnsureExists();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            FetchTimerToActOn();
            timeRecorded = timer.TimeRecorded;
        }

        protected virtual void FetchTimerToActOn()
        {
            TimerManager.EnsureTimerExistsWithID(timerID);
            timer = TimerManager.Timers[timerID];
        }

        protected TimerManager TimerManager
        {
            get { return TimerManager.Instance; }
        }

        protected Timer timer;
        protected TimeSpan timeRecorded;
        
        public override Color GetButtonColor()
        {
            return buttonColor;
        }

        protected static Color32 buttonColor = new Color32(200, 222, 255, 255);
    }
}