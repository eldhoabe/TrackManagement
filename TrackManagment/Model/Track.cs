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
        }


        public void DisplayEvents(List<Talk> talks)
        {

            var morning = new MorningSession();
            List<Event> morningEvents = morning.Shedule(talks);
            var remanining = morning.UnsheduledEvents(talks);

            var evening = new EveningSession();
            var eveningevents = evening.Shedule(remanining);


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
