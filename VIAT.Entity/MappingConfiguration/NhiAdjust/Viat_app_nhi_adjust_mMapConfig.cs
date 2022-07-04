using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_nhi_adjust_mMapConfig : EntityMappingConfiguration<Viat_app_nhi_adjust_m>
    {
        public override void Map(EntityTypeBuilder<Viat_app_nhi_adjust_m>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

