using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class View_com_prodMapConfig : EntityMappingConfiguration<View_com_prod>
    {
        public override void Map(EntityTypeBuilder<View_com_prod>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

