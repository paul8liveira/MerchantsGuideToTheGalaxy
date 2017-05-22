using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using Paul8liveira.MerchantsGuideToTheGalaxy.Infra.Data.EntityConfiguration;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Infra.Data.Context
{
    public class MerchantsGuideToTheGalaxyContext : DbContext
    {
        //Constutor da classe enviando contexto para classe DBContext
        public MerchantsGuideToTheGalaxyContext() : base("DefaultConnection") { }

        //DbSets
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Result> Results { get; set; }

        //Sobrescrevendo OnModelCreating para redefinir alguns padroes de criacao da base de dados atraves do Update-Database do Migrations
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Nao utiliza padrao de pluralizacao
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Define que se houver campo na entidade com nome da tabela + Id, define como chave primaria (Ex: InputId)
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //padroniza todos os campos string para varchar(100)
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //add configuracoes especificas de cada entidade
            modelBuilder.Configurations.Add(new InputConfiguration());
            modelBuilder.Configurations.Add(new ResultConfiguration());
        }

        //Sobrescreve SaveChanges para sempre salvar o campo CreatedAt automaticamente
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
