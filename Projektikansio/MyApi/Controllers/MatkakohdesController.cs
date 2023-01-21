using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatkakohdesController : ControllerBase
    {
        private readonly MydbContext _context;

        public MatkakohdesController(MydbContext context)
        {
            _context = context;
        }

        // GET: api/Matkakohdes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matkakohde>>> GetMatkakohdes()
        {
            return await _context.Matkakohdes.ToListAsync();
        }

        // GET: api/Matkakohdes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matkakohde>> GetMatkakohde(long id)
        {
            var matkakohde = await _context.Matkakohdes.FindAsync(id);

            if (matkakohde == null)
            {
                return NotFound();
            }

            return matkakohde;
        }

        // PUT: api/Matkakohdes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatkakohde(long id, Matkakohde matkakohde)
        {
            if (id != matkakohde.Idmatkakohde)
            {
                return BadRequest();
            }

            _context.Entry(matkakohde).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatkakohdeExists(id))
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

        // POST: api/Matkakohdes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Matkakohde>> PostMatkakohde(Matkakohde matkakohde)
        {
            _context.Matkakohdes.Add(matkakohde);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatkakohde", new { id = matkakohde.Idmatkakohde }, matkakohde);
        }

        // DELETE: api/Matkakohdes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatkakohde(long id)
        {
            var matkakohde = await _context.Matkakohdes.FindAsync(id);
            if (matkakohde == null)
            {
                return NotFound();
            }

            _context.Matkakohdes.Remove(matkakohde);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatkakohdeExists(long id)
        {
            return _context.Matkakohdes.Any(e => e.Idmatkakohde == id);
        }
    }
}
