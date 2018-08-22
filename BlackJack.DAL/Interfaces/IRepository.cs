﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Insert(T item);
        Task Delete(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task Update(T item);
    }
}
