using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iForce.Core.Models
{
    public class UserListModel
    {
        public IEnumerable<UserViewModel> UserList { get; set; }
        public Pagination Pagination { get; set; }
        public Message Notification = null;
        public UserListModel()
        {
            Pagination = new Pagination();
        }
    }
}