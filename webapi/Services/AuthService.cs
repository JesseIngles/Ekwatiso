using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using webapi.DAL.Database.Entities;

namespace webapi.Services 
{
  public class AuthService 
  {
    private static string _signatureKey = "Mr. English";
    public static async Task<string?> GenerateUserToken(TbUser? user)
    {
      string? resposta = string.Empty;
      if(user == null)
      {
        resposta = null;    
      }
      
      try
      {
        var key =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signatureKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var authToken = new JwtSecurityToken(
            issuer: "your_issuer",
            audience: "your_audience",
            claims: new List<Claim>{
      
            },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );  
      }catch(Exception ex)
      {
        throw new Exception("Detalhes", ex);
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
        var key =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signatureKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var authToken = new JwtSecurityToken(
            issuer: "your_issuer",
            audience: "your_audience",
            claims: new List<Claim>{
      
            },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        ); 
      }catch(Exception ex)
      {
        throw new Exception("Detalhes", ex);
      }
      return resposta;
    }
  }
}