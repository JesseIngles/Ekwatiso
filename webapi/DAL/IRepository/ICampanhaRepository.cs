using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.IRepository
{
    public interface ICampanhaRepository
    {
        Task<Dto_Resposta> ApagarCampanha(long id);
        Task<Dto_Resposta> AtualizarCampanha(long id, Dto_Campanha campanha);
        Task<Dto_Resposta> CriarCampanha(Dto_Campanha campanha);
        Task<Dto_Resposta> TodasCampanhas();
        Task<Dto_Resposta> TodasCampanhasProvincia(long id);
    }
}
