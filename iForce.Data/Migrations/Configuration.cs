namespace iForce.Data.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<iForce.Data.Entities.iForceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(iForce.Data.Entities.iForceDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.UserRoles.AddOrUpdate(
              new UserRole { Name = "Administrator" },
              new UserRole { Name = "Manager" },
              new UserRole { Name = "User" }
            );
            context.SaveChanges();

            context.UserStatuses.AddOrUpdate(
              new UserStatus { Name = "New" },
              new UserStatus { Name = "Active" },
              new UserStatus { Name = "Disabled" }
            );
            context.SaveChanges();

            List<string> listUserNames = getUserNameList();
            Random random = new Random();
            foreach (var name in listUserNames)
            {
                var user = new User();
                user.Name = name;
                user.UserStatusId = random.Next(1, 3);
                user.UserRoleId = random.Next(1, 3);
                user.UpdateAt = DateTime.Now;
                context.Users.AddOrUpdate(user);
            }
            context.SaveChanges();
        }

        private static List<string> getUserNameList()
        {
            return new List<string>()
                                  { "Maryland Hayworth",
                                    "Jerrold Sparrow",
                                    "Erinn Deen",
                                    "Velda Garza",
                                    "Philomena Mcduffy",
                                    "Kizzy Bussey",
                                    "Charlie Mcclard",
                                    "Ehtel Budde",
                                    "Violet Fillers",
                                    "Laurice Hockensmith",
                                    "Kiley Rench",
                                    "Aurelio Weinmann",
                                    "Irina Adrian",
                                    "Bryan Fannin",
                                    "Ruby Monzon",
                                    "Catherina ",
                                    "Rocio Scoville",
                                    "Arletha Sowders",
                                    "Kerrie Bardin",
                                    "Temika Tejeda",
                                    "Jane Haworth",
                                    "Mallory Lamica",
                                    "Monika Berrier",
                                    "Ruth Silk",
                                    "Santina Jepson",
                                    "Providencia Smeltzer",
                                    "Taunya Menjivar",
                                    "Denisse Pae",
                                    "Christia Purington",
                                    "Pandora Propp",
                                    "Gilda Stejskal",
                                    "Tammie Nam",
                                    "Columbus Crespo",
                                    "Marybelle Linch",
                                    "Doloris Levett",
                                    "Sharan Farrish",
                                    "Michiko Flick",
                                    "Margareta Makela",
                                    "Ludivina Dubuisson",
                                    "Jestine Bardwell",
                                    "Leroy Martyn",
                                    "Abbie Mathena",
                                    "Mikel Norvell",
                                    "Elisha Canty",
                                    "Scarlet Miesner",
                                    "Viola Kan",
                                    "Darby Eddie",
                                    "Star Enger",
                                    "Carrol Pryce",
                                    "Belva Kimberly" };
        }
    }
}
