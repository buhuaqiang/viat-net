﻿using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Framework.Entity.MappingConfiguration
{
    public class Sys_LogMapConfig : EntityMappingConfiguration<Sys_Log>
    {
        public override void Map(EntityTypeBuilder<Sys_Log> builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
    }
}

