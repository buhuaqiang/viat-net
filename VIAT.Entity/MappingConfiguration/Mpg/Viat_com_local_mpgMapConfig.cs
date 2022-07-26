using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_com_local_mpgMapConfig : EntityMappingConfiguration<Viat_com_local_mpg>
    {
        public override void Map(EntityTypeBuilder<Viat_com_local_mpg>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

