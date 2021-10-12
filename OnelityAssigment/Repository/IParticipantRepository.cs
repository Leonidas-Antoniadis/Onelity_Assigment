using OnelityAssigment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnelityAssigment.Repository
{
    public interface IParticipantRepository : IRepository<Participant>
    {
        Task<List<Participant>> AllByConferenceId(int id);
    }
}
