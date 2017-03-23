using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model
{
    public class EveningSession : Session
    {
        bool _isnetworkingEventAdded { get; set; }


        public EveningSession(TimeSpan startTime, TimeSpan endtime)
        {
            StartTime = startTime;
            EndTime = endtime;
            Events = new List<Event>();
            
            //1-2 = 60 + 60 + 60 +60 
            _maxDurationAvailableMints = 300;//(EndTime.Hours - StartTime.Hours) * minuts;
        }

        public List<Event> Shedule(List<Talk> talks)
        {
            foreach (Talk talk in talks)
            {
                if (IsTimeReamining(talk.Duration))
                {
                    if (IsTimeForNetworkingEvent(talk.Duration))
                    {
                        AddNetworkingEvent(talks, talk);
                    }
                    else
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

            return Events;
        }

        private void AddNetworkingEvent(List<Talk> talks, Talk talk)
        {
            Events.Add(new Event
            {
                Name = "Networking Event",
                StartTime = talks.IndexOf(talk) == 0 ? StartTime : Events.Last().EndTime,
                EndTime = Events.Any() ? GetEndTime(Events.Last().EndTime, talk.Duration) : GetEndTime(StartTime, talk.Duration),
                Duration = talk.Duration
            });


            _isnetworkingEventAdded = true;
        }

        private bool IsTimeForNetworkingEvent(int duration)
        {
            if (!Events.Any() || _isnetworkingEventAdded) return false;

            if (Events.Last().EndTime.Add(new TimeSpan(0, duration, 0)) > new TimeSpan(5, 0, 0))
            {
                return true;
            }
            return false;
        }

    }
}
