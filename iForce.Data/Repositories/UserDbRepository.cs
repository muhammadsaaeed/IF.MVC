using iForce.Data.Entities;
using iForce.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iForce.Core.Repositories
{
    public class UserDbRepository: IDisposable, IRepository<User>
    {
        private iForceDbContext db = new iForceDbContext();

        public User GetById(int id)
        {
            return db.Users.Include(x => x.UserRole)
                           .Include(x => x.UserStatus)
                           .Where(x=> x.ID == id).FirstOrDefault();
        }

        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public List<User> GetList(int maxRows, int currentPage, string sortBy, string sortOrder)
        {
            var userQueryable = getSortingOrder(sortBy, sortOrder);

            return userQueryable.Skip((currentPage - 1) * maxRows)
                                .Take(maxRows)
                                .Include(x=>x.UserRole)
                                .Include(x=>x.UserStatus).ToList();
        }

        private IQueryable<User> getSortingOrder(string sortBy, string sortOrder)
        {
            string sort = sortBy + " " + sortOrder;

            var userQueryable = db.Users.AsQueryable();

            if (sort == "ID ASC")
                userQueryable = userQueryable.OrderBy(x => x.ID);
            if (sort == "ID DESC")
                userQueryable = userQueryable.OrderByDescending(x => x.ID);

            else if (sort == "Name ASC")
                userQueryable = userQueryable.OrderBy(x => x.Name);
            else if (sort == "Name DESC")
                userQueryable = userQueryable.OrderByDescending(x => x.Name);

            else if (sort == "Role ASC")
                userQueryable = userQueryable.OrderBy(x => x.UserRole.Name);
            else if (sort == "Role DESC")
                userQueryable = userQueryable.OrderByDescending(x => x.UserRole.Name);

            else if (sort == "Status ASC")
                userQueryable = userQueryable.OrderBy(x => x.UserStatus.Name);
            else if (sort == "Status DESC")
                userQueryable = userQueryable.OrderByDescending(x => x.UserStatus.Name);

            else if (sort == "UpdateAt ASC")
                userQueryable = userQueryable.OrderBy(x => x.UpdateAt);
            else if (sort == "UpdateAt DESC")
                userQueryable = userQueryable.OrderByDescending(x => x.UpdateAt);

            return userQueryable;
        }

        public int TotalRecords()
        {
            return db.Users.Count();
        }

        public void DeleteById(int id)
        {
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
        }

        public void Update(User user)
        {
            db.Users.Attach(user);
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
