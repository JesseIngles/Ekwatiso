using Microsoft.EntityFrameworkCore;
using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.Database.Entities;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.CRepository
{
  public class CAutenticacaoRepository : IAutenticacaoRepository
  {
    private readonly EkwatisoDbContext _dbContext;
    public CAutenticacaoRepository(EkwatisoDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    private async Task<string?> GenerateUserToken(TbUser? user)
    {
      string? resposta = string.Empty;
      if(user == null)
      {
        resposta = null;
      }
      
      try
      {

      }catch(Exception ex)
      {
        throw new Exception("Flah«", ex);
      }
      return resposta;
    }

    public async Task<Dto_Resposta> FazerLogin(Dto_LoginCredentials credencias)
    {
      Dto_Resposta resposta = new Dto_Resposta();
      if(credencias == null)
      {
        resposta.mensagem = "Falha: Objecto de credencias nulo";
        resposta.sucess = false;
      }

      try
      {
        TbUser? usuarioExistente = await _dbContext.TbUsers.FirstAsync(x => x.NomeCompleto == credencias.Username && x.Senha == credencias.Password);
        TbGerente? gerenteExistente = await _dbContext.TbGerentes.FirstAsync(x => x.NomeCompleto == credencias.Username && x.Senha == credencias.Password);
        if(usuarioExistente == null && gerenteExistente != null)
        {

          resposta.sucess = true;
        }else if (usuarioExistente != null && gerenteExistente == null)
        {
          resposta.sucess = true;
        }else
        {
          resposta.sucess = false;
        }
      }catch(Exception ex)
      {
        resposta.mensagem = $"Falha: Ocorreu um erro durante a validação das credencias. Detalhes: {ex.Message}";
        resposta.sucess = false;
      }
      return resposta;
    }
  }
}