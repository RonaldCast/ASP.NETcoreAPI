using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuideAPI.Models;
using GuideAPI.Services.ColorPaletteService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuideAPI.Controllers
{
    //[Route("styleSheet")]
    [ApiController]
    public class ColorpaletteController : ControllerBase
    {
        private readonly IColorPaletteService _colorPaletteService;

        public ColorpaletteController(IColorPaletteService colorPaletteService)
        {
            _colorPaletteService = colorPaletteService;
        }

        //GET styleSheet/5/Colorpalette
       [HttpGet("styleSheet/{id}/Colorpalette")]
        public async Task<ActionResult> GetAllColorPalette(int id)
        {
            return Ok(
                await _colorPaletteService.GetAllColorPaletteAsync(id)
                );
        }

        // GET styleSheet/5/Colorpalette/1
        [HttpGet("ColorPalette/{id}")]
        public async Task<ActionResult<ColorPalette>> GetOneColor(int id)
        {
            var model = await _colorPaletteService.GetColorPaletteAsync(id);

            if (model == null)
               return NotFound();

            return Ok(
                model
                );
        }

        // Post stylesheet/5/Colorpalette
        [HttpPost("styleSheet/{id}/ColorPalette")]
        public async Task<ActionResult<bool>> Post(int id,[FromBody] ColorPalette model)
        {
            var statuSave = await _colorPaletteService.AddAsync(id, model);
            if (statuSave == false)
                return NotFound(new { message = false });

            return Ok(
                statuSave
            );
        }

        //DELETE stylesheet/5/Colorpalette/4
        [HttpDelete("ColorPalette/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var colorPalette = await _colorPaletteService.DeleteColorPaletteAsync(id);

            if (colorPalette == false)
                return NotFound();

            return NoContent();
        }

        // PUT stylesheet/5/Colorpalette/4
        [HttpPut("colorPalette/{id}")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] ColorPalette model)
        {
            var updateColorPalette = await _colorPaletteService.UpdateColorStyleAsync(id, model);

            if (updateColorPalette == false)
                return NotFound();

            return NoContent();
        }


    }
}