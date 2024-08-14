using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.IRepository
{
    public interface IGerenteRepository
    {
        Task<Dto_Resposta> AtualizarContaGerente(int v, Dto_Gerente gerente);
        Task<Dto_Resposta> CriarContaGerente(Dto_Gerente gerente);
    }
}
