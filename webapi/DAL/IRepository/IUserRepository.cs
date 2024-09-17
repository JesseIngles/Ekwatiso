using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.IRepository
{
    public interface IUserRepository
    {
        Task<Dto_Resposta> AtualizarContaUsuario(int v, Dto_Usuario usuario);
        Task<Dto_Resposta> CriarContaUsuario(Dto_Usuario usuario);
        Task<Dto_Resposta> VerMinhaConta(int usuarioId);
        Task<Dto_Resposta> VerUsuarioPorId(int id);
    }
}