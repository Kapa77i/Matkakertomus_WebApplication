﻿using System;
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
    public class TarinasController : ControllerBase
    {
        private readonly MydbContext _context;

        public TarinasController(MydbContext context)
        {
            _context = context;
        }

        // GET: api/Tarinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarina>>> GetTarinas()
        {
            return await _context.Tarinas.ToListAsync();
        }

        // GET: api/Tarinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarina>> GetTarina(long id)
        {
            var tarina = await _context.Tarinas.FindAsync(id);

            if (tarina == null)
            {
                return NotFound();
            }

            return tarina;
        }

        // PUT: api/Tarinas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarina(long id, Tarina tarina)
        {
            if (id != tarina.Idtarina)
            {
                return BadRequest();
            }

            _context.Entry(tarina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarinaExists(id))
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

        // POST: api/Tarinas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tarina>> PostTarina(Tarina tarina)
        {
            _context.Tarinas.Add(tarina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarina", new { id = tarina.Idtarina }, tarina);
        }

        // DELETE: api/Tarinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarina(long id)
        {
            var tarina = await _context.Tarinas.FindAsync(id);
            if (tarina == null)
            {
                return NotFound();
            }

            _context.Tarinas.Remove(tarina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarinaExists(long id)
        {
            return _context.Tarinas.Any(e => e.Idtarina == id);
        }
    }
}