using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceWebApp.Interfaces
{
    public interface IConferenceViewModel
    {
        public IConference Conference { get; set; }
        public IList<IConference> Sponsors { get; set; }
    }
}
