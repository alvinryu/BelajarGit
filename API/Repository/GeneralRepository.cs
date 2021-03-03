using API.Context;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository {
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

        public int Create(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                entities.Add(entity);
                var result = myContext.SaveChanges();
                return result;
            }
        }

        public int Delete(Key key)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                Entity entity = entities.Find(key);
                entities.Remove(entity);
                var result = myContext.SaveChanges();
                return result;
            }
        }

        public IEnumerable<Entity> Get()
        {
            return entities.AsEnumerable();
        }

        public Entity Get(Key key)
        {
            return entities.Find(key);
        }

        public int Update(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                try
                {
                    myContext.Entry(entity).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    return result;
                }

                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}