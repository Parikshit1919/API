﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace H_API.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Online_examEntities : DbContext
    {
        public Online_examEntities()
            : base("name=Online_examEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Forgot_Pass> Forgot_Pass { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    
        public virtual ObjectResult<VIEW_COURSES_Result> VIEW_COURSES()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VIEW_COURSES_Result>("VIEW_COURSES");
        }
    
        public virtual ObjectResult<GET_FEEDBACK_Result> GET_FEEDBACK()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GET_FEEDBACK_Result>("GET_FEEDBACK");
        }
    }
}
