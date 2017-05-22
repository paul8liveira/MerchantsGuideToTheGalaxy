using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Infra.Data.EntityConfiguration
{
    public class ResultConfiguration : EntityTypeConfiguration<Result>
    {
        public ResultConfiguration()
        { 
            //Define pk
            HasKey(p => p.Id);

            //Define fk
            HasRequired(p => p.Input)
                .WithMany()
                .HasForeignKey(p => p.InputId);

            //define tamanho varchar(500)
            Property(p => p.Translation)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
