using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackManagment.Model
{
    public class MorningSession : Session
    {
        public MorningSession(TimeSpan startTime,TimeSpan endtime)
        {
            StartTime = startTime;
            EndTime = endtime;
            Events = new List<Event>();

            _maxDurationAvailableMints = (EndTime.Hours - StartTime.Hours) * mints;
        }


        public List<Event> Shedule(List<Talk> talks)
        {
            foreach (Talk talk in talks)
            {
                if (IsTimeReamining(talk.Duration))
                {
                    Events.Add(new Event
                    {
                        Name = talk.Name,
                        StartTime = talks.IndexOf(talk) == 0 ? StartTime : Events.Last().EndTime,
                        EndTime = Events.Any() ? GetEndTime(Events.Last().EndTime, talk.Duration) : GetEndTime(StartTime, talk.Duration),
                        Duration = talk.Duration
                    });

                    UpdateRemainingTime(talk.Duration);
                }
            }

            UnsheduledEvents(talks);

            Events.Add(new Event { Name = "Lunch", StartTime = EndTime, Duration = 60, EndTime = GetEndTime(Events.Last().EndTime, 60) });

            return Events;
        }

        public List<Talk> UnsheduledEvents(List<Talk> talks)
        {
            var fullist = talks;

            var sheduled = talks.Where(tk => Events.Any(sh => sh.Name == tk.Name)).ToList();


            var unshed = fullist.Except(sheduled).ToList();

            return unshed;
        }

    }

}
