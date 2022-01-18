using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskDudes.Models;
using TaskDudes.Services;

namespace TaskDudes.Controllers
{
    public class SettingsController
    {
        static readonly TaskMatesContext context = new TaskMatesContext();

        public static Settings GetUserSettings(string userId) 
        { 
            return context.Settings.FirstOrDefault(s => s.UserId==userId); 
        }

        public async void AddNewSettingsAsync(Settings settings)
        {
            context.Settings.Add(settings);
            await context.SaveChangesAsync();
        }

        public async void UpdateSettingsAsync(Settings settings)
        {
            context.Settings.Update(settings);
            await context.SaveChangesAsync();
        }

        public async void RemoveSettingsAsync(Settings settings)
        {
            context.Settings.Remove(settings);
            await context.SaveChangesAsync();
        }
    }
}
