using AutoMapper;
using Paul8liveira.MerchantsGuideToTheGalaxy.MVC.ViewModels;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<InputViewModel, Input>();
            Mapper.CreateMap<ResultViewModel, Result>();
        }
    }
}