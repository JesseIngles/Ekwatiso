using Microsoft.EntityFrameworkCore;
using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.Database.Entities;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;
using webapi.Services;

namespace webapi.DAL.CRepository
{
  public class CAutenticacaoRepository : IAutenticacaoRepository
  {
    private readonly EkwatisoDbContext _dbContext;
    public CAutenticacaoRepository(EkwatisoDbContext dbContext, AuthService authService)
    {
      _dbContext = dbContext;
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
          resposta.resposta = await AuthService.GenerateGerenteToken(gerenteExistente);
          resposta.mensagem = "Sucesso: Gerente logado com sucesso";
          resposta.sucess = true;
        }else if (usuarioExistente != null && gerenteExistente == null)
        {
          resposta.resposta = await AuthService.GenerateUserToken(usuarioExistente);
          resposta.mensagem = "Sucesso: Usuário logado com sucesso";
          resposta.sucess = true;
        }else
        {
          resposta.mensagem = "Falha: Este usuário não existe";
          resposta.sucess = false;
        }
      }catch(Exception ex)
      {
        resposta.mensagem = $"Falha: Ocorreu um erro durante a validação das credencias. Detalhes: {ex.Message}";
        resposta.sucess = false;
      }
      return resposta;  
    }

        public async Task<Dto_Resposta> RecuperarSenha(string telefone)
        {
          Dto_Resposta resposta = new Dto_Resposta();
          if(telefone == null)
          {
            resposta.mensagem = "Falha: Objecto de credencias nulo";
            resposta.sucess = false;
          }

          try
          {
            TbUser? usuarioExistente = await _dbContext.TbUsers.FirstAsync(x => x.Telefone == telefone );
            TbGerente? gerenteExistente = await _dbContext.TbGerentes.FirstAsync(x => x.Telefone == telefone );
            if(usuarioExistente == null && gerenteExistente != null)
            {
              resposta.resposta = await AuthService.GenerateGerenteToken(gerenteExistente);
              resposta.mensagem = "Sucesso: Gerente logado com sucesso";
              resposta.sucess = true;
            }else if (usuarioExistente != null && gerenteExistente == null)
            {
              resposta.resposta = await AuthService.GenerateUserToken(usuarioExistente);
              resposta.mensagem = "Sucesso: Usuário logado com sucesso";
              resposta.sucess = true;
            }else
            {
              resposta.mensagem = "Falha: Este usuário não existe";
              resposta.sucess = false;
            }
          }catch(Exception ex)
          {
            resposta.mensagem = $"Falha: Ocorreu um erro durante a validação das credencias. Detalhes: {ex.Message}";
            resposta.sucess = false;
          }
          return resposta;
        }

        public async Task<Dto_Resposta> TerminarSessão(string authToken)
        {
          Dto_Resposta resposta = new Dto_Resposta();
          try
          {

          }catch(Exception ex)
          {
            resposta.mensagem = $"Falha: Ocorreu um erro durante esta operação. Detalhes: {ex.Message}";
          }
          return resposta;
        }
    }
}