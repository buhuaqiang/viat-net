using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_com_doh_typeMapConfig : EntityMappingConfiguration<Viat_com_doh_type>
    {
        public override void Map(EntityTypeBuilder<Viat_com_doh_type>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

