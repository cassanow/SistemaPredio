using Microsoft.AspNetCore.Mvc;
using SistemaPredio.DTO;
using SistemaPredio.Enum;
using SistemaPredio.Interface;
using SistemaPredio.Mapping;
using SistemaPredio.Model;

namespace SistemaPredio.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ITokenService _tokenService;
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthController(ITokenService tokenService, IUsuarioRepository usuarioRepository)
    {
        _tokenService = tokenService;
        _usuarioRepository = usuarioRepository;
    }
    
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(LoginDTO login)
    {
        var usuario = await _usuarioRepository.GetByEmail(login.Email);
        
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if(usuario == null || usuario.Senha != login.Senha)
            return Unauthorized("Usuario ou senha incorretos");
        
        var token =  _tokenService.GenerateToken(usuario);
        
        return Ok(token);
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(UsuarioDTO usuarioDTO)
    {
        if(User.Identity.IsAuthenticated)
            return Unauthorized("Voce já esta autenticado");
            
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var usuario = UsuarioMapping.ToUsuario(usuarioDTO);
        
        if(await _usuarioRepository.UserExists(usuario.CPF))
            return BadRequest("Usuario já existe");

        var user = await _usuarioRepository.Post(usuario);
        
        return Ok(user);
    }
    
}