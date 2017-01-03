using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model
{
    class StringToModel
    {
        List<Talk> Talks { get; set; }

        readonly IParser parser;
        public StringToModel()
        {
            Talks = new List<Talk>();

            parser = new TrackManagment.Model.Parser.Parser();
        }

        public List<Talk> ConvertToTalks(IEnumerable<string> lines)
        {
            foreach (string line in lines)
            {
                Talks.Add(new Talk
                {
                    Duration = ParseTime(line.Split(' ').Last()),
                    Name = line,
                });
            }

            return Talks;
        }


        /// <summary>
        /// Parse time to integer
        /// </summary>
        /// <param name="theWord"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        internal int ParseTime(string theWord)
        {
            if (string.IsNullOrEmpty(theWord))
                throw new ArgumentNullException("theWord");

            return parser.ParseTime(theWord);
        }
    }
}
