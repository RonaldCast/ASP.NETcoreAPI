using GuideAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Persistens.Mapping
{
    public class ColorPaletteMapping : IEntityTypeConfiguration<ColorPalette>
    {
        public void Configure(EntityTypeBuilder<ColorPalette> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(10);
            builder.Property(c => c.Description).HasMaxLength(15);

            builder
                .HasOne(e => e.StyleSheet)
                .WithMany(e => e.ColorPalette)
                .HasForeignKey(e => e.StyleSheetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
