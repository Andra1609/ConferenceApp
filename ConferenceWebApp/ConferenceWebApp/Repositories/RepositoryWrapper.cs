using ConferenceWebApp.Data;
using ConferenceWebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceWebApp.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
        // create constructor to inject repo
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        IConferenceRepository _conferences;

        ISponsorRepository _sponsors;
        // private field above, but public method to do the assignments; implementation of get method
        public IConferenceRepository Conferences
        {
            get
            {
                if (_conferences == null)
                    _conferences = new ConferenceRepository(_repoContext);
                return _conferences;
            }
        }

        public ISponsorRepository Sponsors
        {
            get
            {
                if (_sponsors == null)
                    _sponsors = new SponsorRepository(_repoContext);
                return _sponsors;
            }
        }

        void IRepositoryWrapper.Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
