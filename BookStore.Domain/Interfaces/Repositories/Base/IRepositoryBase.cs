﻿using System.Linq.Expressions;

namespace BookStore.Domain.Interfaces.Repositories.Base;

public interface IRepositoryBase<TEntity, Tid>
    where TEntity : class
    where Tid : struct
{
    IQueryable<TEntity> ListBy(Expression<Func<TEntity, bool>> where,
        params Expression<Func<TEntity, object>>[] includeProperties);

    IQueryable<TEntity> ListAndOrderBy<TKey>(Expression<Func<TEntity, bool>> where,
        Expression<Func<TEntity, TKey>> order, bool ascending = true,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity GetBy(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties);

    bool Exist(Func<TEntity, bool> where);

    IQueryable<TEntity> List(params Expression<Func<TEntity, object>>[] includeProperties);

    IQueryable<TEntity> ListOrderBy<TKey>(Expression<Func<TEntity, TKey>> order, bool ascending = true,
        params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity GetById(Tid id, params Expression<Func<TEntity, object>>[] includeProperties);

    TEntity Add(TEntity entity);

    TEntity Edit(TEntity entity);

    bool Remove(TEntity entity);

    IEnumerable<TEntity> AddList(IEnumerable<TEntity> entities);
}
