using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_com_global_mpgMapConfig : EntityMappingConfiguration<Viat_com_global_mpg>
    {
        public override void Map(EntityTypeBuilder<Viat_com_global_mpg>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

