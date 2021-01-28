﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationMVC_2021.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class pubsEntities : DbContext
    {
        public pubsEntities()
            : base("name=pubsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<authors> authors { get; set; }
        public virtual DbSet<discounts> discounts { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<jobs> jobs { get; set; }
        public virtual DbSet<pub_info> pub_info { get; set; }
        public virtual DbSet<publishers> publishers { get; set; }
        public virtual DbSet<roysched> roysched { get; set; }
        public virtual DbSet<sales> sales { get; set; }
        public virtual DbSet<stores> stores { get; set; }
        public virtual DbSet<titleauthor> titleauthor { get; set; }
        public virtual DbSet<titles> titles { get; set; }
        public virtual DbSet<titleview> titleview { get; set; }
    
        public virtual ObjectResult<string> byroyalty(Nullable<int> percentage)
        {
            var percentageParameter = percentage.HasValue ?
                new ObjectParameter("percentage", percentage) :
                new ObjectParameter("percentage", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("byroyalty", percentageParameter);
        }
    
        public virtual ObjectResult<reptq1_Result> reptq1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<reptq1_Result>("reptq1");
        }
    
        public virtual ObjectResult<reptq2_Result> reptq2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<reptq2_Result>("reptq2");
        }
    
        public virtual ObjectResult<reptq3_Result> reptq3(Nullable<decimal> lolimit, Nullable<decimal> hilimit, string type)
        {
            var lolimitParameter = lolimit.HasValue ?
                new ObjectParameter("lolimit", lolimit) :
                new ObjectParameter("lolimit", typeof(decimal));
    
            var hilimitParameter = hilimit.HasValue ?
                new ObjectParameter("hilimit", hilimit) :
                new ObjectParameter("hilimit", typeof(decimal));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<reptq3_Result>("reptq3", lolimitParameter, hilimitParameter, typeParameter);
        }
    }
}
