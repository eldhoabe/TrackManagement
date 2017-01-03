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

            List<Event> morningEvents = new MorningSession()
                                            .Shedule(talks);


            Console.WriteLine("***Morning Events***");
            foreach (var evnt in morningEvents)
            {
               
                Console.WriteLine(evnt.Name);
            }

            Console.ReadLine();
        }
    }
}
