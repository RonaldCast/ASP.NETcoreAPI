using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuideAPI.Models;
using GuideAPI.Services.TypepographyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuideAPI.Controllers
{
    [ApiController]
    public class TypepographyController : ControllerBase
    {
        private readonly ITypepographyService _typepographyService;
        public TypepographyController(ITypepographyService typepographyService)
        {
            _typepographyService = typepographyService;
        }

        // GET styleSheet/5/Typography
        [HttpGet("styleSheet/{id}/Typepography")]
        public async Task<ActionResult<IEnumerable<Typepography>>> GetAllTypography(int id)
        {
            var listTypepography = await _typepographyService.GetAllTypepographyAsync(id);

            if (listTypepography == null)
                NotFound( new { message = "Error"});

            return Ok(listTypepography);

        }

        // GET Typography/1
        [HttpGet("typepography/{id}")]
        public async Task<ActionResult<Typepography>> GetOneTypography(int id)
        {
            var model = await _typepographyService.GetTypepographyAsync(id);

            if (model == null)
                return NotFound(new { message = "not found" });

            return Ok(model);
        }

        // POST styleSheet/5/Typepography/
        [HttpPost("styleSheet/{id}/Typepography")]
        public async Task<ActionResult<bool>> Post(int id, [FromBody]  Typepography model)
        {
            var saved = await _typepographyService.AddAsync(id, model);

            if (saved == false)
                return BadRequest(new { message = "Error: bad request" });

            return Ok(saved);
        }

        // PUT typography/1
        [HttpPut("typepography/{id}")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] Typepography model)
        {
            var saved = await _typepographyService.UpdateTypepography(id, model);

            if (saved == false)
                return BadRequest();

            return Ok(saved);
        }

        // DELETE styleSheet/5/Typography/1
        [HttpDelete("typepography/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var saved = await _typepographyService.DeleteTypepographyAsync(id);

            if (saved == false)
                return BadRequest();

            return Ok(saved);
        }

    }
}