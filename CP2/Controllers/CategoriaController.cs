using CP2.Data;
using CP2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CP2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ApplicationContext _context;

    public CategoriasController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Categoria>> Get()
    {
        return Ok(_context.Categorias.ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Categoria> GetById(int id)
    {
        var categoria = _context.Categorias.Find(id);
        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpGet("nome/{nome}")]
    public ActionResult<List<Categoria>> GetByNome(string nome)
    {
        var categorias = _context.Categorias
            .Where(c => c.Nome.Contains(nome))
            .ToList();

        return Ok(categorias);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Categoria> Post(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();

        return Created("", categoria);
    }

    [HttpPut("{id}")]
    public ActionResult<Categoria> Put(int id, Categoria categoria)
    {
        if (id != categoria.Id)
            return BadRequest();

        var existente = _context.Categorias.Find(id);

        if (existente == null)
            return NotFound();

        existente.Nome = categoria.Nome;
        existente.Descricao = categoria.Descricao;

        _context.SaveChanges();

        return Ok(existente);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var categoria = _context.Categorias.Find(id);

        if (categoria == null)
            return NotFound();

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();

        return NoContent();
    }
}