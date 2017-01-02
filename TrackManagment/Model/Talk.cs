using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackManagment.Model
{
    public class Talk
    {
        public string Name { get; set; }

        public int Duration { get; set; }


        public override string ToString()
        {
            return Name + Duration.ToString();
        }

    }
}
