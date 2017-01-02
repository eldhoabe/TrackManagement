using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackManagment.Model
{
    public interface IFileReader
    {
        IEnumerable<string> ReadLines();
    }
}
