using ContosoUniversity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using WebBase.Areas.Identity.Data;

namespace WebBase
{
    public static class UsersDbInitializer
    {
        public static void Initialize(Data.UsersRolesDB context, UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.UserRoles.Count() < 3)
            {
                //return;   // DB has been seeded
                rm.CreateAsync(new IdentityRole("Administrator"));
                rm.CreateAsync(new IdentityRole("Professor"));
                rm.CreateAsync(new IdentityRole("Applicant"));
            }
            // may not want to do this till the end
            context.SaveChanges();

            var users = new TAUser[]
                {
            new TAUser{UserName="Carson Alexander", Email="u0000000@utah.edu", Id="u0000000"},
            new TAUser{UserName="Gytis Barzdukas", Email="u0000001@utah.edu", Id="u0000001"},
            new TAUser{UserName="Yan Li", Email="u0000001@utah.edu", Id="u0000001"},
            new TAUser{UserName="Peggy Justice", Email="u0000001@utah.edu", Id="u0000001"},
            new TAUser{UserName="Laura Norman", Email="u0000001@utah.edu", Id="u0000001"},
            new TAUser{UserName="Nono Olivetto", Email="u0000001@utah.edu", Id="u0000001"},
            new TAUser{UserName="Professor", Email="professor@utah.edu", Id="u0000001"},
            new TAUser{UserName="Administrator", Email="admin@utah.edu", Id="u0000001"},

                };

            //poor security, easy to test, all passwords are the same as the given username
            foreach (TAUser u in users)
            {
                um.CreateAsync(u, u.UserName);
                if (u.UserName == "Professor")
                {
                    um.AddToRoleAsync(u, "Professor");
                }
                else if (u.UserName == "Administrator")
                {
                    um.AddToRoleAsync(u, "Administrator");
                }
                else
                {
                    um.AddToRoleAsync(u, "Applicant");
                }
                
            }
            context.SaveChanges();
        }
    }
}