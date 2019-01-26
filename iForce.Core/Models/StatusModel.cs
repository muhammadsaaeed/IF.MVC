using CacheManager.Core;
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
    public class StatusModel
    {
        private static LookupService<UserStatus> statusLookupService = new LookupService<UserStatus>(new UserStatusLookup());
        public Dictionary<int, string> _status { get; private set; }

        public Dictionary<int, string> Status {
            get
            {
                return getStatusLookupDictionary();
            }
        }

        private static List<UserStatus> getStatusLookupList()
        {
            ObjectCache cache = MemoryCache.Default;

            List<UserStatus> userStatusLookup = cache["userStatusLookup"] as List<UserStatus>;

            if (userStatusLookup == null)
            {
                CacheItemPolicy itemPolicy = new CacheItemPolicy();
                itemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60);
                userStatusLookup = statusLookupService.GetList();
                cache["userStatusLookup"] = userStatusLookup;
            }

            return userStatusLookup;
        }

        private Dictionary<int, string> getStatusLookupDictionary()
        {
            var statuses = getStatusLookupList();
            _status = new Dictionary<int, string>();

            foreach (var status in statuses)
            {
                _status.Add(status.ID, status.Name);
            }
            return _status;
        }

    }
}