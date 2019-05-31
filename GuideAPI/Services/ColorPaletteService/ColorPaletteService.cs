using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuideAPI.Models;
using GuideAPI.Persistens;
using Microsoft.EntityFrameworkCore;

namespace GuideAPI.Services.ColorPaletteService
{
    public class ColorPaletteService : IColorPaletteService
    {
        private readonly ApplicationDbContext _dbContext;

        public ColorPaletteService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<bool> AddAsync(int idStyleSheet, ColorPalette model)
        {
            try
            {
                if (idStyleSheet != model.StyleSheetId)
                {
                    return false;
                }

                var styleSheet = await _dbContext.StyleSheet.Where(e => e.Id == idStyleSheet).SingleOrDefaultAsync();

                model.StyleSheet = styleSheet;
                _dbContext.ColorPalette.Add(model);
                var saved = await _dbContext.SaveChangesAsync();


                return saved == 1;
                
            }
            catch(Exception ex)
            {

                return false; 
            }

        }

        public async Task<bool> DeleteColorPaletteAsync(int idStyleSheet, int idColorPalette)
        {
            try
            {
                var colorRemove = await _dbContext.ColorPalette
                                .Where(e => e.Id == idColorPalette && e.StyleSheetId == idStyleSheet).SingleOrDefaultAsync();

                if (colorRemove == null)
                    return false;

                _dbContext.Remove(colorRemove);

                var saved = await _dbContext.SaveChangesAsync();
                return saved == 1;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ColorPalette>> GetAllColorPaletteAsync(int id)
        {
            var listCalors = new List<ColorPalette>();

            try
            {

                listCalors = await _dbContext.ColorPalette
                            .Where(e => e.StyleSheetId == id)
                            .ToListAsync();
            }
            catch 
            {
                return null;
            }

            return listCalors; 
        }

        public async  Task<ColorPalette> GetColorPaletteAsync(int idStyleSheet, int idColorPalette)
        {
            var colorPalette = new ColorPalette();
            try
            {
                colorPalette = await _dbContext.ColorPalette
                                .Where(e => e.Id == idColorPalette && e.StyleSheetId == idStyleSheet).SingleOrDefaultAsync();

                if (colorPalette == null)
                    return null;

                return colorPalette;
            }
            catch
            {
                return null; 
            }
        }

        public async Task<bool> UpdateColorStyleAsync(int idStyleSheet, ColorPalette model)
        {
            try
            {
                if (idStyleSheet != model.StyleSheetId)
                {
                    return false; 
                }

                var updateColor = await _dbContext.ColorPalette
                                .Where(e => e.Id == model.Id && e.StyleSheetId == model.StyleSheetId)
                                .SingleOrDefaultAsync();

                if (updateColor == null)
                {
                    return false;
                }

                updateColor.Name = model.Name;
                updateColor.Description = model.Description;
                updateColor.Color = model.Color;

                var saved = await _dbContext.SaveChangesAsync();

                return saved == 1;
            }
            catch 
            {
                return false;
            }

        }
    }
}
