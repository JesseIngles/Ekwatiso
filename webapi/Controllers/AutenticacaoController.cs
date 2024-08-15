using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.Controllers
{
  [Authorize]
  [Controller]
  [Route("api/v1/[controller]")]
  public class AutenticacaoController : Controller
  {
    private readonly IAutenticacaoRepository _autenticacaoRepository;
    public AutenticacaoController(IAutenticacaoRepository autenticacaoRepository)
    {
      _autenticacaoRepository = autenticacaoRepository;
    }

    [AllowAnonymous]
    [HttpPost("FazerLogin")]
    public async Task<ActionResult> FazerLogin(Dto_LoginCredentials credencias)
    {
      Dto_Resposta resposta = new Dto_Resposta();
      resposta = await _autenticacaoRepository.FazerLogin(credencias);
      return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
    }

    [AllowAnonymous]
    [HttpPut("TerminarSessão")]
    public async Task<ActionResult> TerminarSessão()
    {
      Dto_Resposta resposta = new Dto_Resposta();
      string authToken = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
      resposta = await _autenticacaoRepository.TerminarSessão(authToken);
      return (resposta.sucess) ? Ok(resposta) : NotFound(resposta); 
    }

    [AllowAnonymous]
    [HttpGet("RecuperarSenha")]
    public async Task<ActionResult> RecuperarSenha(string telefone)
    {
      Dto_Resposta resposta = new Dto_Resposta();
      resposta = await _autenticacaoRepository.RecuperarSenha(telefone);
      return (resposta.sucess) ? Ok(resposta) : NotFound(resposta); 
    }
  }
}