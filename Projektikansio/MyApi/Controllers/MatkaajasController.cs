using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using SharedLib;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatkaajasController : ControllerBase
    {
        private readonly MydbContext _context;

        public MatkaajasController(MydbContext context)
        {
            _context = context;
        }

        // GET: api/Matkaajas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<matkaajaDTO>>> GetMatkaajas()
        {
            List<matkaajaDTO> list = new List<matkaajaDTO>();

            if (_context.Matkaajas == null)
            {
                return NotFound();
            }
            var users = await _context.Matkaajas.OrderByDescending(x => x.Idmatkaaja).ToListAsync();
            foreach (var user in users)
            {
                list.Add(user.toMatkaajaDTO());
            }
            return Ok(list);
        }

        // GET: api/Matkaajas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matkaaja>> GetMatkaaja(long id)
        {
            var matkaaja = await _context.Matkaajas.FindAsync(id);

            if (matkaaja == null)
            {
                return NotFound();
            }

            return matkaaja;
        }

        // PUT: api/Matkaajas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatkaaja(long id, Matkaaja matkaaja)
        {

            var user = await _context.Matkaajas.FirstOrDefaultAsync(x => x.Idmatkaaja == id);
            if (user != null)
            {
                return BadRequest();
            }

            user.Etunimi = matkaaja.Etunimi;
            user.Sukunimi = matkaaja.Sukunimi;
            user.Nimimerkki = matkaaja.Nimimerkki;
            user.Paikkakunta = matkaaja.Paikkakunta;
            user.Esittely = matkaaja.Esittely;
            user.Kuva = matkaaja.Kuva;
            user.Email = matkaaja.Email;
            user.Password = matkaaja.Password;

            _context.Entry(matkaaja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatkaajaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Matkaajas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Matkaaja>> PostMatkaaja(Matkaaja matkaaja)
        {
            _context.Matkaajas.Add(matkaaja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatkaaja", new { id = matkaaja.Idmatkaaja }, matkaaja);
        }

        // DELETE: api/Matkaajas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatkaaja(long id)
        {
            var matkaaja = await _context.Matkaajas.FindAsync(id);
            if (matkaaja == null)
            {
                return NotFound();
            }

            _context.Matkaajas.Remove(matkaaja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatkaajaExists(long id)
        {
            return _context.Matkaajas.Any(e => e.Idmatkaaja == id);
        }
    }
}
