using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.IRepository;

namespace webapi.DAL.CRepository
{
    public class CDoacaoRepository : IDoacaoRepository
    {
        private readonly EkwatisoDbContext _dbContext;
        public CDoacaoRepository(EkwatisoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
