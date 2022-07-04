using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_import_customer_maintainMapConfig : EntityMappingConfiguration<View_import_customer_maintain>
    {
        public override void Map(EntityTypeBuilder<View_import_customer_maintain>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

