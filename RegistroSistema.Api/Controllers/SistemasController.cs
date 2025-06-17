using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistemas.Abstractions;
using Sistemas.Data.Context;
using Sistemas.Data.Models;
using Sistemas.Domain.DTO;


namespace RegistroSistema.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SistemasController(ISistemasService sistemaService) : ControllerBase
    {
        // GET: api/Sistemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SistemasDto>>> GetSistemas()
        {
            return await sistemaService.Listar(p => true);
        }

        // GET: api/Sistemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SistemasDto>> GetSistemas(int id)
        {
            return await sistemaService.Buscar(id);
        }

        // PUT: api/Sistemas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSistemas(int id, SistemasDto sistemaDto)
        {
            if (id != sistemaDto.SistemaId)
            {
                return BadRequest();
            }

            await sistemaService.Guardar(sistemaDto);

            return NoContent();
        }

        // POST: api/Sistemas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sistema>> PostSistemas(SistemasDto sistemaDto)
        {
            await sistemaService.Guardar(sistemaDto);

            return CreatedAtAction("GetSistemas", new { id = sistemaDto.SistemaId }, sistemaDto);
        }

        // DELETE: api/Sistemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSistemas(int id)
        {
            await sistemaService.Eliminar(id);

            return NoContent();
        }
    }
}
