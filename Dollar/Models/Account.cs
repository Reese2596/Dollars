﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dollar.Models
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

        [StringLength(150)]
        [DataType(DataType.Password)]   //input => type password
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}