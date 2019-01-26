using iForce.Core.Services;
using iForce.Data.Entities;
using iForce.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace iForce.Core.Models
{
    public class RoleModel
    {
        private static LookupService<UserRole> userRoleService = new LookupService<UserRole>(new UserRoleLookup());
        public Dictionary<int, string> _roles { get; private set; }

        public Dictionary<int, string> Roles
        {
            get
            {
                return getRolesLookupDictionary();
            }
        }

        public static List<UserRole> GetRolesLookupList()
        {
            ObjectCache cache = MemoryCache.Default;

            List<UserRole> userRoleLookup = cache["userRoleLookup"] as List<UserRole>;

            if (userRoleLookup == null)
            {
                CacheItemPolicy itemPolicy = new CacheItemPolicy();
                itemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60);
                userRoleLookup = userRoleService.GetList();
                cache["userRoleLookup"] = userRoleLookup;
            }

            return userRoleLookup;
        }

        private Dictionary<int, string> getRolesLookupDictionary()
        {
            var roles = GetRolesLookupList();
            _roles = new Dictionary<int, string>();

            foreach (var role in roles)
            {
                _roles.Add(role.ID, role.Name);
            }
            return _roles;
        }

    }
}