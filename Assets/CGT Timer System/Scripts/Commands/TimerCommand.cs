using UnityEngine;

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
    }
}