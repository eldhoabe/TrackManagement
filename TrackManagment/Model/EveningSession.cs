using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model
{
    class EveningSession
    {
        const int minuts = 60;

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public List<Event> EveningEvents { get; set; }

        private int _maxDurationAvailableMints { get; set; }

        bool _isnetworkingEventAdded { get; set; }


        public EveningSession()
        {
            StartTime = new TimeSpan(1, 0, 0);
            EndTime = new TimeSpan(5, 0, 0);
            EveningEvents = new List<Event>();
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
                        EveningEvents.Add(new Event
                        {
                            Name = talk.Name,
                            StartTime = talks.IndexOf(talk) == 0 ? StartTime : EveningEvents.Last().EndTime,
                            EndTime = EveningEvents.Any() ? GetEndTime(EveningEvents.Last().EndTime, talk.Duration) : GetEndTime(StartTime, talk.Duration),
                            Duration = talk.Duration
                        });

                    UpdateRemainingTime(talk.Duration);
                }
            }

            return EveningEvents;
        }

        private void AddNetworkingEvent(List<Talk> talks, Talk talk)
        {
            EveningEvents.Add(new Event
            {
                Name = "Networking Event",
                StartTime = talks.IndexOf(talk) == 0 ? StartTime : EveningEvents.Last().EndTime,
                EndTime = EveningEvents.Any() ? GetEndTime(EveningEvents.Last().EndTime, talk.Duration) : GetEndTime(StartTime, talk.Duration),
                Duration = talk.Duration
            });


            _isnetworkingEventAdded = true;
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


        private TimeSpan GetEndTime(TimeSpan startTime, int duration)
        {
            return startTime.Add(new TimeSpan(0, duration, 0));
        }

        private bool IsTimeForNetworkingEvent(int duration)
        {
            if (!EveningEvents.Any() || _isnetworkingEventAdded) return false;

            if (EveningEvents.Last().EndTime.Add(new TimeSpan(0, duration, 0)) > new TimeSpan(5, 0, 0))
            {
                return true;
            }
            return false;
        }

    }
}
