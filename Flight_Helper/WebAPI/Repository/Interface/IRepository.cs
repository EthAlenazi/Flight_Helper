﻿using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Repository.Implementation;

namespace WebAPI.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}

