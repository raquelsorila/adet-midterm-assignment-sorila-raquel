using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskListing.Models;

namespace TaskListing.Data
{
    public class TaskListContext : DbContext
    {
        public TaskListContext(DbContextOptions<TaskListContext> options)
           : base(options)
        {
        }

        public DbSet<TaskList> Tasks { get; set; }
    }
}
