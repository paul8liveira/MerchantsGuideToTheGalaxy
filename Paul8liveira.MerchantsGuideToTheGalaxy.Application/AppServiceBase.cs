using Paul8liveira.MerchantsGuideToTheGalaxy.Application.Interface;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Application
{
    //Classe concreta, implementa metodos da interface base de forma generica
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        //Atraves de injecao de dependencia feita pelo Ninject, consigo acionar a camada de dominio convertendo IServiceBase para Domain.Services.ServiceBase
        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
