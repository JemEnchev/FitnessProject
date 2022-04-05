namespace FitnessProject.Infrastructure.Data.Repositories
{
    using FitnessProject.Infrastructure.Data.Common;

    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}
