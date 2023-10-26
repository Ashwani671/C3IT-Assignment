using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMgmtSys.Data
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^[a-zA-Z][-_.a-zA-Z0-9]*@gmail.com$", ErrorMessage = "Please enter a valid Gmail email address")]
        [StringLength(50, ErrorMessage = "Email should not exceed 50 characters")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters")]
        [RegularExpression(@"^[a-zA-Z][-_.a-zA-Z0-9]*$", ErrorMessage = "Please enter a valid password")]
        public string password { get; set; }
    }
}