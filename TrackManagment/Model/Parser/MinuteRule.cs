using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model.Parser
{
    class MinuteRule : IParseRule
    {
        const string minSuffix = "min";

        public bool IsMatch(string ruleWord)
        {
            return ruleWord.EndsWith(minSuffix,StringComparison.OrdinalIgnoreCase);
        }

        public int ParseTime(string theWord)
        {
            var time =
                   Convert.ToInt32(theWord.Substring(0, theWord.IndexOf(minSuffix, StringComparison.OrdinalIgnoreCase)));

            return time;
        }
    }
}
