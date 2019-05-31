using GuideAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideAPI.Persistens.Mapping
{
    public class StyleSheetMapping : IEntityTypeConfiguration<StyleSheet>
    {
        //para configurar la clase
        public void Configure(EntityTypeBuilder<StyleSheet> builder)
        {
           
        }
    }
}
