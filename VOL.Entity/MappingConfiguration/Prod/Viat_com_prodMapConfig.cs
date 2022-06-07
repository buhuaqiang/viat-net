using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_com_prodMapConfig : EntityMappingConfiguration<Viat_com_prod>
    {
        public override void Map(EntityTypeBuilder<Viat_com_prod>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

