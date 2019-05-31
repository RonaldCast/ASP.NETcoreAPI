using GuideAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Services.TypepographyService
{
    public interface ITypepographyService
    {
        Task<bool> AddAsync(int idStyleSheet, Typepography model);
        Task<IEnumerable<Typepography>> GetAllTypepographyAsync(int id);
        Task<Typepography> GetTypepographyAsync(int idStyleSheet, int idTypepography);
        Task<bool> DeleteTypepographyAsync(int ididStyleSheet, int idTypepography);
        Task<bool> UpdateTypepography(int idStyleSheet, Typepography model);
    }
}
