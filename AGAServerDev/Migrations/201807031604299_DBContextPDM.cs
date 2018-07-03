namespace AGAServerDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBContextPDM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PDM_ACCION",
                c => new
                    {
                        IdAccion = c.String(nullable: false, maxLength: 3, fixedLength: true, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 80, unicode: false),
                        Aplica = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.IdAccion);
            
            CreateTable(
                "dbo.PDM_OBSERVACION",
                c => new
                    {
                        IdObservacion = c.Int(nullable: false, identity: true),
                        IdParte = c.Int(nullable: false),
                        Observacion = c.String(nullable: false, maxLength: 150, unicode: false),
                        IdAccion = c.String(maxLength: 3, fixedLength: true, unicode: false),
                        FechaAprobacion = c.DateTime(storeType: "smalldatetime"),
                        UsuarioAprobacion = c.Byte(),
                    })
                .PrimaryKey(t => t.IdObservacion)
                .ForeignKey("dbo.PDM_ACCION", t => t.IdAccion)
                .ForeignKey("dbo.PDM_PARTE", t => t.IdParte)
                .Index(t => t.IdParte)
                .Index(t => t.IdAccion);
            
            CreateTable(
                "dbo.PDM_PARTE",
                c => new
                    {
                        IdParte = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        IdSucursal = c.String(nullable: false, maxLength: 3, fixedLength: true, unicode: false),
                        IdMaquinaria = c.String(nullable: false, maxLength: 12, fixedLength: true, unicode: false),
                        IdTipoImplemento = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        IdImplemento = c.String(nullable: false, maxLength: 12, fixedLength: true, unicode: false),
                        IdOperario = c.String(nullable: false, maxLength: 6, fixedLength: true, unicode: false),
                        IdTurno = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        IdEstado = c.String(maxLength: 2, fixedLength: true, unicode: false),
                        Situacion = c.Byte(),
                        FechaCreacion = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UsuarioCreacion = c.Short(nullable: false),
                        FechaModificacion = c.DateTime(storeType: "smalldatetime"),
                        UsuarioModificacion = c.Short(),
                    })
                .PrimaryKey(t => t.IdParte)
                .ForeignKey("dbo.PDM_TIPO_IMPLEMENTO", t => t.IdTipoImplemento)
                .ForeignKey("dbo.PDM_ESTADO", t => t.IdEstado)
                .Index(t => t.IdTipoImplemento)
                .Index(t => t.IdEstado);
            
            CreateTable(
                "dbo.PDM_CHECKLIST",
                c => new
                    {
                        IdCheckList = c.Int(nullable: false, identity: true),
                        IdParte = c.Int(nullable: false),
                        IdSistema = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        IdComponente = c.String(nullable: false, maxLength: 4, fixedLength: true, unicode: false),
                        Estado = c.Byte(nullable: false),
                        Situacion = c.Byte(),
                    })
                .PrimaryKey(t => t.IdCheckList)
                .ForeignKey("dbo.PDM_COMPONENTE", t => t.IdComponente)
                .ForeignKey("dbo.PDM_SISTEMA", t => t.IdSistema)
                .ForeignKey("dbo.PDM_PARTE", t => t.IdParte)
                .Index(t => t.IdParte)
                .Index(t => t.IdSistema)
                .Index(t => t.IdComponente);
            
            CreateTable(
                "dbo.PDM_COMPONENTE",
                c => new
                    {
                        IdComponente = c.String(nullable: false, maxLength: 4, fixedLength: true, unicode: false),
                        IdSistema = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IdComponente)
                .ForeignKey("dbo.PDM_SISTEMA", t => t.IdSistema)
                .Index(t => t.IdSistema);
            
            CreateTable(
                "dbo.PDM_SISTEMA",
                c => new
                    {
                        IdSistema = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 50, unicode: false),
                        IdTipoImplemento = c.String(maxLength: 2, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.IdSistema)
                .ForeignKey("dbo.PDM_TIPO_IMPLEMENTO", t => t.IdTipoImplemento)
                .Index(t => t.IdTipoImplemento);
            
            CreateTable(
                "dbo.PDM_TIPO_IMPLEMENTO",
                c => new
                    {
                        IdTipoImplemento = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IdTipoImplemento);
            
            CreateTable(
                "dbo.PDM_ESTADO",
                c => new
                    {
                        IdEstado = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        Descripcion = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.IdEstado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PDM_OBSERVACION", "IdParte", "dbo.PDM_PARTE");
            DropForeignKey("dbo.PDM_PARTE", "IdEstado", "dbo.PDM_ESTADO");
            DropForeignKey("dbo.PDM_CHECKLIST", "IdParte", "dbo.PDM_PARTE");
            DropForeignKey("dbo.PDM_SISTEMA", "IdTipoImplemento", "dbo.PDM_TIPO_IMPLEMENTO");
            DropForeignKey("dbo.PDM_PARTE", "IdTipoImplemento", "dbo.PDM_TIPO_IMPLEMENTO");
            DropForeignKey("dbo.PDM_COMPONENTE", "IdSistema", "dbo.PDM_SISTEMA");
            DropForeignKey("dbo.PDM_CHECKLIST", "IdSistema", "dbo.PDM_SISTEMA");
            DropForeignKey("dbo.PDM_CHECKLIST", "IdComponente", "dbo.PDM_COMPONENTE");
            DropForeignKey("dbo.PDM_OBSERVACION", "IdAccion", "dbo.PDM_ACCION");
            DropIndex("dbo.PDM_SISTEMA", new[] { "IdTipoImplemento" });
            DropIndex("dbo.PDM_COMPONENTE", new[] { "IdSistema" });
            DropIndex("dbo.PDM_CHECKLIST", new[] { "IdComponente" });
            DropIndex("dbo.PDM_CHECKLIST", new[] { "IdSistema" });
            DropIndex("dbo.PDM_CHECKLIST", new[] { "IdParte" });
            DropIndex("dbo.PDM_PARTE", new[] { "IdEstado" });
            DropIndex("dbo.PDM_PARTE", new[] { "IdTipoImplemento" });
            DropIndex("dbo.PDM_OBSERVACION", new[] { "IdAccion" });
            DropIndex("dbo.PDM_OBSERVACION", new[] { "IdParte" });
            DropTable("dbo.PDM_ESTADO");
            DropTable("dbo.PDM_TIPO_IMPLEMENTO");
            DropTable("dbo.PDM_SISTEMA");
            DropTable("dbo.PDM_COMPONENTE");
            DropTable("dbo.PDM_CHECKLIST");
            DropTable("dbo.PDM_PARTE");
            DropTable("dbo.PDM_OBSERVACION");
            DropTable("dbo.PDM_ACCION");
        }
    }
}
