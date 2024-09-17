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
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpGet("VerMinhaConta")]
        public async Task<ActionResult> VerMinhaConta()
        {
            var usuarioId = int.Parse(User.FindFirst("UserId")!.Value);
    
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _userRepository.VerMinhaConta(usuarioId);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }
        [AllowAnonymous]
        [HttpGet("VerUsuario/{id:int}")]
        public async Task<ActionResult> VerUsuario(int id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _userRepository.VerUsuarioPorId(id);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
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
        public async Task<ActionResult> AtualizarContaUsuario([FromBody] Dto_Usuario usuario)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _userRepository.AtualizarContaUsuario(1, usuario);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }
    }
}