using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankMillenniumRecruitProject.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);

        public void Remove(T entity);

        public void Update(T entity);

        public T Get(long id);

        public IQueryable<T> GetAll();
    }
}
