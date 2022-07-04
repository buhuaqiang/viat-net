using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_com_prod_pop_queryMapConfig : EntityMappingConfiguration<View_com_prod_pop_query>
    {
        public override void Map(EntityTypeBuilder<View_com_prod_pop_query>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

