using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Interfaces.Repositories
{
    //Interface de repositorio base. Contrato de crud basico
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);            
        void Update(TEntity obj);
        void Remove(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
