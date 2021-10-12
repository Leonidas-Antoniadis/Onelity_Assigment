using Microsoft.EntityFrameworkCore;
using OnelityAssigment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnelityAssigment.Repository
{
    public class EfParticipantRepository : EfRepository<Participant>, IParticipantRepository
    {
        public EfParticipantRepository(OnelityAssigmentDbContext dbContext) : base(dbContext) { }

        public Task<List<Participant>> AllByConferenceId(int id)
        {
            return DbContext.Participant.Where(p => p.ConferenceId == id).ToListAsync();
        }
    }
}
