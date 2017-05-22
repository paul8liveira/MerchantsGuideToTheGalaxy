using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Repositories;
using Paul8liveira.MerchantsGuideToTheGalaxy.Infra.Data.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Infra.Data.Repositories
{
    //Classe concreta, implementa metodos da interface base de forma generica
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected MerchantsGuideToTheGalaxyContext Db = new MerchantsGuideToTheGalaxyContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
