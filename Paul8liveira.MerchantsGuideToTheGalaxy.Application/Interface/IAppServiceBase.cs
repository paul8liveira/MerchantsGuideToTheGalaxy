using System.Collections.Generic;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Application.Interface
{
    //Interface de repositorio base. Contrato de crud basico
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
