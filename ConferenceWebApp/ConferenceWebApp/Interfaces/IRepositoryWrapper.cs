using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceWebApp.Interfaces
{
    public interface IRepositoryWrapper
    {
        IConferenceRepository Conferences { get; }
        ISponsorRepository Sponsors { get; }
        void Save();
    }
}
