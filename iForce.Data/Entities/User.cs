using System;
using System.Collections.Generic;
using System.Text;

namespace iForce.Data.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public int UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
