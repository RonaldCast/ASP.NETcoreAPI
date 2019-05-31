using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuideAPI.Models;
using GuideAPI.Services.StyleSheetService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuideAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StyleSheetController : ControllerBase
    {
        public readonly IStyleSheetService _styleSheetService;

        public StyleSheetController(IStyleSheetService styleSheetService)
        {
            _styleSheetService = styleSheetService;
        }
        // GET /stylesheet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StyleSheet>>> Get()
        {
            var listStyleSheet = await _styleSheetService.GetAllStyleSheetAsync();

            if(listStyleSheet == null)
                return NotFound();

            return Ok(
                listStyleSheet
            );
        }

        // GET /stylesheet/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<StyleSheet>> Get(int id)
        {
            var styleSheel = await _styleSheetService.GetStyleSheetByIdAsync(id);
            if (styleSheel == null)
            {
                return NotFound();
            }
            return styleSheel;
        }

        // POST /stylesheet
        [HttpPost]
        public async Task<ActionResult<StyleSheet>> Post([FromBody] StyleSheet model)
        {
            await _styleSheetService.AddAsync(model);

            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        // PUT /stylesheet/:id
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StyleSheet model)
        {

            if (id != model.Id)
            {
                return BadRequest();
            }

            var findUpdated = await _styleSheetService.UpdateStyleSheetAsync(model);

            if (findUpdated == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE /stylesheet/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var styleSheet = await _styleSheetService.DeleteStyleSheetAsync(id);

           
            if ( styleSheet == false)
            {
                return NotFound();
            }

            return NoContent();

        }

    }
}