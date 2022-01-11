using GenericLibrary.GenericInterfaces;


namespace UserMicroService.Repositories.Interfaces
{
    public interface IUserRepository<TEntity> : IGenericCrud<TEntity> where TEntity: class
    {

    }
}
