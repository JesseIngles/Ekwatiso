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
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [AllowAnonymous]
        [HttpPost("CriarConta")]
        public async Task<ActionResult> CriarContaUsuario([FromBody] Dto_Usuario usuario)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _userRepository.CriarContaUsuario(usuario);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpPut("AtualizarConta")]
        public async Task<ActionContext> AtualizarContaUsuario([FromBody] Dto_UpdateUsuario usuario)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _userRepository.AtualizarContaUsuario(1, usuario);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }
    }
}