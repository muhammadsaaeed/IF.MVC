using iForce.Data.Entities;
using iForce.Data.Interfaces;
using iForce.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iForce.Core.Services
{
    public class LookupService<T>
    {
        ILookup<T> lookup;

        public LookupService(ILookup<T> lookup)
        {
            this.lookup = lookup;
        }

        public List<T> GetList()
        {
            return lookup.GetList();
        }

        public T GetById(int id)
        {
            return lookup.GetById(id);
        }
    }
}
