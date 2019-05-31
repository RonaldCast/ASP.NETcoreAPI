using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Models
{
    public class ColorPalette
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public int StyleSheetId { get; set; }
        public StyleSheet StyleSheet { get; set; }

    }
}
