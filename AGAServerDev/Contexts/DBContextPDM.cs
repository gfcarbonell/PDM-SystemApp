namespace AGAServerDev.Contexts
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContextPDM : DbContext
    {
        public DBContextPDM()
            : base("name=DBContextPDM")
        {
        }

        public virtual DbSet<PDM_ACCION> PDM_ACCION { get; set; }
        public virtual DbSet<PDM_CHECKLIST> PDM_CHECKLIST { get; set; }
        public virtual DbSet<PDM_COMPONENTE> PDM_COMPONENTE { get; set; }
        public virtual DbSet<PDM_ESTADO> PDM_ESTADO { get; set; }
        public virtual DbSet<PDM_OBSERVACION> PDM_OBSERVACION { get; set; }
        public virtual DbSet<PDM_PARTE> PDM_PARTE { get; set; }
        public virtual DbSet<PDM_SISTEMA> PDM_SISTEMA { get; set; }
        public virtual DbSet<PDM_TIPO_IMPLEMENTO> PDM_TIPO_IMPLEMENTO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PDM_ACCION>()
                .Property(e => e.IdAccion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_ACCION>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PDM_CHECKLIST>()
                .Property(e => e.IdSistema)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_CHECKLIST>()
                .Property(e => e.IdComponente)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_COMPONENTE>()
                .Property(e => e.IdComponente)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_COMPONENTE>()
                .Property(e => e.IdSistema)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_COMPONENTE>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PDM_COMPONENTE>()
                .HasMany(e => e.PDM_CHECKLIST)
                .WithRequired(e => e.PDM_COMPONENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PDM_ESTADO>()
                .Property(e => e.IdEstado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_ESTADO>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PDM_OBSERVACION>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<PDM_OBSERVACION>()
                .Property(e => e.IdAccion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_PARTE>()
                .Property(e => e.IdSucursal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_PARTE>()
                .Property(e => e.IdMaquinaria)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_PARTE>()
                .Property(e => e.IdTipoImplemento)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_PARTE>()
                .Property(e => e.IdImplemento)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_PARTE>()
                .Property(e => e.IdOperario)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_PARTE>()
                .Property(e => e.IdTurno)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_PARTE>()
                .Property(e => e.IdEstado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_PARTE>()
                .HasMany(e => e.PDM_CHECKLIST)
                .WithRequired(e => e.PDM_PARTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PDM_PARTE>()
                .HasMany(e => e.PDM_OBSERVACION)
                .WithRequired(e => e.PDM_PARTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PDM_SISTEMA>()
                .Property(e => e.IdSistema)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_SISTEMA>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PDM_SISTEMA>()
                .Property(e => e.IdTipoImplemento)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_SISTEMA>()
                .HasMany(e => e.PDM_CHECKLIST)
                .WithRequired(e => e.PDM_SISTEMA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PDM_SISTEMA>()
                .HasMany(e => e.PDM_COMPONENTE)
                .WithRequired(e => e.PDM_SISTEMA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PDM_TIPO_IMPLEMENTO>()
                .Property(e => e.IdTipoImplemento)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PDM_TIPO_IMPLEMENTO>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PDM_TIPO_IMPLEMENTO>()
                .HasMany(e => e.PDM_PARTE)
                .WithRequired(e => e.PDM_TIPO_IMPLEMENTO)
                .WillCascadeOnDelete(false);
        }
    }
}
