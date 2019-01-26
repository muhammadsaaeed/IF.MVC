using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iForce.Data.Interfaces
{
    public interface ILookup<T>
    {
        List<T> GetList();
        T GetById(int id);
    }
}
