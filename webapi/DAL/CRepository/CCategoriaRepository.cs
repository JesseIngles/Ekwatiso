using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.IRepository;

namespace webapi.DAL.CRepository
{
    public class CCategoriaRepository : ICategoriaRepository
    {
        private readonly EkwatisoDbContext _dbContext;
        public CCategoriaRepository(EkwatisoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
