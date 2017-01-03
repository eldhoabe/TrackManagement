using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackManagment.Model
{
    public class MorningSession
    {
        const int minuts = 60;
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public List<Event> MorningEvents { get; set; }

        private int _maxDurationAvailableMints {get;set;}


        public MorningSession()
        {
            StartTime = new TimeSpan(9, 0, 0);
            EndTime = new TimeSpan(12, 0, 0);
            MorningEvents = new List<Event>();

            _maxDurationAvailableMints = (EndTime.Hours - StartTime.Hours) * minuts;
        }


        public List<Event> Shedule(List<Talk> talks)
        {
            foreach (Talk talk in talks)
            {
                if (IsTimeReamining(talk.Duration))
                {
                    MorningEvents.Add(new Event
                    {
                        Name = talk.Name,
                        StartTime = StartTime,
                        Duration = talk.Duration
                    });

                    UpdateRemainingTime(talk.Duration);
                }

            }

            return MorningEvents;

        }



        /// <summary>
        /// This indicate it have time remaining
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        private bool IsTimeReamining(int duration)
        {
            return _maxDurationAvailableMints > duration;

        }

        private void UpdateRemainingTime(int duration)
        {
            _maxDurationAvailableMints = _maxDurationAvailableMints - duration;
        }

    }

}
