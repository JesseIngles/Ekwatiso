using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.IRepository
{
    public interface IUserRepository
    {
        Task<Dto_Resposta> AtualizarContaUsuario(int v, Dto_UpdateUsuario usuario);
        Task<Dto_Resposta> CriarContaUsuario(Dto_Usuario usuario);
    }
}