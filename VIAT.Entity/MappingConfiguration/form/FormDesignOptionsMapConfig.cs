using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class FormDesignOptionsMapConfig : EntityMappingConfiguration<FormDesignOptions>
    {
        public override void Map(EntityTypeBuilder<FormDesignOptions>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

