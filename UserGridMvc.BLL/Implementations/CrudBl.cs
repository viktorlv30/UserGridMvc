﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UserGridMvc.BLL.Interface;
using UserGridMvc.DAL.Repositories.Interfaces;
using UserGridMvc.Entity;

namespace UserGridMvc.BLL.Implementations
{
    public class CrudBl<TRepository, TEntity> : ICrudBl<TEntity>
        where TEntity : IdEntity, IEntity
        where TRepository : class, ICrudRepository<TEntity>
    {
        protected TRepository Repository { get; private set; }

        public CrudBl(TRepository repository)
        {
            Repository = repository;
        }

        //get any entity from db by predicate
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.Get(predicate);
        }

        //get all entities from db by type
        public IQueryable<TEntity> GetAll()
        {
            return Repository.GetAllEntities();
        }
        //get an entity from db by id
        public TEntity GetById(Guid id)
        {
            return Repository.GetById(id);
        }
        //insert an entity to db
        public void Insert(TEntity entity)
        {
            Repository.Add(entity);
        }
        //insert entities array to db
        public void InsertRange(IEnumerable<TEntity> range)
        {
            Repository.Add(range);
        }
        //mark entity as deleted
        public void Remove(Guid id)
        {
            Repository.Delete(id);
        }
        //save Context
        public void SaveChanges()
        {
            Repository.SaveChanges();
        }
        //mark entity IsDeleted = false
        public void Activate(Guid id)
        {
            Repository.Activate(id);
        }

        //update if exist or create if not exist
        public void Update(TEntity entity)
        {
            Repository.Update(entity);
        }
    }
}