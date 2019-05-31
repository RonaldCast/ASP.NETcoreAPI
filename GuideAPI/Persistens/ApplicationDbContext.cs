using GuideAPI.Models;
using GuideAPI.Persistens.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Persistens
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ColorPalette> ColorPalette { get; set; }
        public DbSet<StyleSheet> StyleSheet { get; set; }
        public DbSet<Typepography> Typepography { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColorPaletteMapping());
            modelBuilder.ApplyConfiguration(new StyleSheetMapping());
            modelBuilder.ApplyConfiguration(new TypepographyMapping());
        }


    }
}
