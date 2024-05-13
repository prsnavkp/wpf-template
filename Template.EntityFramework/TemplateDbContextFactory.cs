using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.EntityFramework
{
    public class TemplateDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public TemplateDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public TemplateDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<TemplateDbContext> options = new DbContextOptionsBuilder<TemplateDbContext>();
            _configureDbContext(options);

            return new TemplateDbContext(options.Options);
        }
    }
}
