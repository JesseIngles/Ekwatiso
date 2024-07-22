using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.Controllers
{
    [Authorize]
    [Controller]
    [Route("api/[controller]")]
    public class PaisController : Controller
    {
        private readonly IPaisRepository _paisRepository;
        public PaisController(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        [AllowAnonymous]
        [HttpPost("CadastrarPais")]
        public async Task<ActionResult> CadastrarPais(Dto_Pais pais)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _paisRepository.CadastrarPais(pais);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpPut("AtualizarPais")]
        public async Task<ActionResult> AtualizarPais(int id, Dto_Pais pais)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _paisRepository.AtualizarPais(id, pais);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpGet("TodosPaises")]
        public async Task<ActionResult> TodosPaises()
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _paisRepository.TodosPaises();
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpDelete("ApagarPais")]
        public async Task<ActionResult> ApagarPais(int id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _paisRepository.ApagarPais(id);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }
    }
}
