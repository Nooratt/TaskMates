using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDudes.Models;
using TaskDudes.Services;

namespace TaskDudes.Controllers
{
    public class TaskController
    {
        static readonly TaskMatesContext context = new TaskMatesContext();

        public static List<Taski> GetAllUserTasks(string userId)
        {
            User user = (User)context.Users.Where(u => u.Id == userId);
            return user.Tasks;
        }

        public static List<Taski> GetAllTasks()
        {
           return context.Tasks.ToList();      
        }

        public static Taski GetTask(string id) { return context.Tasks.Find(id); }

        public static async void AddNewTask(Taski task) 
        { 
            context.Tasks.Add(task);
            await context.SaveChangesAsync();
        }

        public async void UpdateTaskAsync(Taski task)
        {
            context.Tasks.Update(task);
            await context.SaveChangesAsync();
        }

        public async void RemoveTaskAsync(Taski taski)
        {
            context.Tasks.Remove(taski);
            await context.SaveChangesAsync();
        }
    }
}
