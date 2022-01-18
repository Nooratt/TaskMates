using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDudes.Models;
using TaskDudes.Services;

namespace TaskDudes.Controllers
{
    public class UserController
    {
        static TaskMatesContext context = new TaskMatesContext();

        public static async Task<IEnumerable<User>> GetAllUsers(bool forceRefresh = false)
        {
            return await Task.FromResult(context.Users);
        }

        public static User GetUser(string id) 
        {
            return context.Users.FirstOrDefault(s => s.Id == id);
        }

        public static User GetUserWithName(string userName)
        {
            context.Database.EnsureCreated();
            return context.Users.FirstOrDefault(s => s.UserName == userName);
        }

        public static async Task<bool> AddNewUserAsync(User user)
        {
            try
            {
                context.Database.EnsureCreated();
                context.Users.Add(user);
                context.SaveChanges();
                return await Task.FromResult(true);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static async Task<bool> UpdateUserAsync(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
            return await Task.FromResult(true);
        }

        public static async Task<bool> RemoveUserAsync(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
            return await Task.FromResult(true);
        }
    }
}
