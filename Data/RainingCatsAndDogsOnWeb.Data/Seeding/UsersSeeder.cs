namespace RainingCatsAndDogsOnWeb.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using RainingCatsAndDogsOnWeb.Data.Models;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Users.Any())
            {
                var users = new List<ApplicationUser>()
            {
                  new ApplicationUser()
                {
                    FirstName = "Борислав",
                    LastName = "Йорданов",
                    Email = "borislav@abv.bg",
                    PhoneNumber = "0892077070",
                    UserName = "borislav@abv.bg",
                    NormalizedUserName = "borislav@abv.bg".ToUpper(),
                    NormalizedEmail = "borislav@abv.bg".ToUpper(),
                },

                new ApplicationUser()
                {
                    FirstName = "Filiana",
                    LastName = "Mikova",
                    Email = "mikova@mail.com",
                    PhoneNumber = "0888456310",
                    UserName = "mikova@mail.com",
                    NormalizedUserName = "mikova@mail.com".ToUpper(),
                    NormalizedEmail = "mikova@mail.com".ToUpper(),
                },

                new ApplicationUser()
                {
                    FirstName = "Viktor",
                    LastName = "Stoyanov",
                    Email = "vikstoyanov@abv.bg",
                    PhoneNumber = "0884441209",
                    UserName = "vikstoyanov@abv.bg",
                    NormalizedUserName = "vikstoyanov@abv.bg".ToUpper(),
                    NormalizedEmail = "vikstoyanov@abv.bg".ToUpper(),
                },

                new ApplicationUser()
                {
                    FirstName = "Данчо",
                    LastName = "Иванов",
                    Email = "batdachno@abv.bg",
                    PhoneNumber = "0895691062",
                    UserName = "batdachno@abv.bg",
                    NormalizedUserName = "batdachno@abv.bg".ToUpper(),
                    NormalizedEmail = "batdachno@abv.bg".ToUpper(),
                },

                new ApplicationUser()
                {
                    FirstName = "Darin",
                    LastName = "Genchew",
                    Email = "darin@gmail.com",
                    PhoneNumber = "0895455141",
                    UserName = "darin@gmail.com",
                    NormalizedUserName = "darin@gmail.com".ToUpper(),
                    NormalizedEmail = "darin@gmail.com".ToUpper(),
                },

                new ApplicationUser()
                {
                    FirstName = "Galin",
                    LastName = "Iliev",
                    Email = "galin@gmail.com",
                    PhoneNumber = "0879047794",
                    UserName = "galin@gmail.com",
                    NormalizedUserName = "galin@gmail.com".ToUpper(),
                    NormalizedEmail = "galin@gmail.com".ToUpper(),
                },

                new ApplicationUser()
                {
                    FirstName = "Блага",
                    LastName = "Йорданова",
                    Email = "blaga@yahoo.com",
                    PhoneNumber = "0886453262",
                    UserName = "blaga@yahoo.com",
                    NormalizedUserName = "blaga@yahoo.com".ToUpper(),
                    NormalizedEmail = "blaga@yahoo.com".ToUpper(),
                },

                new ApplicationUser()
                {
                    FirstName = "Дарья",
                    LastName = "Горач",
                    Email = "dashagorach@abv.bg",
                    PhoneNumber = "+380676425442",
                    UserName = "dashagorach@abv.bg",
                    NormalizedUserName = "dashagorach@abv.bg".ToUpper(),
                    NormalizedEmail = "dashagorach@abv.bg".ToUpper(),
                },

                new ApplicationUser()
                {
                    FirstName = "Светломир",
                    LastName = "Владимиров",
                    Email = "svetliovladimirov@gmail.com",
                    PhoneNumber = "0895349992",
                    UserName = "svetliovladimirov@gmail.com",
                    NormalizedUserName = "svetliovladimirov@gmail.com".ToUpper(),
                    NormalizedEmail = "svetliovladimirov@gmail.com".ToUpper(),
                },

                 new ApplicationUser()
                {
                    FirstName = "Иван",
                    LastName = "Колев",
                    Email = "ikolev@abv.bg",
                    PhoneNumber = "0897266744",
                    UserName = "ikolev@abv.bg",
                    NormalizedUserName = "ikolev@abv.bg".ToUpper(),
                    NormalizedEmail = "ikolev@abv.bg".ToUpper(),
                },
            };

                var passwordHasher = new PasswordHasher<ApplicationUser>();

                users[0].PasswordHash = passwordHasher.HashPassword(users[0], "12345");
                users[1].PasswordHash = passwordHasher.HashPassword(users[1], "1q2w3e4r");
                users[2].PasswordHash = passwordHasher.HashPassword(users[2], "qwerty!");
                users[3].PasswordHash = passwordHasher.HashPassword(users[3], "1235");
                users[4].PasswordHash = passwordHasher.HashPassword(users[4], "1q2w3e4r5t");
                users[5].PasswordHash = passwordHasher.HashPassword(users[5], "54321");
                users[6].PasswordHash = passwordHasher.HashPassword(users[6], "qwerty123");
                users[7].PasswordHash = passwordHasher.HashPassword(users[7], "1232!");
                users[8].PasswordHash = passwordHasher.HashPassword(users[8], "1q2w3e");
                users[9].PasswordHash = passwordHasher.HashPassword(users[9], "bonboni123");

                await dbContext.Users.AddRangeAsync(users);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}

