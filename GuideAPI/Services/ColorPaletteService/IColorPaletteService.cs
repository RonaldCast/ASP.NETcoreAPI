using GuideAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Services.ColorPaletteService
{
    public interface IColorPaletteService
    {
        Task<bool> AddAsync(int idStyleSheet,ColorPalette model);
        Task<IEnumerable<ColorPalette>> GetAllColorPaletteAsync(int id);
        Task<ColorPalette> GetColorPaletteAsync(int idStyleSheet, int idColorPalette);
        Task<bool> DeleteColorPaletteAsync(int idStyleSheet, int idColorPalette);
        Task<bool> UpdateColorStyleAsync(int idStyleSheet, ColorPalette model);
    }
}
