using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace TCache.EntityFramework.Repositories
{
    public abstract class TCacheRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TCacheDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected TCacheRepositoryBase(IDbContextProvider<TCacheDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class TCacheRepositoryBase<TEntity> : TCacheRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected TCacheRepositoryBase(IDbContextProvider<TCacheDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
