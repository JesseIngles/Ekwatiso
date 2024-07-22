using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.IRepository
{
    public interface IPaisRepository
    {
        Task<Dto_Resposta> ApagarPais(int id);
        Task<Dto_Resposta> AtualizarPais(int id, Dto_Pais pais);
        Task<Dto_Resposta> CadastrarPais(Dto_Pais pais);
        Task<Dto_Resposta> TodosPaises();
    }
}
