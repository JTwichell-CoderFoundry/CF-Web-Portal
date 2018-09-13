namespace CF_Web_Portal.Migrations
{
    using CF_Web_Portal.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CF_Web_Portal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CF_Web_Portal.Models.ApplicationDbContext context)
        {
            //Create a few roles (i.e. Admin & Moderator
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            var roles = new[]
            {
                "Admin",
                "Staff",
                "Client",
                "Instructor",
                "Student"
            };

            foreach(var role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleManager.Create(new IdentityRole { Name = role});
                }
            }

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            
            if (!context.Users.Any(u => u.Email == "jtwichell@coretechs.net"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jtwichell@coretechs.net",
                    Email = "jtwichell@coretechs.net",
                    FirstName = "Jason",
                    LastName = "Twichell",
                    NickName = "The Professor"
                }, "Abcd&1234!");
            }
         
            var userId = userManager.FindByEmail("jtwichell@coretechs.net").Id;
            userManager.AddToRole(userId, "Admin");
            userManager.AddToRole(userId, "Instructor");
        }
    }
}
