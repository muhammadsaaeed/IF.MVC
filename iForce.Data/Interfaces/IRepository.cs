using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iForce.Data.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T item);
        List<T> GetList(int maxRows, int currentPage, string sortBy, string sortOrder);
        int TotalRecords();
        void DeleteById(int id);
        void Update(T user);
        T GetById(int id);
    }
}
