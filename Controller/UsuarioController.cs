using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using SistemaPredio.DTO;
using SistemaPredio.Enum;
using SistemaPredio.Interface;
using SistemaPredio.Mapping;
using SistemaPredio.Model;

namespace SistemaPredio.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class UsuarioController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioRepository.GetAll();

        if (User.IsInRole("Morador"))
            return StatusCode(403, new { Mensagem = "Voce nao possui permissao" });
        
        if (usuarios.Count == 0) 
            return NotFound("Nenhum usuário cadastrado");
        
        return Ok(usuarios);
    }

    [HttpGet("GetByCPF")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCPF(string cpf)
    {
        var usuario = await _usuarioRepository.GetByCPF(cpf);
        
        if (User.IsInRole("Morador"))
            return StatusCode(403, new { Mensagem = "Voce nao possui permissao" });
        
        if (!await _usuarioRepository.UserExists(usuario.CPF))
            return NotFound("Nenhum usuário encontrado");
        
        if(usuario.Id < 0)
            return BadRequest("O id informado é invalido");
        
        
        return Ok(usuario);
    }

    [HttpPost("Post")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(Usuario usuario)
    {
        if (User.IsInRole("Morador"))
            return StatusCode(403, new { Mensagem = "Voce nao possui permissao" });
        
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        if (await _usuarioRepository.UserExists(usuario.CPF))
            return Conflict("Usuario já cadastrado");
        
        await _usuarioRepository.Post(usuario);
        
        return Created();
    }

    [HttpPut("Put")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(Usuario usuario)
    {
        if (User.IsInRole("Morador"))
            return StatusCode(403, new { Mensagem = "Voce nao possui permissao" });

        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if (usuario == null) 
            return  NotFound("Usuario não encontrado");
        
        var usuarioUpdated = await _usuarioRepository.Put(usuario);
        
        return Ok(usuarioUpdated);
    }

    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string cpf)
    {
        if (User.IsInRole("Morador"))
            return StatusCode(403, new { Mensagem = "Voce nao possui permissao" });

        var usuarioDelete = await _usuarioRepository.GetByCPF(cpf);
        
        if(usuarioDelete == null) 
            return NotFound("Usuario nao encontrado");
        
        await _usuarioRepository.Delete(usuarioDelete);
        
        return NoContent();
    }
}