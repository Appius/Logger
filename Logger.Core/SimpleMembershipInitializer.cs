using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Security;
using Logger.Core.Models;
using WebMatrix.WebData;

namespace Logger.Core
{
    public class SimpleMembershipInitializer
    {
        public SimpleMembershipInitializer()
        {
            try
            {
                using (var context = new DBContext())
                {
                    if (!context.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        ((IObjectContextAdapter) context).ObjectContext.CreateDatabase();
                    }
                }

                WebSecurity.InitializeDatabaseConnection("AzureConnection", "UserProfile", "Id", "Email", true);

                if (!Roles.RoleExists("Admin"))
                {
                    Roles.CreateRole("Admin");
                }
                if (!Roles.RoleExists("User"))
                {
                    Roles.CreateRole("User");
                }

                if (!WebSecurity.UserExists("Administrator"))
                {
                    WebSecurity.CreateUserAndAccount(
                        "Administrator",
                        "qwerty",
                        new { FirstName = "Admin", LastName = "1", Birthday = "10.10.2010"},
                        false
                    );
                }

                if (!Roles.GetRolesForUser("Administrator").Contains("Admin"))
                {
                    Roles.AddUsersToRoles(new[] { "Administrator" }, new[] { "Admin" });
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588",
                    ex);
            }
        }
    }
}