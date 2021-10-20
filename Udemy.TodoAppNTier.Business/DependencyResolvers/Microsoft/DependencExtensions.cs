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
using Udemy.TodoAppNTier.Business.Services;
using AutoMapper;
using Udemy.TodoAppNTier.Business.Mappings.AutoMapper;
using Udemy.TodoAppNTier.Dtos.WorkDtos;
using Udemy.TodoAppNTier.Business.ValidationRules;
using FluentValidation;

namespace Udemy.TodoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkService, WorkService>();
            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=TodoAppNTier; integrated security=true");
            });
        }
    }
}
