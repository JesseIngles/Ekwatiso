using Microsoft.AspNetCore.Mvc;

namespace webapi.DTO.Outbound
{
  public class Dto_Resposta
  {
    public string mensagem {get;set;}
    public object? resposta {get;set;}
    public bool sucess {get;set;}
  }
}