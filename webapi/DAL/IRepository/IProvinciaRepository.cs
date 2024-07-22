using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.IRepository
{
    public interface IProvinciaRepository
    {
        Task<Dto_Resposta> ApagarProvincia(int id);
        Task<Dto_Resposta> AtualizarProvincia(int id, Dto_Provincia provincia);
        Task<Dto_Resposta> CadastrarProvincia(Dto_Provincia provincia);
        Task<Dto_Resposta> TodosProvincias(int id);
    }
}
