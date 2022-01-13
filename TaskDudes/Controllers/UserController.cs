﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskDudes.Models;
using TaskDudes.Services;

namespace TaskDudes.Controllers
{
    public class UserController
    {
        static TaskMatesContext context = new TaskMatesContext();

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUser(string id) { return context.Users.Find(id); }

        public static async void AddNewUserAsync(User user)
        {
            try
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void UpdateUserAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public async void RemoveUserAsync(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
