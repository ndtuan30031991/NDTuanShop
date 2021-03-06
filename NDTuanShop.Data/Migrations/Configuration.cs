﻿namespace NDTuanShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NDTuanShop.Data.NDTuanShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NDTuanShop.Data.NDTuanShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new NDTuanShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NDTuanShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "ndtuan",
                Email = "nguyendinhtuan1991@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Nguyễn Đình Tuân",
            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("nguyendinhtuan1991@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

            //CreateProductCategorySample(context);
        }
        //private void CreateProductCategorySample(NDTuanShop.Data.NDTuanShopDbContext context)
        //{
        //    if(context.ProductCategories.Count() == 0)
        //    {
        //        List<ProductCategory> listProductCategoty = new List<ProductCategory>()
        //        {
        //            new ProductCategory() {Name = "Điện lạnh", Alias = "dien-lanh", Status = true },
        //            new ProductCategory() {Name = "Viễn thông", Alias = "vien-thong", Status = true },
        //            new ProductCategory() {Name = "Đồ gia dụng", Alias = "do-gia-dung", Status = true }
        //        };

        //        context.ProductCategories.AddRange(listProductCategoty);
        //        context.SaveChanges();
        //    }
        //}
    }
}
