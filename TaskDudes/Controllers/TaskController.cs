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
            return context.Tasks.Where(t => t.UserId==userId).ToList();
        }

        public static List<Taski> GetAllTasks()
        {
           return context.Tasks.ToList();      
        }

        public static Taski GetTask(string id) { return context.Tasks.Find(id); }

        public static void AddNewTask(Taski task) 
        {
            try
            {
                context.Database.EnsureCreated();
                context.Tasks.Add(task);
                context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async void UpdateTaskAsync(Taski task)
        {
            context.Tasks.Update(task);
            await context.SaveChangesAsync();
        }

        public static async void RemoveTaskAsync(Taski taski)
        {
            context.Tasks.Remove(taski);
            await context.SaveChangesAsync();
        }
    }
}
