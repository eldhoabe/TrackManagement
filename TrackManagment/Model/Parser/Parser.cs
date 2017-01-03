using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model.Parser
{
    class Parser : IParser
    {
        readonly List<IParseRule> _rules;

        public Parser()
        {
            _rules = new List<IParseRule>();
            _rules.Add(new MinuteRule());
            _rules.Add(new LighteningRule());
        }

        public int ParseTime(string theWord)
        {
            var parseRule = _rules.FirstOrDefault(h => h.IsMatch(theWord));

            if (parseRule == null)
                throw new FormatException("The string format is not met, either in the rules section");
            else
                return parseRule.ParseTime(theWord);
        }
    }
}
