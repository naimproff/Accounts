using GenericLibrary.GenericInterfaces;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroService.Repositories.Interfaces
{
    public interface IUserRepository<TEntity> : IGenericCrud<TEntity> where TEntity: class
    {

    }
}
