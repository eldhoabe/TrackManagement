using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackManagment.Model
{
    class Track
    {
        public List<Talk> Talks { get; set; }

        public MorningSession MorningSession { get; set; }
    }
}
