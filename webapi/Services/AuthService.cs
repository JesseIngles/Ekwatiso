using webapi.DAL.Database.Entities;

namespace webapi.Services 
{
  public class AuthService 
  {
    public static async Task<string?> GenerateUserToken(TbUser? user)
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

    public static async Task<string?> GenerateGerenteToken(TbGerente? gerente)
    {
      string? resposta = string.Empty;
      if(gerente == null)
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
  }
}