﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public T Get(int id);
    }
}
