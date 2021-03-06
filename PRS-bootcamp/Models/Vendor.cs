﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRS_bootcamp.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Index(IsUnique = true)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(5)]
        public string Zip { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public bool IsPreapproved { get; set; }

        public void Copy(Vendor vendor)
        {
            Code = vendor.Code;
            Name = vendor.Name;
            Address = vendor.Address;
            City = vendor.City;
            State = vendor.State;
            Zip = vendor.Zip;
            Phone = vendor.Phone;
            Email = vendor.Email;
            IsPreapproved = vendor.IsPreapproved;
        }
    }
}