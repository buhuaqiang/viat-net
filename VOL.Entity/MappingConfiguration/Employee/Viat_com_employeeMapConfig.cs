using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_com_employeeMapConfig : EntityMappingConfiguration<Viat_com_employee>
    {
        public override void Map(EntityTypeBuilder<Viat_com_employee>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

