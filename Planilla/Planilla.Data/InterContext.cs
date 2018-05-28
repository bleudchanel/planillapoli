using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Planilla.Business.Entities;

namespace Planilla.Data
{
    public class PlanillaContext : DbContext
    {
        public PlanillaContext()
            : base("name=Planilla")
        {
            Database.SetInitializer<PlanillaContext>(null);
        }

        public DbSet<AporteEmpleador> AporteEmpleadorSet { get; set; }
     //   public DbSet<EstructuraOperacion> EstructuraOperacionSet { get; set; }
        public DbSet<AreaAnalisis> AreaAnalisisSet { get; set; }
        public DbSet<AreaLaboratorio> AreaLaboratorioSet { get; set; }
        public DbSet<AreaServicio> AreaServicioSet { get; set; }
        public DbSet<Cargo> CargoSet { get; set; }
        public DbSet<DiasLaborables> DiasLaborablesSet { get; set; }
        public DbSet<Especialidad> EspecialidadSet { get; set; }
        public DbSet<FondoPensiones> FondoPensionesSet { get; set; }
        public DbSet<Medico> MedicoSet { get; set; }
        public DbSet<Personal> PersonalSet { get; set; }
        public DbSet<PlanillaRemuneracion> PlanillaRemuneracionSet { get; set; }
        public DbSet<Procedimiento> ProcedimientoSet { get; set; }
        public DbSet<TablaAnalisis> TablaAnalisisSet { get; set; }
        public DbSet<TablaAnalisisVR> TablaAnalisisVRSet { get; set; }
        public DbSet<Ubigeo> UbigeoSet { get; set; }
        public DbSet<Vacaciones> VacacionesSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<AporteEmpleador>().HasKey<int>(e => e.IdAporteEmpleador).Ignore(e => e.EntityId);
            modelBuilder.Entity<AreaAnalisis>().HasKey<int>(e => e.IdAreaAnalisis).Ignore(e => e.EntityId);
            modelBuilder.Entity<AreaLaboratorio>().HasKey<int>(e => e.IdAreaLaboratorio).Ignore(e => e.EntityId);
            modelBuilder.Entity<AreaServicio>().HasKey<int>(e => e.IdAreaServicio).Ignore(e => e.EntityId);
            modelBuilder.Entity<Cargo>().HasKey<int>(e => e.IdCargo).Ignore(e => e.EntityId);
            modelBuilder.Entity<DiasLaborables>().HasKey<int>(e => e.IdDiasLaborables).Ignore(e => e.EntityId);
            modelBuilder.Entity<Especialidad>().HasKey<int>(e => e.IdEspecialidad).Ignore(e => e.EntityId);
            modelBuilder.Entity<FondoPensiones>().HasKey<int>(e => e.IdFondoPen).Ignore(e => e.EntityId);
            modelBuilder.Entity<Medico>().HasKey<int>(e => e.IdMedico).Ignore(e => e.EntityId);
            modelBuilder.Entity<Personal>().HasKey<int>(e => e.IdPersonal).Ignore(e => e.EntityId);
            modelBuilder.Entity<PlanillaRemuneracion>().HasKey<int>(e => e.IdPlanilla).Ignore(e => e.EntityId);
            modelBuilder.Entity<Procedimiento>().HasKey<int>(e => e.IdProcedimiento).Ignore(e => e.EntityId);
            modelBuilder.Entity<TablaAnalisis>().HasKey<int>(e => e.IdAnalisis).Ignore(e => e.EntityId);
            modelBuilder.Entity<TablaAnalisisVR>().HasKey<int>(e => e.IdValReferencial).Ignore(e => e.EntityId);
            modelBuilder.Entity<Ubigeo>().HasKey<int>(e => e.IdUbigeo).Ignore(e => e.EntityId);
            modelBuilder.Entity<Vacaciones>().HasKey<int>(e => e.IdVacaciones).Ignore(e => e.EntityId);

            modelBuilder.Entity<PlanillaRemuneracion>().Ignore(e => e.NombrePersona);
            modelBuilder.Entity<PlanillaRemuneracion>().Ignore(e => e.VacacionesPeriodo);
            modelBuilder.Entity<PlanillaRemuneracion>().Ignore(e => e.ApellidoMaterno);
            modelBuilder.Entity<PlanillaRemuneracion>().Ignore(e => e.ApellidoPaterno);
            modelBuilder.Entity<PlanillaRemuneracion>().Ignore(e => e.Nombre);
            modelBuilder.Entity<PlanillaRemuneracion>().Ignore(e => e.CUSPP);
            modelBuilder.Entity<PlanillaRemuneracion>().Ignore(e => e.Dni);
            modelBuilder.Entity<PlanillaRemuneracion>().Ignore(e => e.AFP);


            modelBuilder.Entity<PlanillaRemuneracion>().Property(e => e.PorApoObl).HasPrecision(18, 4);
            modelBuilder.Entity<PlanillaRemuneracion>().Property(e => e.PorComVar).HasPrecision(18, 4);
            modelBuilder.Entity<PlanillaRemuneracion>().Property(e => e.PorPriSeg).HasPrecision(18, 4);
            modelBuilder.Entity<PlanillaRemuneracion>().Property(e => e.PorONP).HasPrecision(18, 4);
            modelBuilder.Entity<PlanillaRemuneracion>().Property(e => e.PorSCTR).HasPrecision(18, 4);
            //modelBuilder.Entity<PlanillaRemuneracion>().Property(e => e.PorApoObl).HasColumnType("decimal(18,4)");
            //modelBuilder.Entity<PlanillaRemuneracion>().Property(e => e.PorComVar).HasColumnType("decimal(18,4)");
            //modelBuilder.Entity<PlanillaRemuneracion>().Property(e => e.PorPriSeg).HasColumnType("decimal(18,4)");
            //modelBuilder.Entity<PlanillaRemuneracion>().Property(e => e.PorONP).HasColumnType("decimal(18,4)");
            //modelBuilder.Entity<PlanillaRemuneracion>().Property(e => e.PorSCTR).HasColumnType("decimal(18,4)");
            //modelBuilder.Entity<CatalogoSistema>().ToTable("ws_CatalogoSistema");
            //modelBuilder.Entity<Log>().ToTable("ws_LogBCP");
            //modelBuilder.Entity<Operacion>().ToTable("Operacion");
            //modelBuilder.Entity<OperacionSistema>().ToTable("ws_OperacionSistema");
            //modelBuilder.Entity<Rede>().ToTable("rede");
            //modelBuilder.Entity<RedeWs>().ToTable("redeWS");
            //modelBuilder.Entity<Rehe>().ToTable("rehe");
            //modelBuilder.Entity<ReheWs>().ToTable("reheWS");
        }
    }
}
