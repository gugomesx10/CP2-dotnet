using CP2.Data;
using CP2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CP2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly ApplicationContext _context;

    public PedidosController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Pedido>> Get()
    {
        return Ok(_context.Pedidos.ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Pedido), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Pedido> GetById(int id)
    {
        var pedido = _context.Pedidos.Find(id);

        if (pedido == null)
            return NotFound();

        return Ok(pedido);
    }

    [HttpGet("cliente/{clienteId}")]
    public ActionResult<List<Pedido>> GetByCliente(int clienteId)
    {
        var pedidos = _context.Pedidos
            .Where(p => p.ClienteId == clienteId)
            .ToList();

        return Ok(pedidos);
    }

    [HttpGet("status/{status}")]
    public ActionResult<List<Pedido>> GetByStatus(string status)
    {
        var pedidos = _context.Pedidos
            .Where(p => p.Status != null && p.Status.Contains(status))
            .ToList();

        return Ok(pedidos);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Pedido), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Pedido> Post(Pedido pedido)
    {
        var clienteExiste = _context.Clientes.Any(c => c.Id == pedido.ClienteId);
        var produtoExiste = _context.Produtos.Any(p => p.Id == pedido.ProdutoId);

        if (!clienteExiste)
            return BadRequest("Cliente informado não existe.");

        if (!produtoExiste)
            return BadRequest("Produto informado não existe.");

        _context.Pedidos.Add(pedido);
        _context.SaveChanges();

        return Created("", pedido);
    }

    [HttpPut("{id}")]
    public ActionResult<Pedido> Put(int id, Pedido pedido)
    {
        if (id != pedido.Id)
            return BadRequest();

        var existente = _context.Pedidos.Find(id);

        if (existente == null)
            return NotFound();

        existente.ClienteId = pedido.ClienteId;
        existente.ProdutoId = pedido.ProdutoId;
        existente.Quantidade = pedido.Quantidade;
        existente.ValorTotal = pedido.ValorTotal;
        existente.DataPedido = pedido.DataPedido;
        existente.Status = pedido.Status;

        _context.SaveChanges();

        return Ok(existente);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pedido = _context.Pedidos.Find(id);

        if (pedido == null)
            return NotFound();

        _context.Pedidos.Remove(pedido);
        _context.SaveChanges();

        return NoContent();
    }
}