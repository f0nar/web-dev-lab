using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CountriesGame.Dal.DbContext;
using CountriesGame.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CountriesGame.Bll.Infrastructure
{
    public class DataSeeder : IDataSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<User> _userManager;

        private readonly ApplicationDbContext _context;

        private readonly string _currentDirectory;

        private const string JsonFilesPath = "../CountriesGame.Bll/SeedData";

        public DataSeeder(RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            _currentDirectory = Directory.GetCurrentDirectory();
        }


        public async Task SeedDataAsync()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.MigrateAsync();

            await SeedRolesDataAsync();
            await SeedUsersDataAsync();
            await SeedDataAsync<Country>("Countries.json");
            await SeedDataAsync<Link>("Links.json");
        }

        private async Task SeedRolesDataAsync()
        {
            if (!_roleManager.Roles.Any())
            {
                var fullPath = GetFullPath("Roles.json");

                List<IdentityRole> roles;

                using (var reader = new StreamReader(fullPath))
                {
                    string rolesJson = await reader.ReadToEndAsync();
                    roles = JsonConvert.DeserializeObject<List<IdentityRole>>(rolesJson);
                }

                for (int i = 0; i < roles.Count; i++)
                {
                    await _roleManager.CreateAsync(roles[i]);
                }
            }
        }

        private async Task SeedUsersDataAsync()
        {
            if (!_userManager.Users.Any())
            {
                var fullPath = GetFullPath("Users.json");
                List<User> users;

                using (var reader = new StreamReader(fullPath))
                {
                    string usersJson = await reader.ReadToEndAsync();
                    users = JsonConvert.DeserializeObject<List<User>>(usersJson);
                }

                await _userManager.CreateAsync(users[0], "MySecret123$");
                await _userManager.AddToRoleAsync(users[0], "Lecturer");

                for (int i = 1; i < users.Count; i++)
                {
                    await _userManager.CreateAsync(users[i], "MySecret123$");
                    await _userManager.AddToRoleAsync(users[i], "Student");
                }
            }
        }

        private async Task SeedDataAsync<T>(string fileName) where T : class
        {
            if (!_context.Set<T>().Any())
            {
                var fullPath = GetFullPath(fileName);
                List<T> entities;

                using (var reader = new StreamReader(fullPath))
                {
                    string entitiesJson = await reader.ReadToEndAsync();
                    entities = JsonConvert.DeserializeObject<List<T>>(entitiesJson);
                }

                foreach (var entity in entities)
                {
                    await _context.AddAsync<T>(entity);
                }

                await _context.SaveChangesAsync();
            }
        }

        private string GetFullPath(string fileName)
        {
            var fullPath = Path.Combine(_currentDirectory, JsonFilesPath, fileName);
            return fullPath;
        }

    }
}