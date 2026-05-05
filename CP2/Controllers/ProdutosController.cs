using CP2.Data;
using CP2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CP2.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ApplicationContext  _context;

    public ProdutosController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Produto>> Get()
    {
        return Ok (_context.Produtos.ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Produto> GetById(int id)
    {
        var produto = _context.Produtos.Find(id);
        
        if (produto == null)        
            return NotFound();
        
        return Ok(produto);
    
    }

    [HttpGet("preco/{valor}")]
    public ActionResult<List<Produto>> GetByPreco(decimal valor)
    {
        var produto = _context.Produtos
            .Where(p => p.Preco == valor)
            .ToList();
        
        return Ok(produto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Produto> Post(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        
        return Created("", produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Produto produto)
    {
        if (id != produto.Id)
            return BadRequest();

        var existente = _context.Produtos.Find(id);

        if (existente == null)
            return NotFound();

        existente.Nome = produto.Nome;
        existente.Preco = produto.Preco;
        
        _context.SaveChanges();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = _context.Produtos.Find(id);
        
        if (produto == null)
            return NotFound();

        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        
        return NoContent();
    }
    
}