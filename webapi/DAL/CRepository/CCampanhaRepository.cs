using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.IRepository;

namespace webapi.DAL.CRepository
{
    public class CCampanhaRepository : ICampanhaRepository
    {
        private readonly EkwatisoDbContext _dbContext;
        public CCampanhaRepository(EkwatisoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
