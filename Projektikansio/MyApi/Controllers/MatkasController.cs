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
    public class MatkasController : ControllerBase
    {
        private readonly MydbContext _context;

        public MatkasController(MydbContext context)
        {
            _context = context;
        }

        // GET: api/Matkas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matka>>> GetMatkas()
        {
            return await _context.Matkas.ToListAsync();
        }

        // GET: api/Matkas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matka>> GetMatka(long id)
        {
            var matka = await _context.Matkas.FindAsync(id);

            if (matka == null)
            {
                return NotFound();
            }

            return matka;
        }

        // PUT: api/Matkas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatka(long id, Matka matka)
        {
            if (id != matka.Idmatka)
            {
                return BadRequest();
            }

            _context.Entry(matka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatkaExists(id))
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

        // POST: api/Matkas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Matka>> PostMatka(Matka matka)
        {
            _context.Matkas.Add(matka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatka", new { id = matka.Idmatka }, matka);
        }

        // DELETE: api/Matkas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatka(long id)
        {
            var matka = await _context.Matkas.FindAsync(id);
            if (matka == null)
            {
                return NotFound();
            }

            _context.Matkas.Remove(matka);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatkaExists(long id)
        {
            return _context.Matkas.Any(e => e.Idmatka == id);
        }
    }
}