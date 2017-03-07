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

        private int _maxDurationAvailableMints { get; set; }


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
                        StartTime = talks.IndexOf(talk) == 0 ? StartTime : MorningEvents.Last().EndTime,
                        EndTime = MorningEvents.Any() ? GetEndTime(MorningEvents.Last().EndTime, talk.Duration) : GetEndTime(StartTime, talk.Duration),
                        Duration = talk.Duration
                    });

                    UpdateRemainingTime(talk.Duration);
                }
            }

            UnsheduledEvents(talks);

            MorningEvents.Add(new Event { Name = "Lunch", StartTime = EndTime, Duration = 60, EndTime = GetEndTime(MorningEvents.Last().EndTime, 60) });

            return MorningEvents;
        }

        public List<Talk> UnsheduledEvents(List<Talk> talks)
        {
            var fullist = talks;

            var sheduled = talks.Where(tk => MorningEvents.Any(sh => sh.Name == tk.Name)).ToList();


            var unshed = fullist.Except(sheduled).ToList();

            return unshed;
        }



        /// <summary>
        /// This indicate it have time remaining
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        private bool IsTimeReamining(int duration)
        {
            return _maxDurationAvailableMints >= duration;

        }

        private void UpdateRemainingTime(int duration)
        {
            _maxDurationAvailableMints = _maxDurationAvailableMints - duration;
        }


        private TimeSpan GetEndTime(TimeSpan startTime, int duration)
        {
            var s = startTime.Add(new TimeSpan(0, duration, 0));

            return s;
        }

    }

}
