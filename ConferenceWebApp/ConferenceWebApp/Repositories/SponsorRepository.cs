using ConferenceWebApp.Data;
using ConferenceWebApp.Interfaces;
using ConferenceWebLibrary.Models;

namespace ConferenceWebApp.Repositories
{
    public class SponsorRepository : Repository<Sponsor>, ISponsorRepository
    {
        public SponsorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }

}
