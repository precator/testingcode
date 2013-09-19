using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChecklistApplication.Models
{
    public class Checklist
    {
        public int ChecklistID { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string DepartingOrganization { get; set; }
        public string NewOrganization { get; set; }
        public string ForwardingAddress { get; set; }
        public string GregTest { get; set; }
        public UserProfile UserID { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public enum WorkFlowStatus
    {
        Signed = 0,
        NotAvailable = 1
    }
    public class Workflow
    {
        public int WorkflowID { get; set; }
        public int ChecklistID { get; set; }
        public int StepID { get; set; }
        public int UserProfileID { get; set; }
        public int WorkFlowStatusId { get; set; }
        public virtual Checklist Checklist { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual Step Step { get; set; }
        public virtual WorkFlowStatus WorkFlowStatus { get; set; }

    }

    public class Step
    {
        public int StepID { get; set; }
        public string StepName { get; set; }
        public string RoleName { get; set; }
        
    }
    public class ChecklistDb : DbContext
    {
        
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<Step> Step { get; set; }
       
       
    }
}