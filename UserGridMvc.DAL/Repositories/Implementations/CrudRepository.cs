using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity;

namespace UserGridMvc.DAL.Repositories.Implementations
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : IdEntity, IEntity
    {
        protected UserGridDbContext ContextDb { get; } = new UserGridDbContext();

        // add an entity to the DB
        public virtual void Add(TEntity entity)
        {
            ContextDb.Set<TEntity>().Add(entity);
            SaveChanges();
        }

        // add range of entities to the DB
        public virtual void Add(IEnumerable<TEntity> range)
        {
            ContextDb.Set<TEntity>().AddRange(range);
            SaveChanges();
        }

        // get a entity from the DB by Id
        public virtual TEntity GetById(Guid id)
        {
            return ContextDb.Set<TEntity>().Find(id);
        }

        // get by predicate
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return ContextDb.Set<TEntity>().Where(predicate);
        }

        // delete an entity by ID
        public virtual void Delete(Guid id)
        {
            Delete(GetById(id));
        }

        // delete an entity itself
        public virtual void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        // activate inactive entity
        public void Activate(Guid id)
        {
            Activate(GetById(id));
        }

        // activate an entity itself
        public void Activate(TEntity entity)
        {
            entity.IsDeleted = false;
            Update(entity);
        }

        // update an entity
        public virtual void Update(TEntity entity)
        {
            ContextDb.Set<TEntity>().AddOrUpdate<TEntity>(entity);
            SaveChanges();
        }

        // get all entities from the DB
        public virtual IQueryable<TEntity> GetAllEntities()
        {
            return ContextDb.Set<TEntity>();
        }

        // save changes after performing an operation
        public virtual void SaveChanges()
        {
            try
            {
                ContextDb.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
        }
    }
}