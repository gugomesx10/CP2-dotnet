using CP2.Data;
using CP2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CP2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase

{
    private readonly ApplicationContext _context;
    
    public ClientesController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Cliente>> Get()
    {
        return Ok(_context.Clientes.ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Cliente> GetById(int id)
    {
        var cliente = _context.Clientes.Find(id);

        if (cliente == null)
            return NotFound();
        
        return Ok(cliente);
    }

    [HttpGet("email/{email}")]
    public ActionResult<List<Cliente>> GetByEmail(string email)
    {
        var clientes = _context.Clientes
            .Where(c => c.Email !=null && c.Email.Contains(email))
            .ToList();
        
        return Ok(clientes);
    }
    
    [HttpGet("endereco/{endereco}")]
    public ActionResult<List<Cliente>> GetByEndereco(string endereco)
    {
        var clientes = _context.Clientes
            .Where(c => c.Endereco !=null && c.Endereco.Contains(endereco))
            .ToList();
        
        return Ok(clientes);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Cliente> Post(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        
        return Created("",  cliente);
    }

    [HttpPut("{id}")]
    public ActionResult<Cliente> Put(int id, Cliente cliente)
    {
        if (id != cliente.Id)
            return  BadRequest();
        
        var existente = _context.Clientes.Find(id);
        
        if  (existente == null)
            return NotFound();

        existente.Nome = cliente.Nome;
        existente.Email = cliente.Email;
        existente.Endereco = cliente.Endereco;
        
        _context.SaveChanges();
        
        return Ok(existente);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cliente = _context.Clientes.Find(id);
        
        if (cliente == null)
            return NotFound();
        
        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        
        return NoContent();
    }
}