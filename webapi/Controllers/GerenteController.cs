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
    public class GerenteController : Controller
    {
        private readonly IGerenteRepository _gerenteRepository;
        
        public GerenteController(IGerenteRepository gerenteRepository)
        {
            _gerenteRepository = gerenteRepository;
        }

        [AllowAnonymous]
        [HttpPost("CriarConta")]
        public async Task<ActionResult> CriarContaGerente([FromBody] Dto_Gerente gerente)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _gerenteRepository.CriarContaGerente(gerente);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpPut("AtualizarConta")]
        public async Task<ActionResult> AtualizarContaGerente([FromBody] Dto_Gerente gerente)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _gerenteRepository.AtualizarContaGerente(1, gerente);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }
    }
}
