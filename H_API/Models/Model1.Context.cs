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
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual ObjectResult<GET_FEEDBACK1_Result> GET_FEEDBACK1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GET_FEEDBACK1_Result>("GET_FEEDBACK1");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<View_Analytics_Result> View_Analytics()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Analytics_Result>("View_Analytics");
        }
    
        public virtual ObjectResult<VIEW_COURSES_Result> VIEW_COURSES()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VIEW_COURSES_Result>("VIEW_COURSES");
        }
    
        public virtual ObjectResult<VIEW_COURSES_BYID_Result> VIEW_COURSES_BYID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VIEW_COURSES_BYID_Result>("VIEW_COURSES_BYID", idParameter);
        }
    
        public virtual ObjectResult<View_Exams_Result> View_Exams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Exams_Result>("View_Exams");
        }
    
        public virtual ObjectResult<View_Exams_BYID_Result> View_Exams_BYID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Exams_BYID_Result>("View_Exams_BYID", idParameter);
        }
    
        public virtual ObjectResult<View_Questions_ByExam_Result> View_Questions_ByExam(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Questions_ByExam_Result>("View_Questions_ByExam", idParameter);
        }
    
        public virtual ObjectResult<View_Questions_ByID_Result> View_Questions_ByID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Questions_ByID_Result>("View_Questions_ByID", idParameter);
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
    
        public virtual ObjectResult<View_Results_ByStudent_Result> View_Results_ByStudent(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Results_ByStudent_Result>("View_Results_ByStudent", idParameter);
        }
    
        public virtual ObjectResult<View_Results_ByEmail_Result> View_Results_ByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Results_ByEmail_Result>("View_Results_ByEmail", emailParameter);
        }
    
        public virtual ObjectResult<View_Student_ByEmail_Result> View_Student_ByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<View_Student_ByEmail_Result>("View_Student_ByEmail", emailParameter);
        }
    }
}
