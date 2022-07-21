using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_wk_masterMapConfig : EntityMappingConfiguration<Viat_wk_master>
    {
        public override void Map(EntityTypeBuilder<Viat_wk_master>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

