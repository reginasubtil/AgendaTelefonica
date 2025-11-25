using Microsoft.AspNetCore.Mvc;
using AgendaTelefonica.Models;
using System.Collections.Generic;
using System.Linq;

namespace AgendaTelefonica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatosController : ControllerBase
    {
        private readonly AgendaContext _context;

        public ContatosController(AgendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Contato> Get()
        {
            return _context.Contatos.ToList();
        }

        [HttpPost]
        public IActionResult Post(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = contato.Id }, contato);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return NotFound();

            _context.Contatos.Remove(contato);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

