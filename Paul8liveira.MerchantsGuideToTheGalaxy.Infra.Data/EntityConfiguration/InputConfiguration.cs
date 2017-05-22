using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Infra.Data.EntityConfiguration
{
    public class InputConfiguration : EntityTypeConfiguration<Input>
    {
        public InputConfiguration()
        {
            //Define pk
            HasKey(p => p.Id);

        }
    }
}