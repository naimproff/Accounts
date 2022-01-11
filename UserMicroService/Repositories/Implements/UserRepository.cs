using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserMicroService.Contexts;
using UserMicroService.Repositories.Interfaces;

namespace UserMicroService.Repositories.Implements
{
    public class UserRepository<TEntity> : IUserRepository<TEntity> where TEntity: class
    {
        private readonly UserDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }


        public void Insert(TEntity obj)
        {
            _dbSet.Add(obj);
            Save();
        }

        public void Update(TEntity obj)
        {
            _dbSet.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            TEntity obj = _dbSet.Find(id);
            _dbSet.Remove(obj);
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }




        public void Save()
        {
            _dbContext.SaveChanges();
        }
        
    }

}
