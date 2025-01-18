using BlooDyWeb.Models;
using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Models.Stock;
using BlooDyWeb.Models.TransfusionModule;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Data
{
    public class BlooDyContext : DbContext
    {
        public BlooDyContext(DbContextOptions<BlooDyContext> options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<ExamenMedical>()
                .Property(p => p.Hemoglobine)
                .HasColumnType("decimal(4, 2)")
                .HasPrecision(4, 2);

            modelBuilder.Entity<ExamenMedical>()
                .Property(p => p.Poids)
                .HasColumnType("decimal(5, 2)")
                .HasPrecision(5, 2)
                .HasAnnotation("MinValue", 10.0)
                .HasAnnotation("MaxValue", 500.0);

            modelBuilder.Entity<ExamenMedical>()
                .Property(p => p.Pouls)
                .HasColumnType("decimal(5, 2)")
                .HasPrecision(5, 2)
                .HasAnnotation("MinValue", 10.0)
                .HasAnnotation("MaxValue", 1000.0);

            
        }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Donateur> Donateurs { get; set; }
        public DbSet<ExamenMedical> Dossiers { get; set; }
        public DbSet<Don> Dons { get; set; }
        public DbSet<Composante> Composantes { get; set; }
        public DbSet<TypeComposante> TypeComposantes { get; set; }
        public DbSet<Collecte> Collectes { get; set; }
        public DbSet<Centre> Centres { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }

        // MODULE DISTRIBUTION
        public DbSet<Chauffeur> Chauffeurs { get; set; }
        public DbSet<Demande> Demandes { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<InstitutionSante> InstitutionsSante { get; set; }
        public DbSet<LogDistribution> LogDistribution { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Transport> Transports { get; set; }

        // MODULE TRANSFUSION
        public DbSet<Beneficiaire> Beneficiaires { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Transfusion> Transfusions { get; set; }

        // REF TABLES
        public DbSet<Ville> Villes { get; set; }
        public DbSet<Arrondissement> Arrondissements { get; set; }
        public DbSet<Departement> Departements { get; set; }
    }
}
