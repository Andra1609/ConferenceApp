using ConferenceWebApp.Data;
using ConferenceWebApp.Interfaces;
using ConferenceWebLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceWebApp.Repositories
{
    public class ConferenceRepository : Repository<Conference>, IConferenceRepository 
    {
        public ConferenceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }

}
