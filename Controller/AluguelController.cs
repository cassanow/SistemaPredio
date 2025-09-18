using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaPredio.DTO;
using SistemaPredio.Enum;
using SistemaPredio.Interface;
using SistemaPredio.Mapping;
using SistemaPredio.Model;
using SistemaPredio.Repository;

namespace SistemaPredio.Controller;

[Route("api/[controller]")]
[ApiController]
public class AluguelController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IAluguelRepository _aluguelRepository;
    private readonly IAluguelService _aluguelService;   

    public AluguelController(IAluguelRepository aluguelRepository,  IAluguelService aluguelService)
    {
        _aluguelRepository = aluguelRepository;
        _aluguelService = aluguelService;
    }
    
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var alugueis = await _aluguelRepository.GetAll();
        
        if(alugueis.Count == 0)
            return NotFound("Nenhum aluguel encontrado");
        
        return Ok(alugueis);
    }

    [HttpGet("GetByCPF")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCPF(string cpf)
    {
        var aluguel = await _aluguelRepository.GetByCPF(cpf);
        
        if(aluguel == null)
            return NotFound("Nenhum aluguel encontrado");
        
        return Ok(aluguel);
    }

    [HttpPost("Post")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post(AluguelDTO dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var aluguel = AluguelMapping.ToAluguel(dto);
        
        await _aluguelRepository.Post(aluguel);
        
        return Created("Aluguel", aluguel);
        
    }

    [HttpPost("Pagamento")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Pagamento(string cpf)
    {
        var aluguel = await _aluguelRepository.GetByCPF(cpf);
        if(aluguel == null)
            return NotFound("Nenhum aluguel encontrado");
        
        if(aluguel.Pago == Pago.Sim)
            return BadRequest("Esse aluguel já foi pago");

        var precoFinal =  _aluguelService.JurosAluguel(aluguel);

        aluguel.Pago = Pago.Sim;
        aluguel.DataPagamento = DateTime.Now;
        await _aluguelRepository.Put(aluguel);

        return Ok(new
        {
            Mensagem = "Pagamento realizado com sucesso",
            ValorOriginal= aluguel.Preco,
            ValorPago =  precoFinal,
        });
    }  

    [HttpPut("Put")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put(AluguelDTO dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var aluguel = AluguelMapping.ToAluguel(dto);
        await _aluguelRepository.Put(aluguel);
        
        return Ok(aluguel);
    }

    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(string cpf)
    {
        var aluguel = await _aluguelRepository.GetByCPF(cpf);
        await _aluguelRepository.Delete(aluguel);
        
        return NoContent();
    }
}