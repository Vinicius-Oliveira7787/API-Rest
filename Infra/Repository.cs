using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;

namespace Infra
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public void Add(T entity)
        {
            using (var db = new APIContext())
            {
                db.Add<T>(entity);
                db.SaveChanges();
            }
        }

        public T Get(Func<T, bool> predicate)
        {
            using (var db = new APIContext())
            {
                return db.Find<T>(predicate);
            }
        }

        public T Get(Guid id)
        {
            using (var db = new APIContext())
            {
                Func<Entity, bool> findById = x => x.Id == id;
                return db.Find<T>(findById);
            }
        }

        public List<T> GetAll()
        {
            using (var db = new APIContext())
            {
                return db.Set<T>().ToList();
            }
        }
    }
}
