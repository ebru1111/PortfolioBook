namespace PortfolioBook.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PortfolioBook.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PortfolioBook.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PortfolioBook.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole() { Name = "Admin" });

            if (!roleManager.RoleExists("Moderator"))
                roleManager.Create(new IdentityRole() { Name = "Moderator" });

            if (!roleManager.RoleExists("User"))
                roleManager.Create(new IdentityRole() { Name = "User" });

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var adminUser = userManager.FindByName("a@a.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = "a@a.com",
                    Email = "a@a.com"
                };
                userManager.Create(adminUser, "Ankara1.");
            }

            if (!userManager.IsInRole(adminUser.Id, "admin"))
                userManager.AddToRole(adminUser.Id, "admin");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
