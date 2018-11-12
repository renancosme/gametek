﻿using MrGreen.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MrGreen.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);

        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(Guid id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}
