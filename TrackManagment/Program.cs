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
        const string filePath = @"C:\a.txt";


        static void Main(string[] args)
        {
            IFileReader reader = new FileReader(filePath);
            IEnumerable<string> fileResult = reader.ReadLines();


            List<Talk> talks = new StringToModel().ConvertToTalks(fileResult);

            var ms = new MorningSession().Shedule(talks);

            int m = 0;
        }
    }
}
