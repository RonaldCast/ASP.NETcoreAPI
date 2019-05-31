using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Models
{
    public class StyleSheet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ColorPalette> ColorPalette { get; set; }
        public ICollection<Typepography> Typepographie { get; set; }
    }
}
