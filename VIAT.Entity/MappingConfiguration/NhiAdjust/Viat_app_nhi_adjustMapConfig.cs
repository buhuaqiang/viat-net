using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_nhi_adjustMapConfig : EntityMappingConfiguration<Viat_app_nhi_adjust>
    {
        public override void Map(EntityTypeBuilder<Viat_app_nhi_adjust>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

