﻿using ContactBookService.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core.Services
{
    public interface IDbService
    {
        IEnumerable<T> Get<T>() where T : Entity;
        Task<T> GetById<T>(int id) where T : Entity;
        IQueryable<T> QueryById<T>(int id) where T : Entity;
        IQueryable<T> Query<T>() where T : Entity;
        ServiceResult Create<T>(T entity) where T : Entity;
        ServiceResult Update<T>(T entity) where T : Entity;
        ServiceResult Delete<T>(T entity) where T : Entity;
        bool Exists<T>(int id) where T : Entity;
    }
}
