using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.EntityFramework
{
    public class TemplateDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public TemplateDbContext(DbContextOptions options) : base(options) { }
    }
}

