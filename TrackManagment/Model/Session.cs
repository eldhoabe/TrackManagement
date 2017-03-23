using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model
{
    /// <summary>
    /// An abstract class which holds the common session properties
    /// </summary>
    public abstract class Session
    {
        protected const int mints = 60;
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public List<Event> Events { get; set; }

        protected int _maxDurationAvailableMints { get; set; }


        /// <summary>
        /// This indicate it have time remaining
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        protected bool IsTimeReamining(int duration)
        {
            return _maxDurationAvailableMints >= duration;

        }

        protected void UpdateRemainingTime(int duration)
        {
            _maxDurationAvailableMints = _maxDurationAvailableMints - duration;
        }


        protected TimeSpan GetEndTime(TimeSpan startTime, int duration)
        {
            return startTime.Add(new TimeSpan(0, duration, 0));
        }
    }
}
