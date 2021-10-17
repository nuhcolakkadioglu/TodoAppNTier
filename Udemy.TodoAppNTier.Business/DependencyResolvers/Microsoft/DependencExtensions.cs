using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Udemy.TodoAppNTier.DataAccess.UnitOfWork;
using Udemy.TodoAppNTier.Business.Interfaces;

namespace Udemy.TodoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkService, IWorkService>();

            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=TodoAppNTier; integrated security=true");
            });
        }
    }
}
