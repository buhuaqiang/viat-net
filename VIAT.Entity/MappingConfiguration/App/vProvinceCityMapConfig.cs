using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class vProvinceCityMapConfig : EntityMappingConfiguration<vProvinceCity>
    {
        public override void Map(EntityTypeBuilder<vProvinceCity>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

