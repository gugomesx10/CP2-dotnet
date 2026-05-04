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
    public ActionResult<Cliente> GetById(int id)
    {
        var cliente = _context.Clientes.Find(id);

        if (cliente == null)
            return NotFound();
        
        return Ok(cliente);
    }

    [HttpGet("email/email")]
    public ActionResult<List<Cliente>> GetByEmail(string email)
    {
        var clientes = _context.Clientes
            .Where(c => c.Email.Contains(email))
            .ToList();
        
        return Ok(clientes);
    }

    [HttpPost]
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

        existente.Nome = cliente.Nome;
        existente.Email = cliente.Email;
        
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