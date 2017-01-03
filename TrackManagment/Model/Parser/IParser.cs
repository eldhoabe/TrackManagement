using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagment.Model
{
    public interface IParser
    {
        int ParseTime(string theWord);
    }
}
