using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Models
{
    public class Typepography
    {
        public int Id { get; set; }
        public string Typeface { get; set; }
        public string Color { get; set; }
        public string Text { get; set; }

        public int StyleSheetId { get; set; }
        public StyleSheet StyleSheet { get; set; }

    }
}
