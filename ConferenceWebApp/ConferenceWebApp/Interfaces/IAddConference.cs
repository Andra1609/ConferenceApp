using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceWebApp.Interfaces
{
    public interface IAddConference
    {
        public string Name { get; set; }
        public string Place { get; set; }
    }
}
