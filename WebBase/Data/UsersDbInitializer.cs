using ContosoUniversity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebBase.Areas.Identity.Data;

namespace WebBase
{
    public static class UsersDbInitializer
    {
        public static async Task Initialize(Data.UsersRolesDB context, UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (rm.Roles.ToArray().Length == 0)
            {
                //return;   // DB has been seeded                
                await rm.CreateAsync(new IdentityRole("Administrator"));
                await rm.CreateAsync(new IdentityRole("Professor"));
                await rm.CreateAsync(new IdentityRole("Applicant"));
            }
            // may not want to do this till the end
            //context.SaveChanges();

            var users = new TAUser[]
                {
            new TAUser{UserName="u0000000@utah.edu", Email="u0000000@utah.edu", unid="u0000000"},
            new TAUser{UserName="u0000001@utah.edu", Email="u0000001@utah.edu", unid="u0000001"},
            new TAUser{UserName="u0000002@utah.edu", Email="u0000002@utah.edu", unid="u0000002"},
            new TAUser{UserName="u0000003@utah.edu", Email="u0000003@utah.edu", unid="u0000003"},
            new TAUser{UserName="u0000004@utah.edu", Email="u0000004@utah.edu", unid="u0000004"},
            new TAUser{UserName="u0000005@utah.edu", Email="u0000005@utah.edu", unid="u0000005"},
            new TAUser{UserName="professor@utah.edu", Email="professor@utah.edu", unid="u0000006"},
            new TAUser {UserName = "admin@utah.edu", Email = "admin@utah.edu", unid="u0000007"},
                };
            
            //poor security, easy to test, all passwords are the same as the given username
            foreach (TAUser u in users)
            {
                //context.Add(u);
                await um.CreateAsync(u, "123ABC!@#def");
                //await um.ConfirmEmailAsync(u, u.Email);
                //context.SaveChanges();

                if (u.UserName == "professor@utah.edu")
                {
                    await um.AddToRoleAsync(u, "Professor");
                }
                else if (u.UserName == "admin@utah.edu")
                {
                   await um.AddToRoleAsync(u, "Administrator");
                }
                else
                {
                   await um.AddToRoleAsync(u, "Applicant");
                }                
            }
            //context.SaveChanges();
        }
    }
}