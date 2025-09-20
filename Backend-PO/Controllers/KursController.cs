using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_PO.Interfaces;
using Backend_PO.Models;

namespace Backend_PO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KursController : ControllerBase
    {
        private readonly IKursService _kursService;

        public KursController(IKursService kursService)
        {
            _kursService = kursService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Kurs>>> GetAllKurs()
        {
            var kursList = await _kursService.GetAllKursAsync();
            return Ok(kursList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kurs>> GetKursById(int id)
        {
            var kurs = await _kursService.GetKursByIdAsync(id);

            if (kurs == null)
                return NotFound();

            return Ok(kurs);
        }

        [HttpPost]
        public async Task<ActionResult<Kurs>> CreateKurs([FromBody] Kurs kurs)
        {
            var createdKurs = await _kursService.CreateKursAsync(kurs);
            return CreatedAtAction(nameof(GetKursById), new { id = createdKurs.Id }, createdKurs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKurs(int id, [FromBody] Kurs updatedKurs)
        {
            var success = await _kursService.UpdateKursAsync(id, updatedKurs);

            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKurs(int id)
        {
            var success = await _kursService.DeleteKursAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}