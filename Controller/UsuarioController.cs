using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaPredio.DTO;
using SistemaPredio.Interface;
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
        
        if (usuarios.Count == 0) 
            return NotFound("Nenhum usuário cadastrado");
        
        return Ok(usuarios);
    }

    [HttpGet("GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _usuarioRepository.GetById(id);

        if (usuario == null)
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
    public async Task<IActionResult> Put(UsuarioDTO usuario)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if (!await _usuarioRepository.UserExists(usuario.CPF)) 
            return  NotFound("Usuario não encontrado");
        
        var usuarioUpdated = await _usuarioRepository.Put(usuario);
        
        return Accepted(usuarioUpdated);
    }

    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Usuario usuario)
    {
        var usuarioDelete =  await _usuarioRepository.GetById(usuario.Id);
        
        if(usuarioDelete == null) 
            return NotFound("Usuario nao encontrado");
        
        await _usuarioRepository.Delete(usuarioDelete);
        
        return NoContent();
    }
}