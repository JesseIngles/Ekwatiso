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
  }
}