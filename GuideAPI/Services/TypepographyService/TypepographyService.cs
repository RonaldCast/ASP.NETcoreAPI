using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuideAPI.Models;
using GuideAPI.Persistens;
using Microsoft.EntityFrameworkCore;

namespace GuideAPI.Services.TypepographyService
{
    public class TypepographyService : ITypepographyService
    {

        private readonly ApplicationDbContext _dbContext;
        public TypepographyService(ApplicationDbContext dbContext)
        {
             _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(int idStyleSheet, Typepography model)
        {
            try
            {
                if (model == null || idStyleSheet == model.Id)
                    return false;
                var styleSheet = await  _dbContext.StyleSheet.FindAsync(idStyleSheet);

                if (styleSheet == null)
                    return false;
                model.StyleSheet = styleSheet;

                _dbContext.Add(model);
                var saved = await _dbContext.SaveChangesAsync();

                return saved == 1;
            }
            catch
            {

                return false; 
            }
        }

        public async Task<bool> DeleteTypepographyAsync
            (int idStyleSheet, int idTypepography)
        {
            try
            {
                var model = await _dbContext.Typepography
                    .Where(e => e.Id == idTypepography && e.StyleSheetId == idStyleSheet)
                    .SingleOrDefaultAsync();
                if (model == null)
                    return false;
                _dbContext.Remove(model);

                var saved = await _dbContext.SaveChangesAsync();

                return saved == 1;
            }
            catch 
            {

                return false; 
            }
        }

        public async Task<IEnumerable<Typepography>> GetAllTypepographyAsync(int id)
        {
            var listTypepography = new List<Typepography>();
            try
            {
                listTypepography = await _dbContext.Typepography
                                    .Where(e => e.StyleSheetId == id)
                                    .ToListAsync();
                if (listTypepography == null)
                    return null;

            }
            catch (Exception)
            {

                return null;
            }

            return listTypepography; 
        }

        public async Task<Typepography> GetTypepographyAsync(int idStyleSheet, int idTypepography)
        {
            var typepography = new Typepography();

            try
            {
                typepography = await _dbContext.Typepography
                             .Where(e => e.StyleSheetId == idStyleSheet && e.Id == idTypepography)
                             .SingleOrDefaultAsync();
            }
            catch
            {
                return null;
            }
            return typepography;
        }

        public async Task<bool> UpdateTypepography(int idStyleSheet, Typepography model)
        {
            try
            {
                if (idStyleSheet == model.StyleSheetId)
                    return false;
                var updateModel = await _dbContext.Typepography
                                    .Where(e => e.StyleSheetId == idStyleSheet && e.Id == model.Id)
                                    .SingleOrDefaultAsync();

                updateModel.Typeface = model.Typeface;
                updateModel.Color = model.Color;
                updateModel.Text = model.Text;

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
