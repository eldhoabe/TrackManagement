using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model.Parser
{
    public interface IParseRule : IParser
    {
        bool IsMatch(string ruleWord);

    }
}
