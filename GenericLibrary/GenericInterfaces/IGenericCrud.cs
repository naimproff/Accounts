using System.Collections.Generic;

namespace GenericLibrary.GenericInterfaces
{
    public interface IGenericCrud<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);
        void Save();
    }
}
