﻿using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMS.Interface
{
    public interface IMongoDbRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(string id);

        Task CreateAsync(T entity); 

        Task UpdateAsync(string id, T entity);

        Task DeleteAsync(string id);


    }
}
