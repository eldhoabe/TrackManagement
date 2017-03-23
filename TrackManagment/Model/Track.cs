using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackManagment.Model
{
    public class Track
    {
        public string TrackName { get; set; }
        public MorningSession MorningSession { get; set; }

        public EveningSession EveningSession { get; set; }

        public Track(string trackName)
        {
            TrackName = trackName;
            MorningSession = new MorningSession(new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0));
            EveningSession = new EveningSession(new TimeSpan(1, 0, 0), new TimeSpan(5, 0, 0));
        }


        public void DisplayEvents(List<Talk> talks)
        {
            List<Event> morningEvents = MorningSession.Shedule(talks);
            var remanining = MorningSession.UnsheduledEvents(talks);

            var eveningevents = EveningSession.Shedule(remanining);

            morningEvents.AddRange(eveningevents);
         
            Print(morningEvents);
        }

        void Print(List<Event> events)
        {
            Console.WriteLine(TrackName);
            foreach (var evnt in events)
            {
                Console.WriteLine(evnt.StartTime + " : " + evnt.Name);
                Console.WriteLine();
            }
        }
    }
}
