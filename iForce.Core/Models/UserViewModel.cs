using iForce.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iForce.Core.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        [StringLength(maximumLength: 50, ErrorMessage ="Maximum allowed length is 50 characters")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        [DisplayName("Role")]
        public int UserRoleId { get; set; }
        public string RoleString { get; private set; }

        [DisplayName("Updated At")]
        [DisplayFormat(DataFormatString = "{0:dd MMM, yyyy HH:mm}")]
        public DateTime UpdateAt { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        [DisplayName("Status")]
        public int UserStatusId { get; set; }
        public string StatusString { get; private set; }

        public Dictionary<int, string> RolesLookup { get; }
        public Dictionary<int, string> StatusesLookup { get; }

        public UserViewModel()
        {
            this.RolesLookup = new RoleModel().Roles;
            this.StatusesLookup = new StatusModel().Status;

        }
    }
}