using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_bulletinMapConfig : EntityMappingConfiguration<Viat_app_bulletin>
    {
        public override void Map(EntityTypeBuilder<Viat_app_bulletin>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

