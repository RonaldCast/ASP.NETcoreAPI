using GuideAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Services.StyleSheetService
{
    public interface IStyleSheetService
    {
        Task<bool> AddAsync(StyleSheet styleSheet);
        Task<IEnumerable<StyleSheet>> GetAllStyleSheetAsync();
        Task<StyleSheet> GetStyleSheetByIdAsync(int id);
        Task<bool> UpdateStyleSheetAsync(StyleSheet styleSheet);
        Task<bool> DeleteStyleSheetAsync(int id);
    }
}
