using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_sftp_exportMapConfig : EntityMappingConfiguration<Viat_sftp_export>
    {
        public override void Map(EntityTypeBuilder<Viat_sftp_export>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

