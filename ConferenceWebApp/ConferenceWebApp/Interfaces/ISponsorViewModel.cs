using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceWebApp.Interfaces
{
    public interface ISponsorViewModel
    {
        public ISponsor Sponsor { get; set; }
        //public IConference Conference { get; set; }
    }
}
