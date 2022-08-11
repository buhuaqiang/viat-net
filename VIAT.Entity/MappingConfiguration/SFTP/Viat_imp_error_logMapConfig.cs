using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_imp_error_logMapConfig : EntityMappingConfiguration<Viat_imp_error_log>
    {
        public override void Map(EntityTypeBuilder<Viat_imp_error_log>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

