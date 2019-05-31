using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuideAPI.Models;
using GuideAPI.Persistens;
using Microsoft.EntityFrameworkCore;

namespace GuideAPI.Services.StyleSheetService
{
    public class StyleSheetService : IStyleSheetService
    {
        private readonly ApplicationDbContext _dbContext;

        public StyleSheetService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(StyleSheet styleSheet)
        {
            try
            {
                if (styleSheet == null || string.IsNullOrEmpty(styleSheet.Name))
                {
                    return false;
                }

                styleSheet.Name = styleSheet.Name.Trim();
                _dbContext.Add(styleSheet);

                var save = await _dbContext.SaveChangesAsync();

                return save == 1;

            }catch
            {
                return false; 
            }
        }

        public async Task<bool> DeleteStyleSheetAsync(int id)
        {
            try
            {
                var item = await _dbContext.StyleSheet.Where(s => s.Id == id).SingleOrDefaultAsync();
                if (item == null)
                {
                    return false;
                }

                _dbContext.Remove(item);
                var statusSave = await _dbContext.SaveChangesAsync();
                return statusSave == 1;

            }
            catch (Exception)
            {

                return false;
            }


        }

        public async Task<IEnumerable<StyleSheet>> GetAllStyleSheetAsync()
        {
            var listStyleSheet = new List<StyleSheet>();
            try
            {
                listStyleSheet = await _dbContext.StyleSheet.ToListAsync();
             
            }catch
            {
                return null;
            }

            return listStyleSheet;
        }

        public async Task<StyleSheet> GetStyleSheetByIdAsync(int id)
        {
            var styleSheet = new StyleSheet();
            try
            {
                styleSheet = await _dbContext.StyleSheet.FindAsync(id);
            }
            catch
            {
                return null;
                
            }
            return styleSheet;
        }

        public async Task<bool> UpdateStyleSheetAsync(StyleSheet styleSheet)
        {
            try
            {
                _dbContext.Entry(styleSheet).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
