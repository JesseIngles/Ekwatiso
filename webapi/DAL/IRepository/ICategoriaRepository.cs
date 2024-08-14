using webapi.DAL.Database.DatabaseContext;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.IRepository
{
    public interface ICategoriaRepository
    {
        Task<Dto_Resposta> AtualizarCategoria(long id, Dto_Categoria categoria);
        Task<Dto_Resposta> CriarCategoria(Dto_Categoria categoria);
        Task<Dto_Resposta> RemoverCategoria(long id);
        Task<Dto_Resposta> TodasCategorias();
    }
}
