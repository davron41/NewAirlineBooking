﻿using NewAirlineBooking.Domain.Common;

namespace NewAirlineBooking.Domain.Interfaces;
public interface IRepositoryBase<TEntity> where TEntity : EntityBase
{
    List<TEntity> GetAll();
    TEntity GetById(int id);
    TEntity Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
    bool Exists(int id);
}
