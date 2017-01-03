using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model.Parser
{
    class LighteningRule : IParseRule
    {
        const string lightiningSuffix = "lightning";

        public bool IsMatch(string ruleWord)
        {
            return ruleWord.EndsWith(lightiningSuffix, StringComparison.OrdinalIgnoreCase);
        }

        public int ParseTime(string theWord)
        {
            return 5;
        }
    }
}
