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
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Forgot_Pass> Forgot_Pass { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    
        public virtual ObjectResult<GET_FEEDBACK1_Result> GET_FEEDBACK1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GET_FEEDBACK1_Result>("GET_FEEDBACK1");
        }
    
        public virtual ObjectResult<VIEW_COURSES_Result> VIEW_COURSES()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VIEW_COURSES_Result>("VIEW_COURSES");
        }
    
        public virtual ObjectResult<View_Exams_Result> View_Exams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Exams_Result>("View_Exams");
        }
    
        public virtual ObjectResult<View_Results_ByExam_Result> View_Results_ByExam(Nullable<int> e_id)
        {
            var e_idParameter = e_id.HasValue ?
                new ObjectParameter("e_id", e_id) :
                new ObjectParameter("e_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Results_ByExam_Result>("View_Results_ByExam", e_idParameter);
        }
    
        public virtual ObjectResult<ViewAll_Results_ByExam_Result> ViewAll_Results_ByExam()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ViewAll_Results_ByExam_Result>("ViewAll_Results_ByExam");
        }
    
        public virtual ObjectResult<VIEW_COURSES_BYID_Result> VIEW_COURSES_BYID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VIEW_COURSES_BYID_Result>("VIEW_COURSES_BYID", idParameter);
        }
    
        public virtual ObjectResult<View_Exams_BYID_Result> View_Exams_BYID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Exams_BYID_Result>("View_Exams_BYID", idParameter);
        }
    }
}
