﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRS_bootcamp.Models
{
    public class PRS_bootcampContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PRS_bootcampContext() : base("name=PRS_bootcampContext")
        {
        }

        public System.Data.Entity.DbSet<PRS_bootcamp.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<PRS_bootcamp.Models.Vendor> Vendors { get; set; }

        public System.Data.Entity.DbSet<PRS_bootcamp.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<PRS_bootcamp.Models.PurchaseRequest> PurchaseRequests { get; set; }

        public System.Data.Entity.DbSet<PRS_bootcamp.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<PRS_bootcamp.Models.PurchaseRequestLineItem> PurchaseRequestLineItems { get; set; }
    }
}
