using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_com_zip_cityMapConfig : EntityMappingConfiguration<Viat_com_zip_city>
    {
        public override void Map(EntityTypeBuilder<Viat_com_zip_city>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

