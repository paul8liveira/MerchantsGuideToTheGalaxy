using AutoMapper;
using Paul8liveira.MerchantsGuideToTheGalaxy.MVC.ViewModels;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Input, InputViewModel>();
            Mapper.CreateMap<Result, ResultViewModel>();
        }
    }
}