using webapi.DAL.Database.Entities;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.IRepository
{
    public interface IAutenticacaoRepository
    {
      Task<Dto_Resposta> FazerLogin(Dto_LoginCredentials credencias);
        Task<Dto_Resposta> RecuperarSenha(string telefone);
        Task<Dto_Resposta> TerminarSessão(string authToken);
    }
}