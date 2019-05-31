using GuideAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Persistens.Mapping
{
    public class TypepographyMapping : IEntityTypeConfiguration<Typepography>
    {
        public void Configure(EntityTypeBuilder<Typepography> builder)
        {
            builder
                 .HasOne(e => e.StyleSheet)
                 .WithMany(e => e.Typepographie)
                 .HasForeignKey(e => e.StyleSheetId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
