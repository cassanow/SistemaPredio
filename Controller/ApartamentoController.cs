using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaPredio.DTO;
using SistemaPredio.Interface;
using SistemaPredio.Mapping;
using SistemaPredio.Model;

namespace SistemaPredio.Controller;

[Route("api/[controller]")]
[ApiController]
public class ApartamentoController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IApartamentoRepository _apartamentoRepository;

    public ApartamentoController(IApartamentoRepository apartamentoRepository)
    {
        _apartamentoRepository = apartamentoRepository;
    }
    
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = "Admin")]
    public async Task <IActionResult> GetAll()
    {
        var apartamentos = await _apartamentoRepository.GetAll();
        
        if (apartamentos.Count == 0)
            return NotFound("Nenhum apartamento encontrado");
        
        return Ok(apartamentos);
    }

    [HttpGet("GetByCPF")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCPF(string cpf)
    {
        var apartamento = await _apartamentoRepository.GetByCPF(cpf);

        if (apartamento == null)
            return NotFound("Nenhum apartamento encontrado");
        
        return Ok(apartamento);
    }

    [HttpPost("Post")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post(ApartamentoDTO dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var apartamento = ApartamentoMapping.ToApartamento(dto);
        
        await _apartamentoRepository.Post(apartamento);
        
        return Ok(apartamento);
    }


    [HttpPut("Put")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(ApartamentoDTO dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var apartamento = new Apartamento
        {
            Codigo = dto.Codigo,
            Andar = dto.Andar,
            cpfMorador = dto.cpfMorador,
        };
        
        await _apartamentoRepository.Put(apartamento);
        
        return Ok(apartamento);
    }

    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(string codigo)
    {
        var apartamento = await _apartamentoRepository.GetByCodigo(codigo);
        await _apartamentoRepository.Delete(apartamento);
        
        return NoContent();
    }
}