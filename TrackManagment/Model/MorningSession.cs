using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackManagment.Model
{
    class MorningSession
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public List<Event> MorningEvents { get; set; }


        public MorningSession()
        {
            StartTime = new TimeSpan(9, 0, 0);
            EndTime = new TimeSpan(12, 0, 0);
            MorningEvents = new List<Event>();
        }


        public List<Event> AllocateSession(List<Talk> talks)
        {
            foreach (Talk talk in talks)
            {

                MorningEvents.Add(new Event { Name = talk.Name, StartTime = StartTime, Duration = talk.Duration });

            }

            return null;

        }



        /// <summary>
        /// This indicate it have time remaining
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        private bool IsTimeReamining(int duration)
        {
            TimeSpan newTime = new TimeSpan(0, duration, 0);

            if (StartTime.Add(newTime).CompareTo(EndTime) < 0)
            {
                return true;
            }
            else
                return false;
        }
    }


   
}
