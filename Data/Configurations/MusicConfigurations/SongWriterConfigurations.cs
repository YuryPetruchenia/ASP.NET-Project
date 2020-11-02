﻿using System.Data.Entity.ModelConfiguration;
using DomainLogic.Model;

namespace Data.Configurations.MusicConfigurations
{
    class SongWriterConfigurations : EntityTypeConfiguration<SongWriter>
    {
        public SongWriterConfigurations()
        {
            HasKey(s => s.SongWriterId);
            HasMany(c => c.Genres).WithOptional().WillCascadeOnDelete(false);
        }
    }
}
