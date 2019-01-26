using iForce.Data.Entities;
using iForce.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iForce.Data.Repositories
{
    public class UserRoleLookup : ILookup<UserRole>
    {
        public UserRole GetById(int id)
        {
            using (var db = new iForceDbContext())
            {
                return db.UserRoles.Find(id);
            }
        }

        List<UserRole> ILookup<UserRole>.GetList()
        {
            using (var db = new iForceDbContext())
            {
                return db.UserRoles.ToList();
            }
        }
    }
}
