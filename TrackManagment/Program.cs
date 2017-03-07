using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackManagment.Model;

namespace TrackManagment
{
    class Program
    {
        const string filePath = "Input.txt";


        static void Main(string[] args)
        {

            IFileReader reader = new FileReader(filePath);
            IEnumerable<string> fileResult = reader.ReadLines();


            List<Talk> talks = new StringToModel().ConvertToTalks(fileResult);

            var morning = new MorningSession();
            List<Event> morningEvents = morning.Shedule(talks);
            var remanining = morning.UnsheduledEvents(talks);



            Console.WriteLine("***Morning Events***");
            foreach (var evnt in morningEvents)
            {

                Console.WriteLine(evnt.StartTime + " : " + evnt.Name);
                Console.WriteLine();
            }



            var evening = new EveningSession();
            var eveningevents = evening.Shedule(remanining);


            Console.WriteLine("***Morning Events***");
            foreach (var evnt in eveningevents)
            {

                Console.WriteLine(evnt.StartTime + " : " + evnt.Name);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
