﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tasking_CRUD.Models
{
    public class TaskDatabaseContext : DbContext 
    {
        public TaskDatabaseContext(DbContextOptions<TaskDatabaseContext> options) : base(options)
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
