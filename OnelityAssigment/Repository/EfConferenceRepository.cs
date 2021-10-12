using OnelityAssigment.Models;

namespace OnelityAssigment.Repository
{
    public class EfConferenceRepository : EfRepository<Conference>, IConferenceRepository
    {
        public EfConferenceRepository(OnelityAssigmentDbContext dbContext) : base(dbContext) { }
    }
}
