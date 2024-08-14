using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.CRepository
{
    public class CGerenteRepository : IGerenteRepository
    {
        private readonly EkwatisoDbContext _dbContext;
        public CGerenteRepository(EkwatisoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dto_Resposta> AtualizarContaGerente(int v, Dto_Gerente gerente)
        {
            throw new NotImplementedException();
        }

        public async Task<Dto_Resposta> CriarContaGerente(Dto_Gerente gerente)
        {
            throw new NotImplementedException();
        }
    }
}
