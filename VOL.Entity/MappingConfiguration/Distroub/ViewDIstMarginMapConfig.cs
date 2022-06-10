using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class ViewDIstMarginMapConfig : EntityMappingConfiguration<ViewDIstMargin>
    {
        public override void Map(EntityTypeBuilder<ViewDIstMargin>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

