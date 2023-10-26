using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMgmtSys.Data
{
    public class LoginDTO1
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^[a-zA-Z][-_.a-zA-Z0-9]*@gmail.com$", ErrorMessage = "Please enter a valid Gmail email address")]
        [StringLength(50, ErrorMessage = "Email should not exceed 50 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters")]
        public string Password { get; set; }
    }
}