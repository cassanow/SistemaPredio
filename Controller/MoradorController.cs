using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaPredio.DTO;
using SistemaPredio.Interface;
using SistemaPredio.Mapping;
using SistemaPredio.Model;

namespace SistemaPredio.Controller;

[Route("api/[controller]")]
[ApiController]
public class MoradorController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IMoradorRepository _moradorRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public MoradorController(IMoradorRepository moradorRepository,  IUsuarioRepository usuarioRepository)
    {
        _moradorRepository = moradorRepository;
        _usuarioRepository = usuarioRepository;
    }
    
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        
        if (User.IsInRole("Morador"))
            return StatusCode(403, new { Mensagem = "Voce nao possui permissao" });
        
        var moradores = await _moradorRepository.GetAllMoradores();
       
        if(moradores.Count == 0)
            return NotFound("Nenhum morador encontrado");
        
        return Ok(moradores);
    }

    [HttpGet("GetByCPF")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByCPF(string cpf)
    {
        if (User.IsInRole("Morador"))
            return StatusCode(403, new { Mensagem = "Voce nao possui permissao" });
        
        var morador = await _moradorRepository.GetByCPF(cpf);
        
        if (!await _moradorRepository.MoradorExists(morador.CPF))
            return NotFound("Nenhum morador encontrado");
        
        return Ok(morador);
    }

    [HttpPost("Post")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public async Task<IActionResult> Post(MoradorDTO dadosMorador)
    { 
        
        var usuarioId = int.Parse(User.FindFirst("id").Value);
        
        var usuario = await _usuarioRepository.GetById(usuarioId);
        if (usuario == null)
            return NotFound("Nenhum usuario encontrado");
        

        var morador = new Morador
        {
            CPF = dadosMorador.CPF,
            Nome = dadosMorador.Nome,
            UsuarioId = usuario.Id,
            Telefone =  dadosMorador.Telefone,
        };

        await _moradorRepository.Post(morador);

        return StatusCode(201, morador);
    }

    [HttpPut("Put")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(MoradorDTO dadosMorador)
    {
        
        var usuarioId = int.Parse(User.FindFirst("id").Value);

        var morador = await _moradorRepository.GetByUsuarioId(usuarioId);
        if(morador == null)
            return NotFound("Nenhum morador encontrado");
        
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        morador.Nome = dadosMorador.Nome;
        morador.Telefone = dadosMorador.Telefone;

        var moradorUpdated = await _moradorRepository.Put(morador);
        
        return Ok(moradorUpdated);
    }

    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(string cpf)
    {
        if (User.IsInRole("Morador"))
            return StatusCode(403, new { Mensagem = "Voce nao possui permissao" });
        
        var morador = await _moradorRepository.GetByCPF(cpf);
        
        await _moradorRepository.Delete(morador);
        
        return NoContent();
    }
}