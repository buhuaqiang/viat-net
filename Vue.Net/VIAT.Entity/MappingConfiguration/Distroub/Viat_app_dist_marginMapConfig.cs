using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_dist_marginMapConfig : EntityMappingConfiguration<Viat_app_dist_margin>
    {
        public override void Map(EntityTypeBuilder<Viat_app_dist_margin>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

