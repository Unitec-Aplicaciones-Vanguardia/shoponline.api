using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using shoponline.Core.Entities;
using shoponline.Core.Interfaces;

namespace shoponline.Infrastructure.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;

        public EntityFrameworkRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _shopOnlineDbContext.Set<T>().ToList();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _shopOnlineDbContext.Set<T>().Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _shopOnlineDbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }
    }
}
