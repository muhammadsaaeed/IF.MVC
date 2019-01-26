using iForce.Data.Entities;
using iForce.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iForce.Data.Repositories
{
    public class UserStatusLookup: ILookup<UserStatus>
    {
        public UserStatus GetById(int id)
        {
            using (var db = new iForceDbContext())
            {
                return db.UserStatuses.Find(id);
            }
        }

        List<UserStatus> ILookup<UserStatus>.GetList()
        {
            using (var db = new iForceDbContext())
            {
                return db.UserStatuses.ToList();
            }
        }
    }
}
