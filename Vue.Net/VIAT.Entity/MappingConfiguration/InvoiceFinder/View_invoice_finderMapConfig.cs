using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_invoice_finderMapConfig : EntityMappingConfiguration<View_invoice_finder>
    {
        public override void Map(EntityTypeBuilder<View_invoice_finder>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

