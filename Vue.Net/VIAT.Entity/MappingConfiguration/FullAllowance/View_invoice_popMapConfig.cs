using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_invoice_popMapConfig : EntityMappingConfiguration<View_invoice_pop>
    {
        public override void Map(EntityTypeBuilder<View_invoice_pop>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

