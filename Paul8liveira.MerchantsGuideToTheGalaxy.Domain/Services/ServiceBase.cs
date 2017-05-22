using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Repositories;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Services
{
    //Classe concreta, implementa metodos da interface base de forma generica
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        //Atraves de injecao de dependencia feita pelo Ninject, consigo acionar a camada de infra convertendo IRepositoryBase para Infra.Repositories.RepositoryBase
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
