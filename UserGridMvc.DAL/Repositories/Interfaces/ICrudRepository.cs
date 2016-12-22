﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UserGridMvc.Entity;

namespace UserGridMvc.DAL.Repositories.Interfaces
{

    public interface ICrudRepository<TEntity> where TEntity : IdEntity, IEntity
    {
        // add an entity to DB
        void Add(TEntity entity);

        // add range of entities to DB
        void Add(IEnumerable<TEntity> range);
        
        // get an entity from DB using ID
        TEntity GetById(Guid id);
        
        // get an entity from DB using predicate
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        
        // delete entity from DB by Id
        void Delete(Guid id);

        // delete particular entity
        void Delete(TEntity entity);

        // activate entity from DB by Id
        void Activate(Guid id);
        
        // activate particular entity
        void Activate(TEntity entity);
        
        // update an entity in DB
        void Update(TEntity entity);
        
        // get all entities from DB
        IQueryable<TEntity> GetAllEntities();
        
        // save changes once operation has been completed
        void SaveChanges();

    }
}