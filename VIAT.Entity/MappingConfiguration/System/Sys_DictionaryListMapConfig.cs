using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Sys_DictionaryListMapConfig : EntityMappingConfiguration<Sys_DictionaryList>
    {
        public override void Map(EntityTypeBuilder<Sys_DictionaryList>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

