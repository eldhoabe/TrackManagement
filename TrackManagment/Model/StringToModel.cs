using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model
{
    class StringToModel
    {
        private List<Talk> Talks { get; set; }

        public StringToModel()
        {
            Talks = new List<Talk>();
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
        /// <exception cref="FormatException"></exception>
        /// <returns></returns>
        internal int ParseTime(string theWord)
        {
            if (string.IsNullOrEmpty(theWord))
                throw new ArgumentNullException("theWord");

            const string minSuffix = "min";
            const string lightiningSuffix = "lightning";

            if (theWord.EndsWith(minSuffix, StringComparison.OrdinalIgnoreCase))
            {
                var time =
                    Convert.ToInt32(theWord.Substring(0, theWord.IndexOf(minSuffix, StringComparison.OrdinalIgnoreCase)));

                return time;
            }
            if (theWord.EndsWith(lightiningSuffix, StringComparison.OrdinalIgnoreCase))
            {
                return 5;
            }


            throw new FormatException("The string format is not met, either " + minSuffix + " or " + lightiningSuffix +
                                      " is supported");
        }
    }
}
