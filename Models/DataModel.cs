namespace SolstatProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<countieslocation> countieslocations { get; set; }
        public virtual DbSet<photocomponent> photocomponents { get; set; }
        public virtual DbSet<photosecondarycomponent> photosecondarycomponents { get; set; }
        public virtual DbSet<thermocomponent> thermocomponents { get; set; }
        public virtual DbSet<thermosecondarycomponent> thermosecondarycomponents { get; set; }
        public virtual DbSet<components_EE> componentsEntity{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<countieslocation>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<countieslocation>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<countieslocation>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<countieslocation>()
                .Property(e => e.iso2)
                .IsUnicode(false);

            modelBuilder.Entity<countieslocation>()
                .Property(e => e.iso3)
                .IsUnicode(false);

            modelBuilder.Entity<countieslocation>()
                .Property(e => e.province)
                .IsUnicode(false);

            modelBuilder.Entity<photocomponent>()
                .Property(e => e.panels)
                .IsUnicode(false);

            modelBuilder.Entity<photosecondarycomponent>()
                .Property(e => e.models)
                .IsUnicode(false);

            modelBuilder.Entity<photosecondarycomponent>()
                .Property(e => e.inverter)
                .IsUnicode(false);

            modelBuilder.Entity<photosecondarycomponent>()
                .Property(e => e.regulator)
                .IsUnicode(false);

            modelBuilder.Entity<photosecondarycomponent>()
                .Property(e => e.batery)
                .IsUnicode(false);

            modelBuilder.Entity<photosecondarycomponent>()
                .Property(e => e.C_bidirectional_meter)
                .IsUnicode(false);

            modelBuilder.Entity<photosecondarycomponent>()
                .Property(e => e.monitoring_system)
                .IsUnicode(false);

            modelBuilder.Entity<thermocomponent>()
                .Property(e => e.brand)
                .IsUnicode(false);

            modelBuilder.Entity<thermosecondarycomponent>()
                .Property(e => e.components)
                .IsUnicode(false);

            modelBuilder.Entity<thermosecondarycomponent>()
                .Property(e => e.comments)
                .IsUnicode(false);
            modelBuilder.Entity<components_EE>()
                .Property(e => e.codigo);
            modelBuilder.Entity<components_EE>()
                .Property(e => e.componente)
                .IsUnicode(false);
            modelBuilder.Entity<components_EE>()
                .Property(e => e.costo);
            modelBuilder.Entity<components_EE>()
                .Property(e => e.marcaComercial)
                .IsUnicode(false);
            modelBuilder.Entity<components_EE>()
                .Property(e => e.tipo)
                .IsUnicode(false);
            modelBuilder.Entity<components_EE>()
                .Property(e => e.tipoMoneda)
                .IsUnicode(false);
        }
    }
}
