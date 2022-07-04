using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_com_system_valueMapConfig : EntityMappingConfiguration<Viat_com_system_value>
    {
        public override void Map(EntityTypeBuilder<Viat_com_system_value>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

