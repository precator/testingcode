using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace ChecklistApplication.Models
{
    public class Seeder : DropCreateDatabaseIfModelChanges<ChecklistDb>
    {
        protected override void Seed(ChecklistDb context)
        {

            

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!Roles.RoleExists("SecurityPOC"))
                Roles.CreateRole("SecurityPOC");

            if (!WebSecurity.UserExists("SecurityPOC"))
                WebSecurity.CreateUserAndAccount(
                    "SecurityPOC",
                    "SecurityPOC"
                    );

            if (!Roles.GetRolesForUser("SecurityPOC").Contains("SecurityPOC"))
                Roles.AddUsersToRoles(new[] { "SecurityPOC" }, new[] { "SecurityPOC" });

            if (!WebSecurity.UserExists("precator"))
                WebSecurity.CreateUserAndAccount(
                    "precator",
                    "mkt8631"
                    );

            if (!Roles.GetRolesForUser("precator").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "precator" }, new[] { "Administrator" });



            /*var step = new List<Step>
            {
                new Step { StepName= "First Step", RoleName ="Darth Vader" },
                new Step { StepName= "Second Step", RoleName ="SecurityPoc" }
            };
            step.ForEach(u => context.Step.Add(u));
            context.SaveChanges();
            
            */

        }
    }
}