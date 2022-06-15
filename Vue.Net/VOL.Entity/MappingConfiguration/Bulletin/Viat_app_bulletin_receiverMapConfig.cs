using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_app_bulletin_receiverMapConfig : EntityMappingConfiguration<Viat_app_bulletin_receiver>
    {
        public override void Map(EntityTypeBuilder<Viat_app_bulletin_receiver>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

