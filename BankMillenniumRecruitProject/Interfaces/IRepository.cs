using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankMillenniumRecruitProject.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<T> Add(T entity);

        public Task Remove(long id);

        public Task Update(T entity);

        public Task<T> Get(long id);

        public Task<bool> IsExists(long id);

        public IQueryable<T> GetAll();
    }
}
