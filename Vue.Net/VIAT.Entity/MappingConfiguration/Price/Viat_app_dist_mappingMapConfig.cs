using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_dist_mappingMapConfig : EntityMappingConfiguration<Viat_app_dist_mapping>
    {
        public override void Map(EntityTypeBuilder<Viat_app_dist_mapping>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

