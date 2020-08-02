using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dollars.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        [StringLength(60)]
        /// <summary>
        /// First and last name
        /// </summary>
        public string FullName { get; set; }

        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.Password)]   //input => type password
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }


    public class AdminAccount : Account
    {
        public string BirthDay { get; set; }
    }
}
