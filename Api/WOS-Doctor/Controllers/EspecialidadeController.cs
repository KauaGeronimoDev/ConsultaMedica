﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WOS_Doctor.MODELS;

namespace WOS_Doctor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly BdClinicaKauaAntonyContext _context;

        public EspecialidadeController(BdClinicaKauaAntonyContext context)
        {
            _context = context;
        }

        // GET: api/Especialidade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especialidade>>> GetEspecialidades()
        {
            return await _context.Especialidades.ToListAsync();
        }

        // GET: api/Especialidade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidade>> GetEspecialidade(int id)
        {
            var especialidade = await _context.Especialidades.FindAsync(id);

            if (especialidade == null)
            {
                return NotFound();
            }

            return especialidade;
        }

        // PUT: api/Especialidade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidade(int id, Especialidade especialidade)
        {
            if (id != especialidade.EspecialidadeId)
            {
                return BadRequest();
            }

            _context.Entry(especialidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadeExists(id))
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

        // POST: api/Especialidade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Especialidade>> PostEspecialidade(Especialidade especialidade)
        {
            _context.Especialidades.Add(especialidade);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EspecialidadeExists(especialidade.EspecialidadeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEspecialidade", new { id = especialidade.EspecialidadeId }, especialidade);
        }

        // DELETE: api/Especialidade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidade(int id)
        {
            var especialidade = await _context.Especialidades.FindAsync(id);
            if (especialidade == null)
            {
                return NotFound();
            }

            _context.Especialidades.Remove(especialidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialidadeExists(int id)
        {
            return _context.Especialidades.Any(e => e.EspecialidadeId == id);
        }
    }
}
