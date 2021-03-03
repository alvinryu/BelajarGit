using API.Context;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Entity : class
        where Context : MyContext
    {
        private readonly MyContext myContext;
        private readonly DbSet<Entity> entities;
        
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<Entity>();
        }

        public IEnumerable<Entity> Get()
        {
            var result = entities.ToList();
            return result;
        }

        public Entity Get(Key key)
        {
            var result = entities.Find(key);
            return result;
        }

        public int Create(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Update(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            myContext.Entry(entity).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }

        public int Delete(Key key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("entity");
            }

            Entity entity = entities.Find(key);
            entities.Remove(entity);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}

