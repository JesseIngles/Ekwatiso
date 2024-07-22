using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.IRepository;

namespace webapi.DAL.CRepository
{
    public class CGerenteRepository : IGerenteRepository
    {
        private readonly EkwatisoDbContext _dbContext;
        public CGerenteRepository(EkwatisoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
